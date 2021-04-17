import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})

export class ReservationService {
    apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    list(queryParams) {
        return this.http.get(this.apiUrl + 'requests/list' + queryParams);
    }

    get(requestId) {
        return this.http.get(this.apiUrl + 'requests/details?id=' + requestId);
    }

}
