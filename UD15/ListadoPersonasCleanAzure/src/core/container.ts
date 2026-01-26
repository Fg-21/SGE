import { Container } from "inversify";
import "reflect-metadata";

import { IPersonasUseCase } from "../domain/interfaces/IPersonasUseCase";
import { IRepoPersonas } from "../domain/interfaces/IRepoPersonas";
import { TYPES } from "./types";
import { PersonasRepositoryAzure } from "../data/repos/RepoPersonas";
import { PersonasUseCase } from "../domain/usecases/PersonasUseCase";

const container = new Container()

container.bind<IRepoPersonas>(TYPES.IReposPersonas).to(PersonasRepositoryAzure)
container.bind<IPersonasUseCase>(TYPES.IPersonasUseCase).to(PersonasUseCase)

export {container};