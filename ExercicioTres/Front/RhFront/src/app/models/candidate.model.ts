import { Technology } from "./technology.model";
import { Vacancy } from "./vacancy.model";

export interface Candidate{
    id?: number,
    name: string,
    vacancy: Vacancy,
    technologies: Technology[],
    creation?: string


}