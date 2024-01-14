import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/models/category.model';
import { Product } from 'src/app/models/product.model';
import { CategoryService } from 'src/app/services/category.service';
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
  categories: Category[] = [];
  activateRouteId: string | undefined;

  constructor(
    private breakPointObserver: BreakpointObserver,
    private productService: ProductService,
    private categoryService: CategoryService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.breakPointObserver
      .observe([`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`])
      .subscribe((state: BreakpointState) => {
        this.isScreenSmall = state.matches;
      });
    this.route.params.subscribe((res) => {
      this.activateRouteId = res['id'];
      if (this.activateRouteId) {
        this.getAllProductById(Number(this.activateRouteId));
      } else {
        this.getAllProducts();
      }
    });
    this.getAllCategories();
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

  getAllProductById(id: number) {
    this.productService.getProductsByCategoryId(id).subscribe((response) => {
      if (response.success) {
        this.products = response.data;
      } else {
        console.log(response.message);
      }
    });
  }
  getAllCategories() {
    this.categoryService.getCategories().subscribe((response) => {
      if (response.success) {
        this.categories = response.data;
        console.log('----------------Category----------------');
        console.log(this.categories);
      }
    });
  }
}
