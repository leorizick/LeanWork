import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgOptimizedImage } from '@angular/common';
import { HttpClientModule, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { CandidateListComponent } from './candidate-list/candidate-list.component';
import { CadCandidateComponent } from './cad-candidate/cad-candidate.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CadTechnologyComponent } from './cad-technology/cad-technology.component';
import { CadVacancyComponent } from './cad-vacancy/cad-vacancy.component';
import { FinalReportComponent } from './final-report/final-report.component';

@NgModule({
  declarations: [
    AppComponent,
    CandidateListComponent,
    CadCandidateComponent,
    CadTechnologyComponent,
    CadVacancyComponent,
    FinalReportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgOptimizedImage,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [[provideHttpClient(withInterceptorsFromDi())]],
  bootstrap: [AppComponent]
})
export class AppModule { }
