import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CartItem } from 'src/app/models/cartItem.model';
import { Category } from 'src/app/models/category.model';
import { CartService } from 'src/app/services/cart.service';
import { CategoryService } from 'src/app/services/category.service';
const SMALL_WIDTH_BREAKPOINT = 720;
@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html',
  styleUrls: ['./cart-detail.component.css'],
})
export class CartDetailComponent implements OnInit {
  isScreenSmall: boolean = false;
  dataSource: CartItem[] = [];
  displayedColumns: string[] = ['name', 'quantity', 'price', 'remove'];
  categories: Category[] = [];

  constructor(
    private cartService: CartService,
    private breakPointObserver: BreakpointObserver,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.breakPointObserver
      .observe([`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`])
      .subscribe((state: BreakpointState) => {
        this.isScreenSmall = state.matches;
      });
    this.getCartItems();
    this.getAllCategories();
  }

  getCartItems() {
    this.cartService.cartItems$.subscribe((res) => {
      this.dataSource = res;
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
  removeFromCart(element: CartItem) {
    this.cartService.removeFromCartItems(element);
  }
}
