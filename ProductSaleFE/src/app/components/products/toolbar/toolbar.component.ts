import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

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
  numberOfItems: number = 2;

  constructor(private matDialog: MatDialog) {}

  ngOnInit(): void {}
  sendSearchText() {
    this.searchItem.emit(this.filterText);
  }
}
