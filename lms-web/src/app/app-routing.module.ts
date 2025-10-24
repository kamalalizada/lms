import { NgModule } from "@angular/core";
import { RouterModule,Routes } from "@angular/router";
import { UserComponent } from "./components/user/user"; 
import { Login } from "./components/login/login";
import { Register } from "./components/register/register";
import { HomeComponent } from "./components/home/home";
import { AuthGuard } from "./guards/auth-guard";
import { RoleGuard } from "./guards/role-guard";
import { AdminDashboard } from "./pages/admin-dashboard/admin-dashboard";
import { InstructorDashboard } from "./pages/instructor-dashboard/instructor-dashboard";
import { StudentDashboard } from "./pages/student-dashboard/student-dashboard";





const routes:Routes=[
    {path:'',redirectTo:'/login',pathMatch:'full'},
    {path:'users',component:UserComponent},
    {path:'login',component:Login},
    {path:'register',component:Register},
    {path:'home',loadChildren:() => import('./components/home/home-module').then(m=>m.HomeModule)},
    { path: 'home', loadChildren: () => import('./components/home/home-module').then(m => m.HomeModule) },
    {path:'home', component:HomeComponent, canActivate:[AuthGuard]},
    {path:'', redirectTo: '/login', pathMatch:'full'},
    {path:'admin', component:AdminDashboard,canActivate:[RoleGuard],data:{roles:['Admin']}},
    {path:'instructor',component:InstructorDashboard, canActivate:[RoleGuard], data:{roles:['Instructor']}},
    {path:'student', component:StudentDashboard, canActivate:[RoleGuard], data:{roles:['Student']}}
];

@NgModule({
    imports:[RouterModule.forRoot(routes)],
    exports:[RouterModule]
})

export class AppRoutingModule{}



