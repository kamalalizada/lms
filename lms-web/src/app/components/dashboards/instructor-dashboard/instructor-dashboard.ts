import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardService } from '../../../services/dashboard';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-instructor-dashboard',
  templateUrl: './instructor-dashboard.html',
  styleUrls: ['./instructor-dashboard.css'],
  standalone: false
})
export class InstructorDashboard implements OnInit {
  dashboardData: any;
  message: string = '';

  constructor(
    private dashboardService: DashboardService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    // JWT token-dən instructor ID-ni düzgün alırıq
    const instructorIdStr = this.authService.getUserId();
    if (!instructorIdStr) {
      this.router.navigate(['/login']);
      return;
    }

    const instructorId = parseInt(instructorIdStr, 10);

    // Dashboard API çağırışı, Authorization header əlavə olunur
    this.dashboardService.getInstructorDashboard(instructorId)
      .subscribe({
        next: data => this.dashboardData = data,
        error: err => {
          console.error('Dashboard load error:', err);
          if (err.status === 401) {
            this.message = 'Unauthorized! Please login again.';
            this.authService.logout();
            this.router.navigate(['/login']);
          } else {
            this.message = 'Something went wrong loading dashboard.';
          }
        }
      });
  }
}
