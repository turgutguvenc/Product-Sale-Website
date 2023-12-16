import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';

const routes: Routes = [
  {
    path: '',
    component: ProductComponent,
    children: [{ path: ':id', component: CategoryDetailComponent }],
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductRoutingModule {}
