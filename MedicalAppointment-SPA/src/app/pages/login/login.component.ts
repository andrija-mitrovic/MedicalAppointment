import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  model: any = {};
  
  constructor(private authService: AuthService,
              private router: Router) {}

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  login() {
    this.authService.login(this.model).subscribe(()=>{
      console.log('Successfully logged');
    }, error => {
      console.log(error);
    }, () => {
      this.router.navigate(['/dashboard'])
    })
  }


}
