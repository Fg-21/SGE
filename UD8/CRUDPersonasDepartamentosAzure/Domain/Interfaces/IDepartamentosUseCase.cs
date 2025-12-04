using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDepartamentosUseCase
    {
        #region CRUD Methods
        int createDepartamento(Departamento newDepartamento);
        Departamento getDepartamentoById(int id);
        Departamento[] getListaDepartamento();
        int updateDepartamento(int id, Departamento eDepartamento);
        int deleteDepartamento(int id);
        List<Departamento> getLISTADepartamento();
        #endregion
    }
}

