import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Instructor } from './instructor';
import { CourseList } from './course-list/course-list';
import { CourseCreate } from './course-create/course-create';
import { ModuleCreate } from './module-create/module-create';
import { LessonCreate } from './lesson-create/lesson-create';

const routes: Routes = [{ path: '', component: Instructor },
  {path:'',component:CourseList},
  {path:'create',component:CourseCreate},
  {path:':courseId/module/create',component:ModuleCreate},
  {path:':courseId/module/:moduleId/lesson/create',component:LessonCreate}
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InstructorRoutingModule { }
