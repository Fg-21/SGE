import { Persona } from "../entities/Persona";

export interface IPersonasUseCase {
    getListaPersonas(): Promise<Persona[]>;
}