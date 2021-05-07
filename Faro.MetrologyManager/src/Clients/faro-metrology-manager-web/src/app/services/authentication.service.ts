import { Injectable } from '@angular/core';
import { User } from "../models/user";

@Injectable()
export class AuthenticationService {
  constructor() { }

  login(email: string, password: string) {
    let user = new User(email, password);
    localStorage.setItem('currentUser', JSON.stringify(user));
    return true;
  }

  logout(user: User) {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }
}
