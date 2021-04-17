import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, Resolve} from '@angular/router';
import {ReservationManager} from '../managers/reservation.manager';

@Injectable({
    providedIn: 'root'
})

export class RequestDetailsResolver implements Resolve<any> {
    constructor(private reservationManager: ReservationManager) {
    }

    resolve(route: ActivatedRouteSnapshot) {
        return this.reservationManager.getDetails(route.paramMap.get('id'));
    }
}
