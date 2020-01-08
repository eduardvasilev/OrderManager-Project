import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ProductService } from "../product.service";
import { Product } from "../product";

@Component({
  selector: 'app-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})

export class CreateProductComponent implements OnInit {
  products: Product[];
  selectedProduct: Product;
  createProductForm;

  constructor(private productService: ProductService,
    private formBuilder: FormBuilder) {

    this.createProductForm = this.formBuilder.group({
      name: '',
      description: '',
      price: ''
    });
  }

  ngOnInit() {
    //
  }

  onSubmit(productData: Product) {
    this.productService.createProduct(productData)
      .subscribe(product => {
        this.products.push(product);
      });
  }
}
