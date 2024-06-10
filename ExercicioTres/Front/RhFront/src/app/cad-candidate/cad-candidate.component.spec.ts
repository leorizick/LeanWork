import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadCandidateComponent } from './cad-candidate.component';

describe('CadCandidateComponent', () => {
  let component: CadCandidateComponent;
  let fixture: ComponentFixture<CadCandidateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CadCandidateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadCandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
