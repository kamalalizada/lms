import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { UserComponent } from './components/user/user'; 
import { AppRoutingModule } from "./app-routing.module";
import { CommonModule } from '@angular/common';
import { MyCourses } from './components/student/my-courses/my-courses';
import { RouterModule } from '@angular/router';
import { AssignmentListComponent } from './components/catalog/assignment-list/assignment-list';
import { CourseDetails } from './components/catalog/course-details/course-details';
import { CatalogCourseList } from './components/catalog/course-list/course-list';
import { Catalog } from './components/catalog/catalog';
import { AdminDashboard } from './components/dashboards/admin-dashboard/admin-dashboard';
import { InstructorDashboard } from './components/dashboards/instructor-dashboard/instructor-dashboard';
import { StudentDashboard } from './components/dashboards/student-dashboard/student-dashboard';
import { HomeComponent } from './components/home/home';
import { CourseCreate } from './components/instructor/course-create/course-create';
import { CourseList } from './components/instructor/course-list/course-list';
import { LessonCreate } from './components/instructor/lesson-create/lesson-create';
import { ModuleCreate } from './components/instructor/module-create/module-create';
import { Instructor } from './components/instructor/instructor';
import { Login } from './components/login/login';
import { Register } from './components/register/register';
import { LessonView } from './components/student/lesson-view/lesson-view';
import { AssignmentService } from './services/assignment';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    MyCourses,
    AssignmentListComponent,
    CourseDetails,
    CatalogCourseList,
    Catalog,
    AdminDashboard,
    InstructorDashboard,
    StudentDashboard,
    HomeComponent,
    CourseCreate,
    CourseList,
    LessonCreate,
    ModuleCreate,
    Instructor,
    Login,
    Register,
    LessonView,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule,
  ],
  providers: [
    AssignmentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
