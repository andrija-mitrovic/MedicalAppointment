import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { DoctorComponent } from '../../pages/doctor/doctor.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { DepartmentComponent } from 'src/app/pages/department/department.component';
import { BloodGroupComponent } from 'src/app/pages/bloodGroup/bloodGroup.component';
import { PatientComponent } from 'src/app/pages/patient/patient.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'doctor',         component: DoctorComponent },
    { path: 'department',     component: DepartmentComponent },
    { path: 'bloodGroup',     component: BloodGroupComponent },
    { path: 'patient',        component: PatientComponent },
    { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent }
];
