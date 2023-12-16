import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryResponse } from '../models/categoryResponse.model';
import { SingleCategoryResponse } from '../models/singleCategoryResponse.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  baseUrl: string = 'https://localhost:7003/api/categories';

  constructor(private httpClient: HttpClient) {}

  getCategories(): Observable<CategoryResponse> {
    return this.httpClient.get<CategoryResponse>(
      this.baseUrl + '/getallcatories'
    );
  }
  getCategoryById(id: number): Observable<SingleCategoryResponse> {
    return this.httpClient.get<SingleCategoryResponse>(this.baseUrl + '/' + id);
  }
}
