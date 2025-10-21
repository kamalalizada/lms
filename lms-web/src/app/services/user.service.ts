import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "../models/user.model";

@Injectable({
    providedIn:'root'
})

export class UserService{
    private apiUrl = 'https://localhost:7106/api/User';

    constructor(private http:HttpClient){}

    getAll():Observable<User[]>{
        return this.http.get<User[]>(this.apiUrl)  
        }

    getById(id:number): Observable<User>{
        return this.http.get<User>(`${this.apiUrl}/${id}`);
    }

    add(user:User):Observable<any>{
        return this.http.post(this.apiUrl,user);
    }

    update(user:User):Observable<any>{
        return this.http.put(this.apiUrl,user);
    }

    delete(id:number):Observable<any>{
        return this.http.delete(`${this.apiUrl}/${id}}`);
    }
}
