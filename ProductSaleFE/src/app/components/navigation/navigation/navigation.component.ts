import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
})
export class NavigationComponent implements OnInit {
  isUserAthenticated!: Observable<boolean>;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.isUserAthenticated = this.userService.isAuthenticated$;
  }
  logout() {
    this.userService.userLogout();
  }
}
