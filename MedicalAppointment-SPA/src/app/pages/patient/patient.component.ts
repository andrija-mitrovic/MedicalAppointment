import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BloodGroup } from 'src/app/_models/bloodGroup';
import { Patient } from 'src/app/_models/patient';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BloodGroupService } from 'src/app/_services/bloodGroup.service';
import { PatientService } from 'src/app/_services/patient.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit {
  patientForm: FormGroup;
  patient: Patient;
  patients: Patient[];
  bloodGroups: BloodGroup[];
  genders: Array<String>=['Male','Female'];

  constructor(private patientService: PatientService,
              private bloodGroupService: BloodGroupService,
              private fb: FormBuilder,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.createPatientForm();
    this.patientService.getPatients().subscribe((patients: Patient[]) => {
      this.patients=patients;
    }, error => {
      this.alertify.error(error);
    });

    this.bloodGroupService.getBloodGroups().subscribe((bloodGroups: BloodGroup[])=> {
      this.bloodGroups=bloodGroups;
    });
  }

  createPatientForm() {
    this.patientForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      gender: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      bloodGroupId: ['', Validators.required]
    });
  }

  createPatient() {
    if(this.patientForm.valid) {
      this.patient = Object.assign({}, this.patientForm.value);
      this.patientService.createPatinet(this.patient).subscribe(() => {
        this.patientService.getPatients().subscribe((patients: Patient[])=>{
          this.patients=patients;
          this.patientForm.reset();
        },error => {
          this.alertify.error(error);
        });
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  deletePatient(id: number) {
    this.patientService.deletePatient(id).subscribe(() => {
      this.patients.splice(this.patients.findIndex(p=>p.patientId==id), 1);
    }, error => {
      this.alertify.error(error);
    });
  }
  
}
