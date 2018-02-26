import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Country } from '../model';
import { ApiService } from './api.service';

@Injectable()
export class CountryService {

  constructor(private apiService: ApiService) {
  }

  getCountries(data): Observable<Country[]> {
    return this.apiService
    .get(
      '/Country',
      null
    );
  }
}
