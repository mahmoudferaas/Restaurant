import {Injectable} from '@angular/core';
import {ReservationService} from '../services/reservation.service';
import {PaginatedResponseModel} from '../models/paginated-response.model';
import {RequestModel} from '../models/request.model';
import {PageEvent} from '@angular/material/paginator';
import {MatDialog} from '@angular/material/dialog';

@Injectable({
    providedIn: 'root'
})

export class ReservationManager {
    public loading = false;
    apiResponse: PaginatedResponseModel;
    public requestsList: RequestModel[];
    requestDetails: RequestModel;
    total = 0;
    pageSize = 10;

    constructor(private reservationService: ReservationService, private dialog: MatDialog) {
    }

    list(currentPage = 1, perPage = this.pageSize) {
        this.loading = true;
        const queryParams = 'pagenumber=' + currentPage + '&pagesize=' + perPage;
        this.reservationService.list(queryParams).subscribe((response: PaginatedResponseModel) => {
            this.apiResponse = response;
            this.requestsList = this.apiResponse.data;
            this.total = this.apiResponse.totalCount;
            this.loading = false;
        }, error => {
            this.loading = false;
        });
    }

    pageChange(event: PageEvent) {
        this.list(event.pageIndex + 1, event.pageSize);
    }

    getDetails(requestId) {
        this.requestDetails = null;
        this.reservationService.get(requestId).subscribe((response: RequestModel) => {
            this.requestDetails = response;
        });
    }
}
