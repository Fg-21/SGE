import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Listilla } from './listilla';

describe('Listilla', () => {
  let component: Listilla;
  let fixture: ComponentFixture<Listilla>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Listilla]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Listilla);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
