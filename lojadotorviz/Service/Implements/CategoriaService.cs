using lojadotorviz.Data;
using lojadotorviz.Model;
using Microsoft.EntityFrameworkCore;

namespace lojadotorviz.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias
                       .Include(t => t.Produto)
                       .ToListAsync();
        }

        public async Task<Categoria?> GetById(long id)
        {
            try
            {
                var Categoria = await _context.Categorias
                                .Include(t => t.Produto)
                                .FirstAsync(i => i.Id == id);

                return Categoria;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Categoria>> GetByTipo(string tipo)
        {
            var Tema = await _context.Categorias
                            .Include(t => t.Produto)
                            .Where(t => t.Tipo.Contains(tipo))
                            .ToListAsync();

            return Tema;
        }

        public async Task<Categoria?> Create(Categoria Categorias)
        {
            _context.Categorias.Add(Categorias);
            await _context.SaveChangesAsync();

            return Categorias;
        }
        public async Task<Categoria?> Update(Categoria Categorias)
        {
            var CategoriaUpdate = await _context.Categorias.FindAsync(Categorias.Id);

            if (CategoriaUpdate is null)
                return null;

            _context.Entry(CategoriaUpdate).State = EntityState.Detached;
            _context.Entry(Categorias).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Categorias;
        }

        public async Task Delete(Categoria Categorias)
        {
            _context.Remove(Categorias);
            await _context.SaveChangesAsync();
        }
    }
}
