import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { UserRegister } from 'src/app/models/userRegister.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup | undefined;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.createRegisterForm();
  }

  register() {
    const user: UserRegister = this.registerForm?.value;
    if (user) {
      this.userService.userRegister(user).subscribe((res) => {
        console.log('Register Response' + res.data.token);
        this.snackBar.open(res.message, 'Register', {
          duration: 3000,
        });
        this.router.navigate(['login']);
      });
    }
  }

  cancelRegister() {
    this.router.navigate(['/products']);
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      email: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
}
