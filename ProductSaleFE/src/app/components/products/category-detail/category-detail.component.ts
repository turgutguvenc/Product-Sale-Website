import { Component, Input, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/models/category.model';
import { Product } from 'src/app/models/product.model';
import { CartService } from 'src/app/services/cart.service';
import { CategoryService } from 'src/app/services/category.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.css'],
})
export class CategoryDetailComponent implements OnInit {
  category: Category | undefined;
  productByCategory: Product[] = [];

  @Input() product: Product | undefined;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private snackBar: MatSnackBar,
    private cartService: CartService
  ) {}

  ngOnInit(): void {}
  addCart(product: Product) {
    this.cartService.addToCart(product);
    this.snackBar.open(product?.productName + ' is added to Cart', 'Cart', {
      duration: 2000,
    });
  }
}
