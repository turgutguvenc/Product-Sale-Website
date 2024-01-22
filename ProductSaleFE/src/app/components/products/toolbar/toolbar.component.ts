import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],
})
export class ToolbarComponent implements OnInit {
  @Output() toggleSidenav = new EventEmitter();
  @Output() toggleTheme = new EventEmitter();
  @Output() searchItem = new EventEmitter<string>();
  filterText: string = '';
  numberOfItems: Observable<number> | undefined;

  constructor(private matDialog: MatDialog, private cartService: CartService) {}

  ngOnInit(): void {
    this.getTotalitems();
  }

  sendSearchText() {
    this.searchItem.emit(this.filterText);
  }
  getTotalitems() {
    this.numberOfItems = this.cartService.totalItems$;
  }
}
