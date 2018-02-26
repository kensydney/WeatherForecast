import { Routes, RouterModule } from '@angular/router';
import { WeatherComponent } from './components/weather/weather.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/weather',
    pathMatch: 'full'
  },
  {
    path: 'weather',
    component: WeatherComponent
  }
];
