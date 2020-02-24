import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from "../model/order";


@Injectable({ providedIn: 'root' })
export class OrderService {

  private orderUrl = 'order';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    //
  }

  getProducts(): Observable<Order[]> {
    return this.http.get<Order[]>(this.orderUrl);
  }
}
