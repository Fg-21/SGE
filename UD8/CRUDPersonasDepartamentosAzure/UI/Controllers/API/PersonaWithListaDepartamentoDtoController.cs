using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaWithListaDepartamentoDtoController : ControllerBase
    {
        private readonly IPersonasUseCase _personasUseCase;

        public PersonaWithListaDepartamentoDtoController(IPersonasUseCase personasUseCase)
        {
            _personasUseCase = personasUseCase;
        }

        // GET: api/<PersonaWithListaDepartamentoDtoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaWithListaDepartamentosDto> lista;
            try
            {
                lista = _personasUseCase.getListaPersonasWithListaDepartamentosDto();
                if (lista.Count == 0) {
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

        // GET api/<PersonaWithListaDepartamentoDtoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PersonaWithListaDepartamentosDto persona;
            IActionResult salida;

            try
            {
                persona = _personasUseCase.getPersonaWithListaDepartamentos(id);
                salida = Ok(persona);
            }
            catch
            {
                salida = NotFound();
            }

            return salida;
        }
    }
}
