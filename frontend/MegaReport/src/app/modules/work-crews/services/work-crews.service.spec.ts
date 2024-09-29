import { TestBed } from '@angular/core/testing';

import { WorkCrewsService } from './work-crews.service';

describe('WorkCrewsService', () => {
  let service: WorkCrewsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkCrewsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
