import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';
  private currentUserSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any): Observable<User> {
    return this.http.post<User>(this.baseUrl + 'Account/login', model)
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);  
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
