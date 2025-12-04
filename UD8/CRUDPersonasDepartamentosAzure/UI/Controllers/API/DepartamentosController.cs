using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {

        #region Campos
        private readonly IDepartamentosUseCase _departamentoUseCase;
        #endregion

        #region useCases
        public DepartamentosController(IDepartamentosUseCase departamentoUseCase)
        {
            _departamentoUseCase = departamentoUseCase;
        }
        #endregion

        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<Departamento> lista;
            try
            {
                lista = _departamentoUseCase.getLISTADepartamento();
                if (lista.Count == 0) {
                    salida = NotFound();
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

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            try
            {
                Departamento departamento = _departamentoUseCase.getDepartamentoById(id);
                salida = Ok(departamento);
            }
            catch
            {
                salida = NoContent();
            }


            return salida;
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public IActionResult Post(Departamento dpto)
        {
            IActionResult salida;
            int filasAfectadas;

            try
            {
                filasAfectadas = _departamentoUseCase.createDepartamento(dpto);
                if (filasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(dpto);
                }
            }
            catch
            {
                salida = BadRequest();
            }


            return salida;
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Departamento dpto)
        {
            IActionResult salida;
            int filasAfectadas;

            try
            {
                filasAfectadas = _departamentoUseCase.updateDepartamento(id, dpto);
                if (filasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(dpto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int filasAfectadas;
            Departamento dpto;

            try
            {
                dpto = _departamentoUseCase.getDepartamentoById(id);
                filasAfectadas = _departamentoUseCase.deleteDepartamento(id);
                if (filasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(dpto);
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }
    }
}
