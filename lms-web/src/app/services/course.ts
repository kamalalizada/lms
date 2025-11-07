import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private baseUrl = 'https://localhost:7106/api/Course';
  private enrollUrl= 'https://localhost:7106/api/Enrollment';

  constructor(private http:HttpClient){}

  getAll(){
    return this.http.get<any[]>(`${this.baseUrl}`);
  }

  getById(id:number){
    return this.http.get<any>(`${this.baseUrl}/${id}`);
  }

  enroll(courseId:number , studentId:number){
    return this.http.post(`${this.enrollUrl}/enroll`,{
      courseId,
      studentId
      })
  }

  create(course: any){
    return this.http.post(`${this.baseUrl}`, course);
  }

  getByInstructorId(instructorId:number){
    return this.http.get<any[]>(`${this.baseUrl}/instructor/${instructorId}`);
  };
  

}
