import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-user',
  standalone:false,
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: User[] = [];
  newUser: User = { fullname: '', email: '', password: '' };
  editingUser?: User;

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getAll().subscribe(data => {
      this.users = data;
    });
  }

  addUser() {
    this.userService.add(this.newUser).subscribe(() => {
      this.newUser = { fullname: '', email: '', password: '' };
      this.loadUsers();
    });
  }

    editUser(user: any) {
    this.editingUser = { ...user };
  }

  deleteUser(id: number) {
    this.userService.delete(id).subscribe(() => {
      this.loadUsers();
    });
  }

  updateUser() {
    if (this.editingUser) {
      this.userService.update(this.editingUser).subscribe(() => {
        this.editingUser = undefined;
        this.loadUsers();
      });
    }
  }
}
