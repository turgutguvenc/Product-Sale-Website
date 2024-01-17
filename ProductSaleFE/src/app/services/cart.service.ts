import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { CartItems } from '../models/cartItems.data';
import { CartItem } from '../models/cartItem.model';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor() {}

  addToCart(productToCart: Product) {
    let item = CartItems.find(
      (item) => item.product.categoryId === productToCart.productId
    );
    if (item) {
      item.quantity += 1;
    } else {
      let cartItem: CartItem = {
        product: productToCart,
        quantity: 1,
      };
      CartItems.push(cartItem);
    }
  }

  listCartItems(): CartItem[] {
    return CartItems;
  }

  removeFromCartItems(cartItem: CartItem) {
    let item = CartItems.find(
      (i) => i.product.categoryId === cartItem.product.productId
    );
    if (item) {
      CartItems.splice(CartItems.indexOf(item), 1);
    }
  }
}
