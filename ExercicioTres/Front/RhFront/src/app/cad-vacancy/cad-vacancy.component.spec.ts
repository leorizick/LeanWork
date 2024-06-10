import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadVacancyComponent } from './cad-vacancy.component';

describe('CadVacancyComponent', () => {
  let component: CadVacancyComponent;
  let fixture: ComponentFixture<CadVacancyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CadVacancyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadVacancyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
