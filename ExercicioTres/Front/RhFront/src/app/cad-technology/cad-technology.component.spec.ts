import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadTechnologyComponent } from './cad-technology.component';

describe('CadTechnologyComponent', () => {
  let component: CadTechnologyComponent;
  let fixture: ComponentFixture<CadTechnologyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CadTechnologyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadTechnologyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
