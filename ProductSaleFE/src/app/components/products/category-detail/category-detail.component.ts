import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/models/category.moldel';
import { Product } from 'src/app/models/product.model';
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

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const id = params['id'];
      this.productService.getProductsByCategoryId(id).subscribe((response) => {
        if (response.success) {
          this.productByCategory = response.data;
          console.log(this.productByCategory);
        }
      });
      // You can now use the ID in your component logic
    });
  }
}
