import { Component, OnInit } from '@angular/core';
import { CartItem } from 'src/app/models/cartItem.model';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html',
  styleUrls: ['./cart-detail.component.css'],
})
export class CartDetailComponent implements OnInit {
  cartItems: CartItem[] = [];

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.getCartItems();
  }

  getCartItems() {
    this.cartItems = this.cartService.listCartItems();
    console.log(this.cartItems);
  }
}
