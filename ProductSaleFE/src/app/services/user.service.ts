import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserRegister } from '../models/userRegister.model';
import { UserLogin } from '../models/userLogin.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthenticationResult } from '../models/authenticationResult.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl: string = 'https://localhost:7003/api/auth';
  private isAuthenticated: BehaviorSubject<boolean> =
    new BehaviorSubject<boolean>(false);
  public isAuthenticated$: Observable<boolean> =
    this.isAuthenticated.asObservable();

  constructor(private httpClient: HttpClient) {}

  userRegister(userRegister: UserRegister): Observable<AuthenticationResult> {
    return this.httpClient.post<AuthenticationResult>(
      this.baseUrl + '/register',
      userRegister
    );
  }

  userLogin(userLogin: UserLogin): Observable<AuthenticationResult> {
    return this.httpClient.post<AuthenticationResult>(
      this.baseUrl + '/login',
      userLogin
    );
  }

  setIsAuthenticated(value: boolean) {
    this.isAuthenticated.next(value);
  }

  userLogout() {
    this.isAuthenticated.next(false);
    localStorage.removeItem('token');
  }
}
