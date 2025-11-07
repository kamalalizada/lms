import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { CatalogRoutingModule } from './catalog-routing-module';
import { Catalog } from './catalog';

@NgModule({
  declarations: [
    Catalog 
  ],
  imports: [
    CommonModule,
    FormsModule, 
    CatalogRoutingModule
  ]
})
export class CatalogModule { }
