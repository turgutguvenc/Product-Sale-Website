import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductRoutingModule } from './product-routing.module';
import { MaterialModule } from 'src/app/shared/material.module';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';
import { VatAddedPipe } from 'src/app/pipes/vat-added.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FilterPipe } from 'src/app/pipes/filter.pipe';
import { CartDetailComponent } from './cart-detail/cart-detail.component';

@NgModule({
  declarations: [
    ProductComponent,
    ToolbarComponent,
    CategoryDetailComponent,
    VatAddedPipe,
    FilterPipe,
    CartDetailComponent,
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [ProductComponent],
})
export class ProductModule {}
