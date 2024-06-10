import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RhWebApiService } from '../services/rh-web-api.service';
import { Router } from '@angular/router';
import { Vacancy } from '../models/vacancy.model';

@Component({
  selector: 'app-cad-vacancy',
  templateUrl: './cad-vacancy.component.html',
  styleUrl: './cad-vacancy.component.css'
})
export class CadVacancyComponent implements OnInit {
  vacancyFormGroup: FormGroup = this.formBuilder.group({
    name: ['', Validators.required],
    description: ['', Validators.required]
  })

  constructor(private readonly rhWebApi: RhWebApiService,
    private readonly formBuilder: FormBuilder,
    private readonly router: Router) {

  }

  ngOnInit(): void {
    this.vacancyFormGroup.getRawValue();
  }

  onSubmit() {
    const vacancy: Vacancy = this.vacancyFormGroup.getRawValue();
    this.rhWebApi.postVacancy(vacancy).subscribe(res => this.router.navigateByUrl(''));
  }
}
