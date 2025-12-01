using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{
    public class DepartamentoController : Controller
    {
        #region Fields
        private readonly IDepartamentosUseCase _departamentoUseCase;
        #endregion

        #region Constructors
        public DepartamentoController(IDepartamentosUseCase departamentoUseCase)
        {
            _departamentoUseCase = departamentoUseCase;
        }
        #endregion

        #region Actions

        // Listado de departamentos
        public IActionResult listado()
        {
            var lista = _departamentoUseCase.getListaDepartamento();
            return View(lista);
        }

        // Detalle de un departamento
        public IActionResult detalle(int id)
        {
            Departamento dpto = _departamentoUseCase.getDepartamentoById(id);
            if (dpto == null)
                return NotFound();

            return View(dpto);
        }

        // Crear departamento - GET
        public IActionResult crear()
        {
            return View();
        }

        // Crear departamento - POST
        [HttpPost]
        public IActionResult crear(Departamento newDpto)
        {
            if (ModelState.IsValid)
            {
                _departamentoUseCase.createDepartamento(newDpto);
                return RedirectToAction("listado");
            }

            return View(newDpto);
        }

        // Editar departamento - GET
        public IActionResult editar(int id)
        {
            Departamento dpto = _departamentoUseCase.getDepartamentoById(id);
            if (dpto == null)
                return NotFound();

            return View(dpto);
        }

        // Editar departamento - POST
        [HttpPost]
        public IActionResult editar(int id, Departamento editedDpto)
        {
            if (ModelState.IsValid)
            {
                _departamentoUseCase.updateDepartamento(id, editedDpto);
                return RedirectToAction("listado");
            }

            return View(editedDpto);
        }

        // Eliminar departamento - GET (confirmación)
        public IActionResult eliminar(int id)
        {
            Departamento dpto = _departamentoUseCase.getDepartamentoById(id);
            if (dpto == null)
                return NotFound();

            return View(dpto);
        }

        // Eliminar departamento - POST
        [HttpPost]
        public IActionResult eliminar(int id, IFormCollection collection)
        {
            _departamentoUseCase.deleteDepartamento(id);
            return RedirectToAction("listado");
        }

        #endregion
    }
}

