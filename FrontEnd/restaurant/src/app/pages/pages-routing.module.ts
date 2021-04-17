import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateReservationComponent } from './create-reservation/create-reservation.component';
import { HomeComponent } from './home/home.component';
import { LayoutComponent } from './_layout/layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'home',
        component: HomeComponent,
      },
      {
        path: 'create-reservation',
        component: CreateReservationComponent,
      },
      {
        path: 'reservation-requests',
        loadChildren: () =>
          import('./reservation-requests/reservation-requests.module').then((m) => m.ReservationRequestsModule),
      },
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
      },
      {
        path: '**',
        redirectTo: 'errors/404',
        pathMatch: 'full',
      }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule { }
