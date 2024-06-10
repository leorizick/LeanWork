import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateListComponent } from './candidate-list/candidate-list.component';
import { CadCandidateComponent } from './cad-candidate/cad-candidate.component';
import { CadTechnologyComponent } from './cad-technology/cad-technology.component';
import { CadVacancyComponent } from './cad-vacancy/cad-vacancy.component';
import { FinalReportComponent } from './final-report/final-report.component';

const routes: Routes = [
  { path: '', redirectTo: '/candidates', pathMatch:'full' },
  { path: 'candidates', component: CandidateListComponent },
  { path: 'CadCandidate', component: CadCandidateComponent },
  { path: 'CadTechnology', component: CadTechnologyComponent },
  { path: 'CadVacancy', component: CadVacancyComponent },
  { path: 'Report', component: FinalReportComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
