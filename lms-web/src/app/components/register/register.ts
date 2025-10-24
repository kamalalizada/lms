import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Route, Router, RouterLink } from '@angular/router';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone:false,
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  fullName : string = '';
  email : string = '';
  password: string = '';
  message : string = '';

  constructor(private authService:AuthService, private router:Router){}
  
  onRegister(){
    this.authService.register(this.fullName,this.email,this.password).subscribe({
      next :(res)=>{
        this.message = 'Registration successful! You  can log in';
        setTimeout(()=>{
          this.router.navigate(['/login']);
        }, 1500);
      },

      error:(err) => {
        this.message = 'An error occurred during registration';
      }
    });
  }
}
