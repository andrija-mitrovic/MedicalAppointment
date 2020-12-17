import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ClipboardModule } from 'ngx-clipboard';

import { AdminLayoutRoutes } from './admin-layout.routing';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { DoctorComponent } from '../../pages/doctor/doctor.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DepartmentComponent } from 'src/app/pages/department/department.component';
import { BloodGroupComponent } from 'src/app/pages/bloodGroup/bloodGroup.component';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { PatientComponent } from 'src/app/pages/patient/patient.component';
import { AppointmentComponent } from 'src/app/pages/appointment/appointment.component';
import { TestErrorsComponent } from 'src/app/errors/test-errors/test-errors.component';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptorProvider } from 'src/app/_interceptors/error.interceptor';
import { NotFoundComponent } from 'src/app/errors/not-found/not-found.component';
import { ServerErrorComponent } from 'src/app/errors/server-error/server-error.component';
// import { ToastrModule } from 'ngx-toastr';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ReactiveFormsModule,
    ClipboardModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  declarations: [
    DashboardComponent,
    DoctorComponent,
    TablesComponent,
    IconsComponent,
    MapsComponent,
    DepartmentComponent,
    BloodGroupComponent,
    PatientComponent,
    AppointmentComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent
  ],
  providers:[
    AlertifyService,
    ErrorInterceptorProvider
  ]
})

export class AdminLayoutModule {}
