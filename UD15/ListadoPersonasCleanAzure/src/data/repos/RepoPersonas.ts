import { Injectable } from "@angular/core";
import { Persona } from "../../domain/entities/Persona";
import { IRepoPersonas } from "../../domain/interfaces/IRepoPersonas";
import ApiBase from "../api/ApiBase";

@Injectable({
    providedIn: 'root'
})
export class PersonasRepositoryAzure implements IRepoPersonas {
    API_URL = ApiBase.getApiBase()
    
    async getListadoCompletoPersonas(): Promise<Persona[]> {
        try {
            const response = await fetch(this.API_URL + "PersonasApi");

            if (!response.ok) {
                throw new Error(`Error HTTP: ${response.status} ${response.statusText}`);
            }

            const data: any[] = await response.json();

            // Mapear los datos de la API a instancias de Persona
            return data.map((item: any) => new Persona(
                item.id,
                item.nombre,
                item.apellido,
                new Date(item.fechaNac),
                item.direccion,
                item.telefono,
                item.imagen,
                item.idDepartamento
            ));

        } catch (error) {
            console.error("Error al obtener personas:", error);
            throw error;
        }
    }
}