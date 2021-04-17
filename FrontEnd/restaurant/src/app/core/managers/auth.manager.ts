import {Injectable, OnDestroy} from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class AuthManager implements OnDestroy {


    constructor() {
    }

    get user() {
        return {fullName: 'user', email: 'user@demo.com'};
    }

    logout() {
        localStorage.removeItem('token');
        location.reload();
    }

    ngOnDestroy() {
    }
}
