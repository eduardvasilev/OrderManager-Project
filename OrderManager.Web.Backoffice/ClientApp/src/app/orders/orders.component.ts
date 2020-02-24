import { Component, OnInit } from '@angular/core';
import { OrderService } from "../services/order.service";
import { Order } from "../model/order";
import { animate, state, style, transition, trigger } from '@angular/animations';
@Component({
  selector: 'app-product',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)'))
    ])
  ],
})

export class OrdersComponent implements OnInit {
  orders: Order[];
  selectedOrder: Order;
  expandedElement: Order | null;
  columnsToDisplay: string[] = ['creationDate', 'statusId'];

  constructor(private orderService: OrderService) {
    //
  }

  ngOnInit() {
    this.getOrders();
  }

  getOrders(): void {
    this.orderService.getProducts()
      .subscribe(orders => this.orders = orders);
  }
}
