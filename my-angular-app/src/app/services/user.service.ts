import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User, UserCreationDto } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly apiUrl = 'https://localhost:44337/api/User';

  constructor(private http: HttpClient) { }

  addUser(newUser: UserCreationDto): Observable<any> {
    const url = `${this.apiUrl}`;
    return this.http.post(url, newUser);
  }

  fetchUsers(): Observable<User[]> {
    const url = `${this.apiUrl}/users`;
    return this.http.get<User[]>(url);
  }
}
