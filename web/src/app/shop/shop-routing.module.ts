import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

const routes: Routes = [
  {path: 'shop', component: ShopComponent},
  {path: 'shop/:id', component: ProductDetailsComponent},
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ShopRoutingModule { }
