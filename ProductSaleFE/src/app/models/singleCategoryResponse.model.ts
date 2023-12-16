import { Category } from './category.moldel';
import { GeneralResponse } from './generalReponse.model';

export interface SingleCategoryResponse extends GeneralResponse {
  data: Category;
}
