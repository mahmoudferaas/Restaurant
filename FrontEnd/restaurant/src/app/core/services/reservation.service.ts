import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})

export class ReservationService {
    apiUrl = environment.apiUrl+'Reservations/';

    constructor(private http: HttpClient) {
    }

    list() {
        return this.http.get(this.apiUrl + 'GetAllReservations' );
    }

    get(requestId) {
        return this.http.get(this.apiUrl + 'GetById?id=' + requestId);
    }

    create(data) {
        return this.http.post(this.apiUrl + 'CreateReservation' , data);
    }

}
