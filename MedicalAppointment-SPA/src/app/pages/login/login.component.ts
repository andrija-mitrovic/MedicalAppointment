import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  model: any = {};
  
  constructor(private authService: AuthService,
              private router: Router,
              private toastr: ToastrService) {}

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  login() {
    this.authService.login(this.model).subscribe(()=>{
      this.router.navigate(['/dashboard'])
    });
  }


}
