import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserLogin } from 'src/app/models/userLogin.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup | undefined;
  isUserAthenticated!: Observable<boolean>;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
    this.isUserAthenticated = this.userService.isAuthenticated$;
  }

  login() {
    const user: UserLogin = this.loginForm?.value;
    if (user) {
      this.userService.userLogin(user).subscribe(
        (res) => {
          console.log('Login Response' + res.data.token);
          this.snackBar.open(res.message, 'Register', {
            duration: 3000,
          });
          localStorage.setItem('token', res.data.token);
          this.userService.setIsAuthenticated(true);
          this.router.navigate(['/products/cart-detail']);
        },
        (error) => {
          console.log(error);
          this.snackBar.open(error.error.message, 'Register', {
            duration: 3000,
          });
        }
      );
    }
  }

  cancelLogin() {
    this.router.navigate(['/products']);
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  logout() {
    this.userService.userLogout();
  }
}
