import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
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
    private router: Router
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
      unitInStock: ['', Validators.required],
      categoryId: ['', Validators.required],
    });
  }

  addProduct() {
    console.log(this.productAddForm?.value);
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
