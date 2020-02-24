import { Component, OnInit } from '@angular/core';
import { ProductService } from "../services/product.service";
import { Product } from "../model/product";

@Component({
  selector: 'app-product',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})

export class ProductsComponent implements OnInit {
  products: Product[];
  selectedProduct: Product;
  createProductForm;
  displayedColumns: string[] = ['name', 'description', 'price'];

  constructor(private productService: ProductService) {
    //
  }

  ngOnInit() {
    this.getProducts();
  }

  getProducts(): void {
    this.productService.getProducts()
      .subscribe(products => this.products = products);
  }

  onSelect(product: Product): void {
    this.selectedProduct = product;
  }
}
