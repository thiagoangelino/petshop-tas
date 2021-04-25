/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AccommodationsService } from './accommodations.service';

describe('Service: Accommodations', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccommodationsService]
    });
  });

  it('should ...', inject([AccommodationsService], (service: AccommodationsService) => {
    expect(service).toBeTruthy();
  }));
});
