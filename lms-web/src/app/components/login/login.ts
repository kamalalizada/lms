import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone:false,
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  email : string='';
  password : string = '';
  message : string = '';

  constructor(private authService:AuthService,private router : Router){}

  onLogin(){
    this.authService.login(this.email,this.password).subscribe({
      next:(response : any)=>{
        this.authService.saveToken(response.token,response.role);

        this.message = 'Login successful! Redirecting...';

      setTimeout(()=>{
        this.router.navigate(['/home']);
      },1000);
      },

      error:(err)=>{
        this.message='Email or password is incorrect.!';
      }
    });
  }

}
