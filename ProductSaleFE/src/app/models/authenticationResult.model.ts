import { GeneralResponse } from './generalReponse.model';
import { TokenInfo } from './tokenInfo.model';

export interface AuthenticationResult extends GeneralResponse {
  data: TokenInfo;
}
