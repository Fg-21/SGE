using Domain.Entities;
using Domain.Interfaces;
using Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class DefGetListaPersonasUseCase : IGetListaPersonasUseCase
    {
        private readonly IRepoPersonasDepartamentos _repository;

        public DefGetListaPersonasUseCase(IRepoPersonasDepartamentos getListaPersonas)
        {
            _repository = getListaPersonas;
        }

        public Persona[] getListaPersonas()
        {
            return _repository.getListaPersonas();
        }
    }
}
