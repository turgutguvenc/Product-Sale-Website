import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponse } from '../models/listResponse.model';
import { Category } from '../models/category.model';
import { SingleResponse } from '../models/singleResponse.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  baseUrl: string = 'https://localhost:7003/api/categories';

  constructor(private httpClient: HttpClient) {}

  getCategories(): Observable<ListResponse<Category>> {
    return this.httpClient.get<ListResponse<Category>>(
      this.baseUrl + '/getallcatories'
    );
  }
  getCategoryById(id: number): Observable<SingleResponse<Category>> {
    return this.httpClient.get<SingleResponse<Category>>(
      this.baseUrl + '/' + id
    );
  }
}
