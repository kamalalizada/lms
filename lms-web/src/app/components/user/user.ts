import { Component, OnInit } from '@angular/core';
import { User } from './models/user.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user',
  standalone:false,
  templateUrl: './user.html',
  styleUrls: ['./user.css']
})
export class UserComponent implements OnInit {

  users: User[] = [];
  newUser: User = { fullname: '', email: '', password: '' };
  editingUser?: User;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getAll().subscribe({
      next: data => this.users = data,
      error: err => console.error('User load error:', err)
    });
  }

  addUser() {
    if (!this.newUser.fullname || !this.newUser.email || !this.newUser.password) return;

    this.userService.add(this.newUser).subscribe({
      next: () => {
        this.newUser = { fullname: '', email: '', password: '' };
        this.loadUsers();
      },
      error: err => console.error('Add user error:', err)
    });
  }

  deleteUser(id: number) {
    this.userService.delete(id).subscribe({
      next: () => this.loadUsers(),
      error: err => console.error('Delete user error:', err)
    });
  }

  editUser(user: User) {
    this.editingUser = { ...user };
  }

  updateUser() {
    if (this.editingUser) {
      this.userService.update(this.editingUser).subscribe({
        next: () => {
          this.editingUser = undefined;
          this.loadUsers();
        },
        error: err => console.error('Update error:', err)
      });
    }
  }
}