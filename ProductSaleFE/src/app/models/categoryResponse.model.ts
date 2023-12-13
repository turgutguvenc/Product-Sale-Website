import { Category } from './category.moldel';
import { GeneralResponse } from './generalReponse.model';

export interface CategoryResponse extends GeneralResponse {
  data: Category[];
}
