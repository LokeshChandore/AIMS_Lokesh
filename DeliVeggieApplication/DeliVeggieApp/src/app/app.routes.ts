import { Routes } from '@angular/router';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductComponent } from './product/product.component';

export const routes: Routes = [
   { path: '', component: ProductComponent },
   { path: '', children:[
    {path: "product/:id", component: ProductDetailComponent}
   ] },
];
