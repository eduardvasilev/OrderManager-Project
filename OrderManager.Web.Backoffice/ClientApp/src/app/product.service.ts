import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from './product';



@Injectable({ providedIn: 'root' })
export class ProductService {

  private productUrl = 'product';
  private createUrl = 'product/Create';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    //
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl);
  }

  createProduct(product: Product): any {
    return this.http.post(this.createUrl, product, this.httpOptions); 
  }
}
