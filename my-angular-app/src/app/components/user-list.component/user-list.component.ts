import { Component, OnInit } from '@angular/core';
import { User, UserCreationDto } from '../../models/user.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
})
export class UserListComponent implements OnInit {
  users: User[] = [];
  newUser: UserCreationDto = {
    Name: '',
    LastName: '',
    Address: '',
    PhoneNumber: '',
    CustomerId: '',
    InitialCredit: 0.0,
  };

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.fetchUsers();
  }

    addUser() {
      this.userService.addUser(this.newUser).subscribe(
        (response: any) => {
          console.log('User added:', response);
          this.fetchUsers();
        },
        (error) => {
          console.log('Error adding user:', error);
        }
      );
    }
    fetchUsers() {
      this.userService.fetchUsers().subscribe(
        (response: User[]) => {
          this.users = response;
        },
        (error) => {
          console.log('Error fetching users:', error);
        }
      );
    }
  }
