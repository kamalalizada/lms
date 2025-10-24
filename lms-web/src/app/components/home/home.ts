import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class HomeComponent implements OnInit {
  userName: string = '';

  constructor(private authService : AuthService){}

  ngOnInit(): void {
    this.userName = this.authService.getRole() || 'User';
  }
}
