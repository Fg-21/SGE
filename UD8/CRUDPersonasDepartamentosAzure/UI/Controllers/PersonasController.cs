using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    using Domain.Dtos;
    using Domain.Entities;
    using Domain.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    namespace UI.Controllers
    {
        public class PersonasController : Controller
        {
            #region Fields
            private readonly IPersonasUseCase _personaUseCase;
            private readonly IDepartamentosUseCase _departamentoUseCase;
            #endregion

            #region Constructors
            public PersonasController(IPersonasUseCase personaUseCase, IDepartamentosUseCase departamentoUseCase)
            {
                _personaUseCase = personaUseCase;
                _departamentoUseCase = departamentoUseCase;
            }
            #endregion

            #region Actions

            // Listado de personas
            public IActionResult listado()
            {
                var personas = _personaUseCase.getListaPersonas();
                return View(personas);
            }

            // Detalle de una persona con nombre del departamento
            public IActionResult detalle(int idPersonaSeleccionada)
            {
                PersonaWithNombreDepartamentoDto personaDto =
                    _personaUseCase.getPersonaWithNombreDepartamentoById(idPersonaSeleccionada);

                if (personaDto == null)
                    return NotFound();

                return View(personaDto);
            }

            // Crear persona - GET
            public IActionResult crear()
            {
                // Traer lista de departamentos para el dropdown
                List<Domain.Entities.Departamento> listaDepartamentos =
                    new List<Domain.Entities.Departamento>(_departamentoUseCase.getListaDepartamento());

                return View(listaDepartamentos);
            }

            // Crear persona - POST
            [HttpPost]
            public IActionResult crear(Persona newPersona)
            {
                if (ModelState.IsValid)
                {
                    _personaUseCase.createPersona(newPersona);
                    return RedirectToAction("listado");
                }

                // Si falla validación, recargar lista de departamentos
                List<Domain.Entities.Departamento> listaDepartamentos =
                    new List<Domain.Entities.Departamento>(_departamentoUseCase.getListaDepartamento());

                return View(listaDepartamentos);
            }

            // Editar persona - GET
            public IActionResult editar(int idPersonaSeleccionada)
            {
                PersonaWithListaDepartamentosDto personaDto =
                    _personaUseCase.getPersonaWithListaDepartamentos(idPersonaSeleccionada);

                if (personaDto == null)
                    return NotFound();

                return View(personaDto);
            }

            // Editar persona - POST
            [HttpPost]
            public IActionResult editar(int idPersonaSeleccionada, Persona editedPersona)
            {
                if (ModelState.IsValid)
                {
                    _personaUseCase.updatePersona(idPersonaSeleccionada, editedPersona);
                    return RedirectToAction("listado");
                }

                // Si falla validación, recargar DTO para volver a mostrar el formulario
                PersonaWithListaDepartamentosDto personaDto =
                    _personaUseCase.getPersonaWithListaDepartamentos(idPersonaSeleccionada);

                return View(personaDto);
            }

            // Eliminar persona - GET (confirmación)
            public IActionResult eliminar(int idPersonaSeleccionada)
            {
                PersonaWithNombreDepartamentoDto personaDto =
                    _personaUseCase.getPersonaWithNombreDepartamentoById(idPersonaSeleccionada);

                if (personaDto == null)
                    return NotFound();

                return View(personaDto);
            }

            // Eliminar persona - POST
            [HttpPost]
            public IActionResult eliminar(int idPersonaAEliminar, IFormCollection collection)
            {
                _personaUseCase.deletePersona(idPersonaAEliminar);
                return RedirectToAction("listado");
            }

            #endregion
        }
    }
}
