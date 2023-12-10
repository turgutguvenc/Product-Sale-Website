import { Component } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {
  products:any[] = [{
    id:1,
    name:'Iphone 12',
    status:true,
    numberOfProduct:10,
    description:'Điện thoại Iphone 12',
    unitPrice:1000000,
  },
  {
    id:2,
    name:'Iphone 14',
    status:true,
    numberOfProduct:100,
    description:'Điện thoại Iphone 14',
    unitPrice:1000000,
  },
  {
    id:3,
    name:'Iphone 15',
    status:true,
    numberOfProduct:189,
    description:'Điện thoại Iphone 15',
    unitPrice:1000000,
  },
]
}
