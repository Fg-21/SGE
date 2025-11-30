using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Interfaces;

namespace UseCases
{
    public class DepartamentosUseCase : IDepartamentosUseCase
    {
        #region Fields
        private readonly IRepoDepartamentos _repoDepartamentos;
        #endregion

        #region Constructors
        public DepartamentosUseCase(IRepoDepartamentos repoDepartamentos)
        {
            _repoDepartamentos = repoDepartamentos;
        }
        #endregion

        #region CRUD Methods
        public int createDepartamento(Departamento newDepartamento)
        {
            return _repoDepartamentos.createDepartamento(newDepartamento);
        }

        public Departamento getDepartamentoById(int id)
        {
            return _repoDepartamentos.getDepartamentoById(id);
        }

        public Departamento[] getListaDepartamento()
        {
            return _repoDepartamentos.getListaDepartamento();
        }

        public int updateDepartamento(int id, Departamento eDepartamento)
        {
            return _repoDepartamentos.updateDepartamento(id, eDepartamento);
        }

        public int deleteDepartamento(int id)
        {
            int resultado = 0;

            // Llama al repo para contar personas asociadas a este departamento
            int personasAsociadas = _repoDepartamentos.contarPersonasDepartamentos(id);

            if (personasAsociadas == 0)
            {
                resultado = _repoDepartamentos.deleteDepartamento(id);
            }

            return resultado;
        }
        #endregion
    }
}

