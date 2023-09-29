using lojadotorviz.Model;

namespace lojadotorviz.Service
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();

        Task<Categoria?> GetById(long id);

        Task<IEnumerable<Categoria>> GetByTipo(string tipo);

        Task<Categoria?> Create(Categoria Categorias);

        Task<Categoria?> Update(Categoria Categorias);

        Task Delete(Categoria Categorias);
    }
}
