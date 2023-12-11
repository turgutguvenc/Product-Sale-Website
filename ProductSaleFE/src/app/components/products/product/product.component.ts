import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';

const SMALL_WIDTH_BREAKPOINT = 720;

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  isScreenSmall: boolean = false;

  constructor(private breakPointObserver:BreakpointObserver) {}

  ngOnInit(): void {
   this.breakPointObserver.observe([`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`]).subscribe((state: BreakpointState) => {
    this.isScreenSmall = state.matches;
  });
}
}
