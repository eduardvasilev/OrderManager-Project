import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ProductService } from "../product.service";
import { Product } from "../product";
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})

export class CreateProductComponent implements OnInit {
  products: Product[];
  product: Product;
  createProductForm;

  constructor(private formBuilder: FormBuilder,
    private productService: ProductService,
    private router: Router) {

    this.createProductForm = this.formBuilder.group({
      name: new FormControl(this.product, [
        Validators.required,
        Validators.maxLength(255)
      ]),
      description: new FormControl(this.product, [
        Validators.maxLength(500)
      ]),
      price: new FormControl(this.product, [
        Validators.required,
        Validators.min(0)
      ]),
    });
  }

  ngOnInit() {
    //
  }

  onSubmit(productData: Product) {
    if(this.createProductForm.valid){
      this.productService.createProduct(productData)
      .subscribe(() => {
        this.router.navigate(['/products']);
      });
    }
  }
}
