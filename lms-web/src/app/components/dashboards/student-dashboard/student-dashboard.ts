import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardService } from '../../../services/dashboard';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-student-dashboard',
  templateUrl: './student-dashboard.html',
  styleUrls: ['./student-dashboard.css'],
  standalone: false
})
export class StudentDashboard implements OnInit {
  dashboardData: any;

  constructor(private dashboardService: DashboardService, private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    const studentIdStr = this.authService.getUserId();
    if (!studentIdStr) {
      this.router.navigate(['/login']);
      return;
    }
    const studentId = parseInt(studentIdStr, 10);
    this.dashboardService.getStudentDashboard(studentId)
      .subscribe({ next: data => this.dashboardData = data, error: err => console.error(err) });
  }
}
