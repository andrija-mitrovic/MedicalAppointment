/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BloodGroupService } from './bloodGroup.service';

describe('Service: BloodGroup', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BloodGroupService]
    });
  });

  it('should ...', inject([BloodGroupService], (service: BloodGroupService) => {
    expect(service).toBeTruthy();
  }));
});
