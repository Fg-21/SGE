using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    using Domain.Dtos;
    using Domain.Entities;
    using Domain.Interfaces;
    using Microsoft.AspNetCore.Mvc;

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
            public IActionResult detalle(int id)
            {
                PersonaWithNombreDepartamentoDto personaDto =
                    _personaUseCase.getPersonaWithNombreDepartamentoById(id);

                if (personaDto == null)
                    return NotFound();

                return View(personaDto);
            }

            // Crear persona - GET
            public IActionResult crear()
            {                
                    var dto = _personaUseCase.GetPersonaParaCrear();
                    return View(dto);
            }

            // Crear persona - POST
            [HttpPost]
            public IActionResult crear(Persona newPersona)
            {
                if (ModelState.IsValid)
                {
                    var dto = _personaUseCase.GetPersonaParaCrear();
                    dto.persona = newPersona;
                    return View(dto);
                }

                try
                {
                    // 2. Guardar la persona y verificar si la operación fue exitosa (debe devolver > 0)
                    int rowsAffected = _personaUseCase.createPersona(newPersona);

                    if (rowsAffected > 0)
                    {
                        // Éxito: Redirige a la lista
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Falló la inserción sin lanzar excepción (por ejemplo, lógica interna del Use Case)
                        throw new Exception("La base de datos no pudo crear la persona.");
                    }
                }
                catch (Exception ex)
                {
                    // 3. Error: Vuelve a la vista de creación y muestra el error
                    var dto = _personaUseCase.GetPersonaParaCrear();
                    dto.persona = newPersona; // Asegura que se muestren los datos que el usuario intentó guardar
                    ModelState.AddModelError("", $"Error al crear la persona: {ex.Message}");
                    return View(dto);
                }
            }
            

            // Editar persona - GET
            public IActionResult editar(int id)
            {
                PersonaWithListaDepartamentosDto personaDto =
                    _personaUseCase.getPersonaWithListaDepartamentos(id);

                if (personaDto == null)
                    return NotFound();

                return View(personaDto);
            }

            // Editar persona - POST
            [HttpPost]
            public IActionResult editar(int id, Persona editedPersona)
            {
                if (ModelState.IsValid)
                {
                    _personaUseCase.updatePersona(id, editedPersona);
                    return RedirectToAction("listado");
                }

                // Si falla validación, recargar DTO para volver a mostrar el formulario
                PersonaWithListaDepartamentosDto personaDto =
                    _personaUseCase.getPersonaWithListaDepartamentos(id);

                return View(personaDto);
            }

            // Eliminar persona - GET (confirmación)
            public IActionResult eliminar(int id)
            {
                PersonaWithNombreDepartamentoDto personaDto =
                    _personaUseCase.getPersonaWithNombreDepartamentoById(id);

                if (personaDto == null)
                    return NotFound();

                return View(personaDto);
            }

            // Eliminar persona - POST
            [HttpPost]
            public IActionResult eliminar(int id, IFormCollection collection)
            {
                _personaUseCase.deletePersona(id);
                return RedirectToAction("listado");
            }

            #endregion
        }
    }
}
