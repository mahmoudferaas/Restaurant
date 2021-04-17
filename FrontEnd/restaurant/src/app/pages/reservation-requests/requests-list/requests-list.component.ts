import { Component, OnInit } from '@angular/core';
import {ReservationManager} from '../../../core/managers/reservation.manager';

@Component({
  selector: 'app-requests-list',
  templateUrl: './requests-list.component.html',
  styleUrls: ['./requests-list.component.scss']
})
export class RequestsListComponent implements OnInit {
  displayedColumns = ['name', 'phone', 'date', 'actions'];

  constructor(public reservationManager: ReservationManager) {
  }
  ngOnInit(): void {
  }
}
