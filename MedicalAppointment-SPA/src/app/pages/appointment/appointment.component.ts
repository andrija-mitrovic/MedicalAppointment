import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { error } from 'protractor';
import { Appointment } from 'src/app/_models/appointment';
import { Department } from 'src/app/_models/department';
import { Doctor } from 'src/app/_models/doctor';
import { Patient } from 'src/app/_models/patient';
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
  doctor: Doctor;

  constructor(private appointmentService: AppointmentService,
              private doctorService: DoctorService,
              private patientService: PatientService,
              private departmentService: DepartmentService,
              private fb: FormBuilder) { }

  ngOnInit() {
    this.createAppointmentForm();
    this.appointmentService.getAppointments().subscribe((appointmens: Appointment[])=> {
      this.appointments=appointmens;
    });

    this.doctorService.getDoctors().subscribe((doctors: Doctor[])=>{
      this.doctors=doctors;
    })

    this.patientService.getPatients().subscribe((patients: Patient[]) => {
      this.patients=patients;
    });

    /*this.departmentService.getDepartments().subscribe((departments: Department[])=>{
      this.departments=departments;
    }, error => {
      this.alertify.error(error);
    });*/
  }

  createAppointmentForm() {
    this.appointmentForm=this.fb.group({
      appointmentDate: ['', Validators.required],
      symptoms: ['', Validators.required],
      patientId: ['', Validators.required],
      doctorId: ['', Validators.required],
      departmentId: ['']
    });
  }

  createAppointment() {
    if(this.appointmentForm.value){
      this.appointment=Object.assign({}, this.appointmentForm.value);
      
      this.doctorService.getDoctor(this.appointment.doctorId).subscribe((doctor: Doctor)=>{
        this.appointment.departmentId=doctor.department.departmentId;
        this.appointmentService.createAppointment(this.appointment).subscribe(()=>{
          this.appointmentService.getAppointments().subscribe((appointments: Appointment[])=>{
            this.appointments=appointments;
            this.appointmentForm.reset();
          });
        });
      });

      
    }
  }

  deleteAppointment(id: number) {
    this.appointmentService.deleteAppointment(id).subscribe(() => {
      this.appointments.splice(this.appointments.findIndex(p=>p.appointmentId==id, 1));
    });
  }
}
