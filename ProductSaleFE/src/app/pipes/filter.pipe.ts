import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../models/product.model';

@Pipe({
  name: 'filter',
})
export class FilterPipe implements PipeTransform {
  // Value represent the data we want to change, here we will filter Product[] according to filter text.
  transform(value: Product[], filterText: string): Product[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : '';
    return filterText
      ? value.filter(
          (p: Product) =>
            p.productName.toLocaleLowerCase().indexOf(filterText) !== -1
        )
      : value;
  }
}
