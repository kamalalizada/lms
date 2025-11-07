import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Catalog } from './catalog';
import { CourseList } from './course-list/course-list';
import { CourseDetails } from './course-details/course-details';

const routes: Routes = [{ path: '', component: CourseList },
                        {path:':id', component: CourseDetails},
                        {path:'',component:Catalog}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogRoutingModule { }
