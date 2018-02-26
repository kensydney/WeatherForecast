import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, FormBuilder} from '@angular/forms';
import { CountryService, CityService, WeatherService } from '../../services';
import { Country, City, Forecast } from '../../model';
import {map} from 'rxjs/operators/map';
import { debounceTime } from 'rxjs/operators/debounceTime'

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css'],
  providers: [ CountryService ]
})
export class WeatherComponent implements OnInit {
  countryCtrl: FormControl;
  cityCtrl: FormControl;
  countries: Country[];
  cities: City[];
  weatherForm: FormGroup;
  forecast: Forecast;
  weatherTitle: string;
  forecastKey: string[];

  constructor (
    private countryService: CountryService,
    private cityService: CityService,
    private weatherService: WeatherService,
    private fb: FormBuilder
  ) {
     this.countries = [];
     this.countryCtrl = new FormControl();
     this.countryService.getCountries('')
          .subscribe(res => {
            this.countries = res ;
          });

      this.cities = [];
      this.cityCtrl = new FormControl();
  }

  ngOnInit() {
    this.weatherForm = this.fb.group({
      countryCtrl: '',
      cityCtrl: ''
    }
    );

    this.onChanges();
  }

  onChanges() {
    const self = this;
    this.weatherForm.get('countryCtrl').valueChanges.subscribe(val => {
      this.cityService.getCities(val)
        .subscribe(res => {
           if (res == null) {
             self.cities = [];
           } else
           if (!(res instanceof Array)) {
             self.cities = [res];
           } else {
             self.cities = res;
           }
           self.forecast = null;
           self.forecastKey = [];
           self.weatherTitle = '';
           self.weatherForm.patchValue({cityCtrl: ''});
        })
    });
  }

  onSubmit() {
    this.weatherForm.updateValueAndValidity();
    if (this.weatherForm.invalid) {return; }

    this.forecast = null;
    this.forecastKey = [];
    const country = this.weatherForm.value.countryCtrl;
    const city = this.weatherForm.value.cityCtrl;

    this.weatherService.getForecast(country, city)
      .subscribe(res => {
        this.forecast = res;
        this.weatherTitle = country === '' || city === '' ?
          'Country or city need to be filled!' : 'Weather Details for ' + city + ' in ' + country;
        this.forecastKey = Object.keys(this.forecast);
          })
  }
}
