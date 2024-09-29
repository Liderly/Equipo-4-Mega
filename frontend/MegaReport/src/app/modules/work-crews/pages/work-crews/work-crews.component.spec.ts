import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkCrewsComponent } from './work-crews.component';

describe('WorkCrewsComponent', () => {
  let component: WorkCrewsComponent;
  let fixture: ComponentFixture<WorkCrewsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WorkCrewsComponent]
    });
    fixture = TestBed.createComponent(WorkCrewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
