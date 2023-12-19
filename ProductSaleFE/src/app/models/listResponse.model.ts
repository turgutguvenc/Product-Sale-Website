import { GeneralResponse } from './generalReponse.model';

export interface ListResponse<T> extends GeneralResponse {
  data: T[];
}
