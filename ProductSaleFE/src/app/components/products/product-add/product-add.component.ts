import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category.model';
import { CreateProduct } from 'src/app/models/createProduct.model';
import { CategoryService } from 'src/app/services/category.service';
import { ProductService } from 'src/app/services/product.service';
const SMALL_WIDTH_BREAKPOINT = 720;
@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css'],
})
export class ProductAddComponent implements OnInit {
  isScreenSmall: boolean = false;
  productAddForm: FormGroup | undefined;
  categories: Category[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private breakPointObserver: BreakpointObserver,
    private categoryService: CategoryService,
    private router: Router,
    private productService: ProductService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.breakPointObserver
      .observe([`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`])
      .subscribe((state: BreakpointState) => {
        this.isScreenSmall = state.matches;
      });
    this.createProductAddForm();
    this.getAllCategories();
  }

  createProductAddForm() {
    this.productAddForm = this.formBuilder.group({
      productName: ['', Validators.required],
      unitPrice: ['', Validators.required],
      unitsInStock: ['', Validators.required],
      categoryId: ['', Validators.required],
    });
  }

  addProduct() {
    let productCreate: CreateProduct = Object.assign(
      {},
      this.productAddForm?.value
    );
    console.log(productCreate);
    this.productService.addProduct(productCreate).subscribe(
      (res) => {
        if (res) {
          console.log(res);
          this.snackBar.open(res.message, 'Products', {
            duration: 3000,
          });
          this.router.navigate(['/products']);
        }
      },
      (err) => {
        console.log(err);
        let message = '';
        if (err.status === 401 || err.status === 403) {
          message = 'You are unauthorized';
        } else if (err.status === 400) {
          message = 'Bad Request';
        } else if (err.status === 404) {
          message = 'Not Found';
        } else {
          message = err.error.message;
        }
        this.snackBar.open(message, 'Error', {
          duration: 3000,
        });
      }
    );
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
  cancelProduct() {
    this.router.navigate(['/products']);
  }
}
