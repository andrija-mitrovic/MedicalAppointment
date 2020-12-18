import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { DoctorService } from './_services/doctor.service';
import { PatientService } from './_services/patient.service';
import { DepartmentService } from './_services/department.service';
import { AppointmentService } from './_services/appointment.service';
import { BloodGroupService } from './_services/bloodGroup.service';
import { AuthService } from './_services/auth.service';
import { DashboardService } from './_services/dashboard.service';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptorProvider } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth']
      }
    }),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    AuthLayoutComponent,
  ],
  providers: [
    ErrorInterceptorProvider,
    DoctorService,
    PatientService,
    DepartmentService,
    AppointmentService,
    BloodGroupService,
    AuthService,
    DashboardService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
