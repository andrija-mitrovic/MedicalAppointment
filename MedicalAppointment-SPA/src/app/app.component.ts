import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Medical Appointment';

  jwtHelper = new JwtHelperService();

  constructor(private auth: AuthService) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if(token) {
      this.auth.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }
}
