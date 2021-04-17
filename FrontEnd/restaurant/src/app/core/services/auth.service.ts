import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from "../../../environments/environment";

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    login(userData) {
        return this.http.post(this.apiUrl + 'login', userData);
    }
}
