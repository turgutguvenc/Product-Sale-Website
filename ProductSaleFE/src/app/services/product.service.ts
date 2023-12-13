import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductResponse } from '../models/productResponse.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl: string = 'https://localhost:7003/api';

  constructor(private httpClient: HttpClient) {}

  getProducts(): Observable<ProductResponse> {
    return this.httpClient.get<ProductResponse>(this.baseUrl + '/products');
  }
}
