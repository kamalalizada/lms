import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AssignmentService {
  private apiUrl = 'https://localhost:7106/api/Assignment';

  constructor(private http:HttpClient){}

  getAssignments(): Observable<any[]>
{
  return this.http.get<any[]>(this.apiUrl);
}  

// createAssignment(data:any):Observable<any>{
//   // return this.http.put<any>(`${this.apiUrl}/${id}`,data);
// }

deleteAssignment(id:number):Observable <any>{
  return this.http.delete<any>(`${this.apiUrl}/${id}`);
}
}
