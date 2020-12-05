import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { error } from 'protractor';
import { Department } from 'src/app/_models/department';
import { Doctor } from 'src/app/_models/doctor';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { DepartmentService } from 'src/app/_services/department.service';
import { DoctorService } from 'src/app/_services/doctor.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.scss']
})
export class DoctorComponent implements OnInit {
  doctorForm: FormGroup;
  doctor: Doctor;
  doctors: Doctor[];
  departments: Department[];
  genders: Array<String>=['Male','Female'];

  constructor(private doctorService: DoctorService,
              private departmentService: DepartmentService,
              private fb: FormBuilder,
              private router: Router,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.createDoctorForm();
    this.doctorService.getDoctors().subscribe((doctors: Doctor[]) => {
      this.doctors=doctors;
      console.log(this.doctors);
    }, error => {
      this.alertify.error(error);
    });

    this.departmentService.getDepartments().subscribe((departments: Department[])=> {
      this.departments=departments;
    });
  }

  createDoctorForm() {
    this.doctorForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      gender: ['', Validators.required],
      education: ['', Validators.required],
      designation: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      departmentId: ['', Validators.required]
    });
  }

  createDoctor() {
    if(this.doctorForm.valid) {
      this.doctor = Object.assign({}, this.doctorForm.value);
      this.doctorService.createDoctor(this.doctor).subscribe(() => {
        this.doctorService.getDoctors().subscribe((doctors: Doctor[])=>{
          this.doctors=doctors;
          this.doctorForm.reset();
        },error => {
          this.alertify.error(error);
        });
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  deleteDoctor(id: number){
    console.log(id);
    this.doctorService.deleteDoctor(id).subscribe(() => {
      this.doctors.splice(this.doctors.findIndex(p=>p.doctorId==id), 1);
    }, error => {
      this.alertify.error(error);
    });
  }
}
