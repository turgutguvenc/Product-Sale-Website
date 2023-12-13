import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

const SMALL_WIDTH_BREAKPOINT = 720;

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  isScreenSmall: boolean = false;
  products: Product[] = [];

  constructor(
    private breakPointObserver: BreakpointObserver,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.breakPointObserver
      .observe([`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`])
      .subscribe((state: BreakpointState) => {
        this.isScreenSmall = state.matches;
      });
    this.getAllProducts();
  }

  getAllProducts() {
    this.productService.getProducts().subscribe((response) => {
      if (response.success) {
        this.products = response.data;
        console.log(this.products);
      } else {
        console.log(response.message);
      }
    });
  }
}
