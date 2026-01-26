import { inject, injectable } from "inversify";
import { Persona } from "../entities/Persona";
import { IPersonasUseCase } from "../interfaces/IPersonasUseCase";
import { TYPES } from "../../core/types";
import { PersonasRepositoryAzure } from "../../data/repos/RepoPersonas";

@injectable()
export class PersonasUseCase implements IPersonasUseCase{
    _listaPersonas: Promise<Persona[]>;

    constructor(@inject(TYPES.IReposPersonas) private repoPersonas: PersonasRepositoryAzure){ 
    this._listaPersonas = this.repoPersonas.getListadoCompletoPersonas()
    };
    
    async getListaPersonas(): Promise<Persona[]> {
        return this._listaPersonas
    }
}