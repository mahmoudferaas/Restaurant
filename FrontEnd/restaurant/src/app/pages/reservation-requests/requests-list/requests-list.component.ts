import { Component, OnInit } from '@angular/core';
import { ReservationService } from 'src/app/core/services/reservation.service';
import {ReservationManager} from '../../../core/managers/reservation.manager';

@Component({
  selector: 'app-requests-list',
  templateUrl: './requests-list.component.html',
  styleUrls: ['./requests-list.component.scss']
})
export class RequestsListComponent implements OnInit {
  displayedColumns = ['numberOfGuests', 'reservationDate', 'specialRequest', 'actions'];
 reservations : any [];

  constructor(public reservationService: ReservationService) {
  }
  ngOnInit(): void {
   this.reservationService.list().subscribe((data : any) => {
     debugger
      this.reservations = data;
    });
  }
}
