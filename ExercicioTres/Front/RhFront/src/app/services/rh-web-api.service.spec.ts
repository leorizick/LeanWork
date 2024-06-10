import { TestBed } from '@angular/core/testing';

import { RhWebApiService } from './rh-web-api.service';

describe('RhWebApiService', () => {
  let service: RhWebApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RhWebApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
