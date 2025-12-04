using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaWithNombreDepartamentoDtoController : ControllerBase
    {
        private readonly IPersonasUseCase _personasUseCase;

        public PersonaWithNombreDepartamentoDtoController(IPersonasUseCase personasUseCase)
        {
            _personasUseCase = personasUseCase;
        }

        // GET: api/<PersonaWithNombreDepartamentoDto>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaWithNombreDepartamentoDto> lista = new List<PersonaWithNombreDepartamentoDto>();

            try
            {
                lista = _personasUseCase.getListaPersonasWithNombreDptos();
                if (lista.Count > 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(lista);
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        // GET api/<PersonaWithNombreDepartamentoDto>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PersonaWithNombreDepartamentoDto personaWNDpto;
            IActionResult salida;

            try
            {
                personaWNDpto = _personasUseCase.getPersonaWithNombreDepartamentoById(id);
                salida = Ok(personaWNDpto);
            }
            catch
            {
                salida = NotFound();
            }
            return salida;
        }
    }
}
