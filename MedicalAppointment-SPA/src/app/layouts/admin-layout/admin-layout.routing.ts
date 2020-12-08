import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { DoctorComponent } from '../../pages/doctor/doctor.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { DepartmentComponent } from 'src/app/pages/department/department.component';
import { BloodGroupComponent } from 'src/app/pages/bloodGroup/bloodGroup.component';
import { PatientComponent } from 'src/app/pages/patient/patient.component';
import { AppointmentComponent } from 'src/app/pages/appointment/appointment.component';
import { AuthGuard } from 'src/app/_guards/auth.guard';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent, canActivate: [AuthGuard] },
    { path: 'doctor',         component: DoctorComponent, canActivate: [AuthGuard] },
    { path: 'appointment',    component: AppointmentComponent, canActivate: [AuthGuard] },
    { path: 'department',     component: DepartmentComponent, canActivate: [AuthGuard] },
    { path: 'bloodGroup',     component: BloodGroupComponent, canActivate: [AuthGuard] },
    { path: 'patient',        component: PatientComponent, canActivate: [AuthGuard] },
    { path: 'tables',         component: TablesComponent, canActivate: [AuthGuard] },
    { path: 'icons',          component: IconsComponent, canActivate: [AuthGuard] },
    { path: 'maps',           component: MapsComponent, canActivate: [AuthGuard] }
];
