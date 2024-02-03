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
import { ProductAddComponent } from './product-add/product-add.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from 'src/app/interceptors/auth.interceptor';

@NgModule({
  declarations: [
    ProductComponent,
    ToolbarComponent,
    CategoryDetailComponent,
    VatAddedPipe,
    FilterPipe,
    CartDetailComponent,
    ProductAddComponent,
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  exports: [ProductComponent],
})
export class ProductModule {}
