import { Component, OnInit } from '@angular/core';
import { Candidate } from '../models/candidate.model';
import { RhWebApiService } from '../services/rh-web-api.service';
import { Technology } from '../models/technology.model';
import { Vacancy } from '../models/vacancy.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-cad-candidate',
  templateUrl: './cad-candidate.component.html',
  styleUrl: './cad-candidate.component.css'
})
export class CadCandidateComponent implements OnInit {
  candidateFormGroup: FormGroup = this.formBuilder.group({
    name: ['', Validators.required],
    technology: [undefined, Validators.required],
    vacancy: [undefined, Validators.required]
  })
  technologies: Technology[] = [];
  vacancies: Vacancy[] = [];

  constructor(private readonly rhWebApi: RhWebApiService,
     private readonly formBuilder: FormBuilder,
    private readonly router: Router) {

  }

  ngOnInit(): void {
    this.rhWebApi.getTechnologies().subscribe(res => {
      this.technologies = res;
    })
    this.rhWebApi.getVacancies().subscribe(res => {
      this.vacancies = res;
    })
  }

  onSubmit() {
    const candidate: Candidate = {
      creation: '2024-06-10T00:13:26.110Z',
      id: 0,
      name: this.candidateFormGroup.controls['name'].value,
      technologies: this.candidateFormGroup.controls['technology'].value,
      vacancy: this.candidateFormGroup.controls['vacancy'].value[0]
    }
    this.rhWebApi.postCandidate(candidate).subscribe(res => this.router.navigateByUrl(''));
  }

}
