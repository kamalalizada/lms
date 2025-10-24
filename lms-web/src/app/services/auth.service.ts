import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";



@Injectable({
    providedIn:'root'
})

export class AuthService{
    getUserRole(): string | null {
        const user = localStorage.getItem('user');
        if(user){
            return JSON.parse(user).role;
        }
        return null;
    }
    private apiUrl = 'https://localhost:7106/api/Auth';

    constructor(private http:HttpClient){}

    register(fullName : string,email : string, password : string) : Observable<any>{
        return this.http.post(`${this.apiUrl}/register`,{fullName , email , password});
    }

    login (email : string, password : string): Observable<any>{
        const body = {email,password};
        return this.http.post(`${this.apiUrl}/login`,{email,password});
    }

    logout(){
        localStorage.removeItem('token');
        localStorage.removeItem('role');
    }

    saveToken(token : string, role : string){
        localStorage.setItem('token',token);
        localStorage.setItem('role',role);
    }

    getToken(): string | null{
        return localStorage.getItem('token');
    }

    getRole(): string | null{
        return localStorage.getItem('role');
    }

    isAuthenticated(): boolean{
        return !! localStorage.getItem('token')
    }
}




