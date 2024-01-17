import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
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
  numberOfItems: number | undefined;

  constructor(private matDialog: MatDialog, private cartService: CartService) {}

  ngOnInit(): void {}

  sendSearchText() {
    this.searchItem.emit(this.filterText);
  }
  getNumberOfCartElements() {
    this.numberOfItems = this.cartService.listCartItems().length;
  }
}
