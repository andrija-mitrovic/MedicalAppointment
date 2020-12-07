import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { error } from 'protractor';
import { Appointment } from 'src/app/_models/appointment';
import { Department } from 'src/app/_models/department';
import { Doctor } from 'src/app/_models/doctor';
import { Patient } from 'src/app/_models/patient';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AppointmentService } from 'src/app/_services/appointment.service';
import { DepartmentService } from 'src/app/_services/department.service';
import { DoctorService } from 'src/app/_services/doctor.service';
import { PatientService } from 'src/app/_services/patient.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})
export class AppointmentComponent implements OnInit {
  appointmentForm: FormGroup;
  appointment: Appointment;
  appointments: Appointment[];
  doctors: Doctor[];
  patients: Patient[];
  departments: Department[];

  constructor(private appointmentService: AppointmentService,
              private doctorService: DoctorService,
              private patientService: PatientService,
              private departmentService: DepartmentService,
              private fb: FormBuilder,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.createAppointmentForm();
    this.appointmentService.getAppointments().subscribe((appointmens: Appointment[])=> {
      this.appointments=appointmens;
    }, error => {
      this.alertify.error(error);
    });

    this.doctorService.getDoctors().subscribe((doctors: Doctor[])=>{
      this.doctors=doctors;
    }, error => {
      this.alertify.error(error);
    })

    this.patientService.getPatients().subscribe((patients: Patient[]) => {
      this.patients=patients;
    }, error=> {
      this.alertify.error(error);
    });

    this.departmentService.getDepartments().subscribe((departments: Department[])=>{
      this.departments=departments;
    }, error => {
      this.alertify.error(error);
    });
  }

  createAppointmentForm() {
    this.appointmentForm=this.fb.group({
      appointmentDate: ['', Validators.required],
      symptoms: ['', Validators.required],
      patientId: ['', Validators.required],
      doctorId: ['', Validators.required],
      departmentId: ['', Validators.required]
    });
  }

  createAppointment() {
    if(this.appointmentForm.value){
      this.appointment=Object.assign({}, this.appointmentForm.value);
      this.appointmentService.createAppointment(this.appointment).subscribe(()=>{
        this.appointmentService.getAppointments().subscribe((appointments: Appointment[])=>{
          this.appointments=appointments;
          this.appointmentForm.reset();
        },error=>{
          this.alertify.error(error);
        });
      },error=>{
          this.alertify.error(error); 
      });
    }
  }

  deleteAppointment(id: number) {
    this.appointmentService.deleteAppointment(id).subscribe(() => {
      this.appointments.splice(this.appointments.findIndex(p=>p.appointmentId==id, 1));
    }, error => {
      this.alertify.error(error);
    });
  }
}
