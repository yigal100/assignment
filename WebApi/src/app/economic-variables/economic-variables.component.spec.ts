import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EconomicVariablesComponent } from './economic-variables.component';

describe('EconomicVariablesComponent', () => {
  let component: EconomicVariablesComponent;
  let fixture: ComponentFixture<EconomicVariablesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EconomicVariablesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EconomicVariablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
