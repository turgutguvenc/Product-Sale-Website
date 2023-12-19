import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';
import { ListResponse } from '../models/listResponse.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl: string = 'https://localhost:7003/api';
  constructor(private httpClient: HttpClient) {}

  getProducts(): Observable<ListResponse<Product>> {
    return this.httpClient.get<ListResponse<Product>>(
      this.baseUrl + '/products'
    );
  }

  getProductsByCategoryId(id: number): Observable<ListResponse<Product>> {
    return this.httpClient.get<ListResponse<Product>>(
      this.baseUrl + '/products/category/' + id
    );
  }
}
