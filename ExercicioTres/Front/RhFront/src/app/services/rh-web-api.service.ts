import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Candidate } from '../models/candidate.model';
import { Technology } from '../models/technology.model';
import { Vacancy } from '../models/vacancy.model';
import { VacancyTechnologyValue } from '../models/vacancytechnologyvalue.model';

@Injectable({
  providedIn: 'root'
})
export class RhWebApiService {
  private baseUrl: string = 'http://localhost:8080/api';

  constructor(private http: HttpClient) { }

  getCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(`${this.baseUrl}/Candidate`)
  }

  postCandidate(candidate: Candidate): Observable<Candidate> {
    return this.http.post<Candidate>(`${this.baseUrl}/Candidate`, candidate)
  }

  getTechnologies(): Observable<Technology[]> {
    return this.http.get<Technology[]>(`${this.baseUrl}/Technology`)
  }

  postTechnology(technology: Technology): Observable<Technology> {
    return this.http.post<Technology>(`${this.baseUrl}/Technology`, technology)
  }

  getVacancies(): Observable<Vacancy[]> {
    return this.http.get<Vacancy[]>(`${this.baseUrl}/Vacancy`)
  }

  postVacancy(vacancy: Vacancy): Observable<Vacancy> {
    return this.http.post<Vacancy>(`${this.baseUrl}/Vacancy`, vacancy)
  }

  getVacancyTechnologyValue(): Observable<VacancyTechnologyValue[]> {
    return this.http.get<VacancyTechnologyValue[]>(`${this.baseUrl}/VacancyTechnologyValue`)
  }

  postReport(vacancyTechnologyValue: VacancyTechnologyValue): Observable<VacancyTechnologyValue>{
    return this.http.post<VacancyTechnologyValue>(`${this.baseUrl}/FinalReport`, vacancyTechnologyValue)
  }
}
