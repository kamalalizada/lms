import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

interface AuthResponse {
  token: string;
  role: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
  standalone: false
})
export class Login {
  email: string = '';
  password: string = '';
  message: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onLogin() {
    this.authService.login(this.email, this.password).subscribe({
      next: (response: AuthResponse) => {
        this.message = 'Login successful! Redirecting...';

        const role = response.role?.toLowerCase().trim();

        setTimeout(() => {
          if (role === 'instructor') {
            this.router.navigate(['/instructor']);
          } else if (role === 'student') {
            this.router.navigate(['/student']);
          } else if (role === 'admin') {
            this.router.navigate(['/admin']);
          } else {
            this.router.navigate(['/login']);
          }
        }, 500);
      },
      error: () => {
        this.message = 'Email or password is incorrect!';
      }
    });
  }
}
