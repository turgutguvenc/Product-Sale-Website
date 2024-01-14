import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product/product.component';
import { ProductRoutingModule } from './product-routing.module';
import { MaterialModule } from 'src/app/shared/material.module';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { CategoryDetailComponent } from './category-detail/category-detail.component';
import { VatAddedPipe } from 'src/app/pipes/vat-added.pipe';

@NgModule({
  declarations: [
    ProductComponent,
    ToolbarComponent,
    CategoryDetailComponent,
    VatAddedPipe,
  ],
  imports: [CommonModule, ProductRoutingModule, MaterialModule],
  exports: [ProductComponent],
})
export class ProductModule {}
