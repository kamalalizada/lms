import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private baseUrl = 'https://localhost:7222/api';

  constructor(private http: HttpClient) {}

  getInstructorDashboard(instructorId: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/instructor/dashboard/${instructorId}`);
  }

  getStudentDashboard(studentId: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/student/dashboard/${studentId}`);
  }

  getAdminDashboard(): Observable<any> {
    return this.http.get(`${this.baseUrl}/admin/dashboard`);
  }
}
