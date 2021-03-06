import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  apiUrl = environment.apiUrl+'Items/';
  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get<any>(this.apiUrl + 'GetAllItems');
}
}
