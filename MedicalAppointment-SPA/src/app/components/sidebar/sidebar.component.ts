import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'ni ni-chart-pie-35 text-info', class: '' },
    { path: '/appointment', title: 'Appointment',  icon: 'ni ni-ruler-pencil text-primary', class: '' },
    { path: '/doctor', title: 'Doctor',  icon:'ni-single-02 text-blue', class: '' },
    { path: '/department', title: 'Department',  icon:'ni-archive-2 text-yellow', class: '' },
    { path: '/bloodGroup', title: 'Blood Group',  icon:'ni ni-tag text-red', class: '' },
    { path: '/patient', title: 'Patient',  icon:'ni ni-ambulance text-orange', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;

  constructor(private router: Router,
              private authService: AuthService,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
  }

  logout(){
    localStorage.removeItem('token');
    this.authService.decodedToken = null;
    this.router.navigate(['/login']);
    this.alertify.message('Logged out');
  }
}
