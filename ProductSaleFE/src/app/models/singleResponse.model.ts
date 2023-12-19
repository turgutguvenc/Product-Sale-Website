import { Category } from './category.model';
import { GeneralResponse } from './generalReponse.model';

export interface SingleResponse<T> extends GeneralResponse {
  data: T;
}
