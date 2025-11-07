import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { InstructorRoutingModule } from './instructor-routing-module';

import { Instructor } from './instructor';
import { ModuleCreate } from './module-create/module-create'; 

@NgModule({
  declarations: [
    Instructor,
     
  ],
  imports: [
    CommonModule,
    FormsModule, 
    InstructorRoutingModule,
    ModuleCreate
  ]
})
export class InstructorModule { }
