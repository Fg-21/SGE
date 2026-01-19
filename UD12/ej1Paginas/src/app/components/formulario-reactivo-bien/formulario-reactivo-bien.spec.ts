import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioReactivoBien } from './formulario-reactivo-bien';

describe('FormularioReactivoBien', () => {
  let component: FormularioReactivoBien;
  let fixture: ComponentFixture<FormularioReactivoBien>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioReactivoBien]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioReactivoBien);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
