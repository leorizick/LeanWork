import { Component, OnInit } from '@angular/core';
import { Candidate } from '../models/candidate.model';
import { RhWebApiService } from '../services/rh-web-api.service';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html',
  styleUrl: './candidate-list.component.css'
})
export class CandidateListComponent implements OnInit {

  protected candidateList: Candidate[] | undefined;

  constructor(private readonly rhWebApi: RhWebApiService) {

  }

  ngOnInit(): void {
    this.rhWebApi.getCandidates().subscribe(res => {
      this.candidateList = res;
      console.log(res);
    })
  }
}
