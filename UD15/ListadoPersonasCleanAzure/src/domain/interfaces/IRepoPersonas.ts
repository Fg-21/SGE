import { Persona } from "../entities/Persona";

export interface IRepoPersonas {
    getListadoCompletoPersonas(): Promise<Persona[]>;
}