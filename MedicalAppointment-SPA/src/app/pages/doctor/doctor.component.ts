import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Doctor } from 'src/app/_models/doctor';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { DoctorService } from 'src/app/_services/doctor.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.scss']
})
export class DoctorComponent implements OnInit {
  doctorForm: FormGroup;
  doctor: Doctor;

  constructor(private doctorService: DoctorService,
              private fb: FormBuilder,
              private router: Router,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.createDoctorForm();
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
      department: ['', Validators.required]
    });
  }

  createDoctor() {
    if(this.doctorForm.valid) {
      this.doctor = Object.assign({}, this.doctorForm.value);
      this.doctorService.createDoctor(this.doctor).subscribe(() => {
        this.router.navigate(['/doctor']);
      }, error => {
        this.alertify.error(error);
      });
    }
  }
}
