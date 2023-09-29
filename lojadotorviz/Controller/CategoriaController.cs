using FluentValidation;
using lojadotorviz.Model;
using lojadotorviz.Service;
using Microsoft.AspNetCore.Mvc;

namespace lojadotorviz.Controller
{
    [Route("~/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IValidator<Categoria> _categoriaValidator;

        public CategoriaController(
           ICategoriaService categoriaService,
            IValidator<Categoria> categoriaValidator)
        {
            _categoriaService = categoriaService;
            _categoriaValidator = categoriaValidator;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _categoriaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _categoriaService.GetById(id);

            if (Resposta is null)
                return NotFound();

            return Ok(Resposta);
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult> GetByTipo(string tipo)
        {
            return Ok(await _categoriaService.GetByTipo(tipo));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Categoria categoria)
        {
            var ValidarCategoria = await _categoriaValidator.ValidateAsync(categoria);

            if (!ValidarCategoria.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ValidarCategoria);

            var Resposta = await _categoriaService.Create(categoria);

            if (Resposta is null)
                return BadRequest("Categoria Não Encontrada!");

            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Categoria categoria)
        {
            if (categoria.Id == 0)
                return BadRequest("Id da Categoria é Invalido");

            var ValidarCategoria = await _categoriaValidator.ValidateAsync(categoria);

            if (!ValidarCategoria.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ValidarCategoria);

            var Resposta = await _categoriaService.Update(categoria);

            if (Resposta is null)
                return NotFound("Categoria Não Encontrada");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaCategoria = await _categoriaService.GetById(id);

            if (BuscaCategoria is null)
                return NotFound("Categoria não Encontrada.");

            await _categoriaService.Delete(BuscaCategoria);

            return NoContent();
        }
    }
}
