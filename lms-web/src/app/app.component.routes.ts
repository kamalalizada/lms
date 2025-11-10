import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { AdminDashboard } from './components/dashboards/admin-dashboard/admin-dashboard';
import { RoleGuard } from './guards/role-guard';
import { InstructorDashboard } from './components/dashboards/instructor-dashboard/instructor-dashboard';
import { StudentDashboard } from './components/dashboards/student-dashboard/student-dashboard';
import { Catalog } from './components/catalog/catalog';
import { AssignmentListComponent } from './components/catalog/assignment-list/assignment-list';

export const routes: Routes = [
    { path: '', component: Login, pathMatch: 'full' },
    {
        path: 'dashboards',
        children: [
            {
                path: 'admin',
                component: AdminDashboard,
                canActivate: [RoleGuard],
                data: { roles: ['admin'] }
            },
            {
                path: 'instuctor',
                component: InstructorDashboard,
                canActivate: [RoleGuard],
                data: { roles: ['instructor', 'admin'] }
            },
            {
                path: 'student',
                component: StudentDashboard,
                canActivate: [RoleGuard],
                data: { roles: ['admin', 'student'] }
            }
        ]
    },
    {
        path: 'catalog',
        component: Catalog,
        canActivate: [RoleGuard],
        data: { roles: ['admin'] },
        children: [
            {
                path: 'assignment-list',
                component: AssignmentListComponent,
                canActivate: [RoleGuard],
                data: { roles: ['admin'] },
            },
        ]
    }
];
