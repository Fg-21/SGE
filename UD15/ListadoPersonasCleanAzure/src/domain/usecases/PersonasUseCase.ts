import { Persona } from "../entities/Persona";
import { IPersonasUseCase } from "../interfaces/IPersonasUseCase";

export class PersonasUseCase implements IPersonasUseCase{
    getListaPersonas(): Promise<Persona[]> {
        throw new Error("Method not implemented.");
    }
}