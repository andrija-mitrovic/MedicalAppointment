import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

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


@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    AuthLayoutComponent
  ],
  providers: [
    DoctorService,
    PatientService,
    DepartmentService,
    AppointmentService,
    BloodGroupService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
