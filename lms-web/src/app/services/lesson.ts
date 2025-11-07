import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  private baseUrl='';

  constructor(private http:HttpClient){}  

  create(model:any){
    return this.http.post(this.baseUrl,model); 
  }
  
}
