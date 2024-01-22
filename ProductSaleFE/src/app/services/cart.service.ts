import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { CartItems } from '../models/cartItems.data';
import { CartItem } from '../models/cartItem.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  initialItemNumber: number = 0;
  totalItems: BehaviorSubject<number> = new BehaviorSubject<number>(
    this.initialItemNumber
  );
  totalItems$ = this.totalItems.asObservable();

  private cartItems: BehaviorSubject<CartItem[]> = new BehaviorSubject<
    CartItem[]
  >([]);
  cartItems$: Observable<CartItem[]> = this.cartItems.asObservable();

  constructor() {}

  addToCart(productToCart: Product) {
    let item = this.cartItems.value.find(
      (item) => item.product.productId === productToCart.productId
    );
    if (item) {
      item.quantity += 1;
    } else {
      let cartItem: CartItem = {
        product: productToCart,
        quantity: 1,
      };
      const currentItems = this.cartItems.value;
      const updatedItems = [...currentItems, cartItem];
      this.cartItems.next(updatedItems);
      this.initialItemNumber += 1;
      this.totalItems.next(this.initialItemNumber);
    }
  }

  removeFromCartItems(cartItem: CartItem) {
    let item = this.cartItems.value.find(
      (i) => i.product.productId === cartItem.product.productId
    );
    if (item) {
      this.initialItemNumber -= 1;
      this.totalItems.next(this.initialItemNumber);
      const currentItems = this.cartItems.value;
      const updatedItems = currentItems.filter(
        (existingItem) => existingItem !== item
      );
      this.cartItems.next(updatedItems);
    }
  }
}
