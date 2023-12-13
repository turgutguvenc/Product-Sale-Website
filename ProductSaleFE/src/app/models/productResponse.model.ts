import { GeneralResponse } from './generalReponse.model';
import { Product } from './product.model';

export interface ProductResponse extends GeneralResponse {
  data: Product[];
}
