import { TestBed } from '@angular/core/testing';

import { MovimientosapiService } from './movimientosapi.service';

describe('MovimientosapiService', () => {
  let service: MovimientosapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MovimientosapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
