import { Component, OnInit } from '@angular/core';
import { Candidate } from '../models/candidate.model';
import { RhWebApiService } from '../services/rh-web-api.service';
import { VacancyTechnologyValue } from '../models/vacancytechnologyvalue.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-final-report',
  templateUrl: './final-report.component.html',
  styleUrl: './final-report.component.css'
})
export class FinalReportComponent implements OnInit {


  protected vacancyTechnology: VacancyTechnologyValue[] | undefined;

  vacancyTechnologyFormGroup: FormGroup = this.formBuilder.group({
    name: ['', Validators.required],
    description: ['', Validators.required]
  })

  constructor(private readonly rhWebApi: RhWebApiService,
    private readonly formBuilder: FormBuilder,
    private readonly router: Router) {

  }

  ngOnInit(): void {
    this.rhWebApi.getVacancyTechnologyValue().subscribe(res => {
      this.vacancyTechnology = res;
      console.log(res);
    })
  }
  
  onSubmit() {
    throw new Error('Method not implemented.');
  }
}
