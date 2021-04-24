/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AccommodationService } from './accommodation.service';

describe('Service: Accommodation', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccommodationService]
    });
  });

  it('should ...', inject([AccommodationService], (service: AccommodationService) => {
    expect(service).toBeTruthy();
  }));
});
