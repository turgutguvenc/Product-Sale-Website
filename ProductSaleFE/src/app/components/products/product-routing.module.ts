import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';
import { CartDetailComponent } from './cart-detail/cart-detail.component';
import { ProductAddComponent } from './product-add/product-add.component';
import { AuthGuard } from 'src/app/guards/auth.guard';

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
    canActivate: [AuthGuard],
  },
  {
    path: 'products/product-add',
    component: ProductAddComponent,
    canActivate: [AuthGuard],
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
