using APICadastroPF.Data;
using APICadastroPF.Data.Dtos;
using APICadastroPF.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APICadastroPF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaFisicaController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public PessoaFisicaController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreatePessoaDto pessoaFisicaDto)
        {
            PessoaFisica pessoa = _mapper.Map<PessoaFisica>(pessoaFisicaDto);

            _context.PessoaFisica.Add(pessoa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Cpf = pessoa.Cpf }, pessoa);
        }

        [HttpGet]
        public IEnumerable<PessoaFisica> RecuperaFilmes()
        {
            return _context.PessoaFisica;
        }

        [HttpGet("{Cpf}")]
        public IActionResult RecuperaFilmesPorId(string Cpf )
        {
            PessoaFisica pessoa = _context.PessoaFisica.FirstOrDefault(pessoa => pessoa.Cpf == Cpf);
            if (pessoa != null)
            {
                ReadPessoaDto shapeDto = _mapper.Map<ReadPessoaDto>(pessoa);

                return Ok(shapeDto);
            }
            return NotFound();
        }

        [HttpPut("{Cpf}")]
        public IActionResult AtualizaShape(string cpf, [FromBody] UpdatePessoaDto pessoaDto)
        {
            PessoaFisica pessoa = _context.PessoaFisica.FirstOrDefault(shape => shape.Cpf == cpf);
            if (pessoa == null)
            {
                return NotFound();
            }
            _mapper.Map(pessoaDto, pessoa);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{Cpf}")]
        public IActionResult DeletaShape(string cpf)
        {
            var pessoa = _context.PessoaFisica.FirstOrDefault(pessoa => pessoa.Cpf == cpf);
            if (pessoa == null)
            {
                return NotFound();
            }
            _context.Remove(pessoa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
