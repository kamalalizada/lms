import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {

  private baseurl = 'https://localhost:7106/api/Enrollment';

  constructor(private http:HttpClient){}

  getByStudentId(studentId:number){
    return this.http.get<any[]>(`${this.baseurl}/student/${studentId}`);
  }
  
}
