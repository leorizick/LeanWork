import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RhWebApiService } from '../services/rh-web-api.service';
import { Technology } from '../models/technology.model';

@Component({
  selector: 'app-cad-technology',
  templateUrl: './cad-technology.component.html',
  styleUrl: './cad-technology.component.css'
})
export class CadTechnologyComponent implements OnInit {
  technologyFormGroup: FormGroup = this.formBuilder.group({
    name: ['', Validators.required]
  })

  constructor(private readonly rhWebApi: RhWebApiService,
    private readonly formBuilder: FormBuilder,
    private readonly router: Router) {

  }

  ngOnInit(): void {
    this.technologyFormGroup.getRawValue();
  }

  onSubmit() {
    const technology: Technology = this.technologyFormGroup.getRawValue();
    this.rhWebApi.postTechnology(technology).subscribe(res => this.router.navigateByUrl(''));
  }

}
