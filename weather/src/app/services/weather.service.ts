import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Forecast } from '../model';
import { ApiService } from './api.service';

@Injectable()
export class WeatherService {

  constructor(private apiService: ApiService) {
  }

  getForecast(country, city): Observable<Forecast> {
    return this.apiService
    .get(
      '/Weather?country=' + country + '&city=' + city,
      null
    );
  }
}
