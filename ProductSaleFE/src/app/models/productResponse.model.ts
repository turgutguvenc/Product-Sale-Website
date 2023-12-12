import { Product } from './product.model';

export interface ProductResponse {
  data: Product[];
  success: boolean;
  message: string;
}
