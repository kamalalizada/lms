import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, tap } from "rxjs";

interface AuthResponse {
  token: string;
  role: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7106/api/Auth';

  constructor(private http: HttpClient) {}

  // ===== Login =====
  login(email: string, password: string): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, { email, password }).pipe(
      tap(res => {
        if (res?.token && res?.role) {
          this.saveToken(res.token, res.role);
        }
      })
    );
  }

  // ===== Register =====
  register(fullName: string, email: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, { fullName, email, password });
  }

  // ===== Logout =====
  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
  }

  private saveToken(token: string, role: string): void {
    localStorage.setItem('token', token);
    localStorage.setItem('role', role.toLowerCase()); 
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getRole(): string | null {
    return localStorage.getItem('role');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  getUserId(): string | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload?.userId?.toString() || null;
    } catch {
      return null;
    }
  }
}
