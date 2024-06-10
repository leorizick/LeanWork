import { Component, OnInit } from '@angular/core';
import { Candidate } from '../models/candidate.model';
import { RhWebApiService } from '../services/rh-web-api.service';
import { VacancyTechnologyValue } from '../models/vacancytechnologyvalue.model';

@Component({
  selector: 'app-final-report',
  templateUrl: './final-report.component.html',
  styleUrl: './final-report.component.css'
})
export class FinalReportComponent implements OnInit{

  protected vacancyTechnology: VacancyTechnologyValue[] | undefined;

  constructor(private readonly rhWebApi: RhWebApiService) {

  }

  ngOnInit(): void {
    this.rhWebApi.getVacancyTechnologyValue().subscribe(res => {
      this.vacancyTechnology = res;
      console.log(res);
    })
  }
}
