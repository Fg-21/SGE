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
        public IActionResult detalle(int idDptoSeleccionado)
        {
            Departamento dpto = _departamentoUseCase.getDepartamentoById(idDptoSeleccionado);
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
        public IActionResult editar(int idDptoSeleccionado)
        {
            Departamento dpto = _departamentoUseCase.getDepartamentoById(idDptoSeleccionado);
            if (dpto == null)
                return NotFound();

            return View(dpto);
        }

        // Editar departamento - POST
        [HttpPost]
        public IActionResult editar(int idDptoSeleccionado, Departamento editedDpto)
        {
            if (ModelState.IsValid)
            {
                _departamentoUseCase.updateDepartamento(idDptoSeleccionado, editedDpto);
                return RedirectToAction("listado");
            }

            return View(editedDpto);
        }

        // Eliminar departamento - GET (confirmación)
        public IActionResult eliminar(int idDptoSeleccionado)
        {
            Departamento dpto = _departamentoUseCase.getDepartamentoById(idDptoSeleccionado);
            if (dpto == null)
                return NotFound();

            return View(dpto);
        }

        // Eliminar departamento - POST
        [HttpPost]
        public IActionResult eliminar(int idDptoAEliminar, IFormCollection collection)
        {
            _departamentoUseCase.deleteDepartamento(idDptoAEliminar);
            return RedirectToAction("listado");
        }

        #endregion
    }
}

