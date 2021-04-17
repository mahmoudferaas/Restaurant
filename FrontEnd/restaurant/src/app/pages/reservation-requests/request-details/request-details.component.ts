import {Component, OnInit} from '@angular/core';
import {ReservationManager} from '../../../core/managers/reservation.manager';

@Component({
    selector: 'app-request-details',
    templateUrl: './request-details.component.html',
    styleUrls: ['./request-details.component.scss']
})
export class RequestDetailsComponent implements OnInit {

    constructor(public reservationManager: ReservationManager) {
    }

    ngOnInit(): void {
    }

}
