import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioMaterials } from './formulario-materials';

describe('FormularioMaterials', () => {
  let component: FormularioMaterials;
  let fixture: ComponentFixture<FormularioMaterials>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioMaterials]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioMaterials);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
