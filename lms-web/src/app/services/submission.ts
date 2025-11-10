import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubmissionService {
  private apiUrl= 'https://localhost:7106/api/Submission';

  constructor(private http:HttpClient){}

  submitAssignment(data:any):Observable<any>{
    return this.http.post<any>(this.apiUrl,data);}

    getSubmissionForAssignment(assignmentId:number):Observable<any[]>{
      return this.http.get<any[]>(`${this.apiUrl}/ByAssignment/${assignmentId}`);
    }

    getSubmissionById(id:number):Observable<any>{
      return this.http.get<any>(`${this.apiUrl}/${id}`);
    }

    gradeSubmission(id:number,gradeData:any):Observable<any>{
      return this.http.put<any>(`${this.apiUrl}/Grade/${id}`,gradeData);
    }
  
}
