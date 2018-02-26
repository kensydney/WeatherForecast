import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule  } from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from '../app/components/app/app.component';
import { WeatherComponent } from '../app/components/weather/weather.component';

import { ApiService, CountryService, CityService, WeatherService } from './services'
import { routes } from './app.route';
import { MatAutocompleteModule, MatInputModule, MatSelectModule, MatListModule } from '@angular/material'



@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent
  ],
  imports: [
    BrowserModule,
    MatInputModule,
    MatAutocompleteModule,
    MatSelectModule,
    MatListModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
               ApiService,
               CountryService,
               CityService,
               WeatherService
             ],
  bootstrap: [AppComponent]
})
export class AppModule { }
