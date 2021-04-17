import {Injectable} from '@angular/core';
import {
    HttpInterceptor,
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpErrorResponse,
    HttpResponse
} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, finalize, tap} from 'rxjs/operators';
import {AuthService} from '../services/auth.service';

@Injectable({
    providedIn: 'root'
})

export class ApiInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) {
    }

    intercept(
        req: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        const token = localStorage.getItem('token');

        const clonedReq = req.clone({
            setHeaders: {
                Authorization: 'Bearer ' + token
            }
        });

        return next.handle(clonedReq).pipe(
            tap(evt => {
                if (evt instanceof HttpResponse) {
                    return evt.body;
                }
            }), catchError((error: HttpErrorResponse) => {
                return throwError(error);
            }),
            finalize(() => {
            })
        );
    }
}
