import { Technology } from "./technology.model";
import { Vacancy } from "./vacancy.model";

export interface VacancyTechnologyValue{
    id?: number,
    vacancy?: Vacancy,
    technology?: Technology,
    value?:number,
    creation?: Date
}