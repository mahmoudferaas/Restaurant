import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationRequestsComponent } from './reservation-requests.component';
import {RouterModule} from '@angular/router';
import {RequestsListResolver} from '../../core/resolvers/requests-list-resolver.service';
import {RequestDetailsResolver} from '../../core/resolvers/request-details-resolver.service';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatButtonModule} from '@angular/material/button';
import {MatSortModule} from '@angular/material/sort';
import {InlineSVGModule} from 'ng-inline-svg';
import { RequestsListComponent } from './requests-list/requests-list.component';
import { RequestDetailsComponent } from './request-details/request-details.component';



@NgModule({
  declarations: [ReservationRequestsComponent, RequestsListComponent, RequestDetailsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: ReservationRequestsComponent,
        children: [
          {
            path: '',
            component: RequestsListComponent,
            resolve: {requests: RequestsListResolver},
          },
          {
            path: ':id',
            component: RequestDetailsComponent,
            resolve: {request: RequestDetailsResolver},
          }
        ]
      },
    ]),
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSortModule,
    InlineSVGModule
  ]
})
export class ReservationRequestsModule { }
