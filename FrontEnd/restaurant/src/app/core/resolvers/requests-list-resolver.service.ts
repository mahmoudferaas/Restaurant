import {Injectable} from '@angular/core';
import {Resolve} from '@angular/router';
import {ReservationManager} from '../managers/reservation.manager';

@Injectable({
    providedIn: 'root'
})

export class RequestsListResolver implements Resolve<any> {
    constructor(private reservationManager: ReservationManager) {
    }

    resolve() {
        return this.reservationManager.list(1);
    }
}
