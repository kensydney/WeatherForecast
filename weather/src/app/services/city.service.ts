import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { City } from '../model';
import { ApiService } from './api.service';

@Injectable()
export class CityService {

  constructor(private apiService: ApiService) {
  }

  getCities(data): Observable<City[]> {
    return this.apiService
    .get(
      '/City?country=' + data,
      null
    );
  }
}
