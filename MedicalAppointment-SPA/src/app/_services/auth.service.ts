import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt/lib/jwthelper.service';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseUrl=environment.apiUrl+'auth/';
jwtHelper = new JwtHelperService();
decodedToken: any;

constructor(private httpClient: HttpClient) { }

register(user: User) {
  return this.httpClient.post(this.baseUrl+'register', user);
}

login(user: any) {
  return this.httpClient.post(this.baseUrl+'login', user).pipe(
    map((response: any) => {
      const user=response;
      if(user){
        localStorage.setItem('token', user.token);
        this.decodedToken = this.jwtHelper.decodeToken(user.token);
      }
    })
  );
}

loggedIn() {
  const token = localStorage.getItem('token');
  return !this.jwtHelper.isTokenExpired(token);
}
}
