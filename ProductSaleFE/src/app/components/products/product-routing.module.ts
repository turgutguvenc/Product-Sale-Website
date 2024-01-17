import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';
import { CartDetailComponent } from './cart-detail/cart-detail.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: ProductComponent,
  },
  {
    path: 'products',
    component: ProductComponent,
  },
  {
    path: 'products/cart-detail',
    component: CartDetailComponent,
  },
  {
    path: 'products/category/:id',
    component: ProductComponent,
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductRoutingModule {}
