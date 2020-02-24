import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from "../model/order";
import { OrderItem } from "../model/orderItem";


@Injectable({ providedIn: 'root' })
export class OrderService {

  private orderUrl = 'order';
  private orderItemsUrl = 'order/items';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    //
  }

  getProducts(): Observable<Order[]> {
    return this.http.get<Order[]>(this.orderUrl);
  }

  getItems(orderId: number): Observable<OrderItem[]> {
    let params: HttpParams = new HttpParams().set("orderId", orderId.toString()); 
    return this.http.get<OrderItem[]>(this.orderItemsUrl, { params: params});
  }
}
