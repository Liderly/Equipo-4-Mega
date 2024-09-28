import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechniciansPageComponent } from './technicians-page.component';

describe('TechniciansPageComponent', () => {
  let component: TechniciansPageComponent;
  let fixture: ComponentFixture<TechniciansPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TechniciansPageComponent]
    });
    fixture = TestBed.createComponent(TechniciansPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
