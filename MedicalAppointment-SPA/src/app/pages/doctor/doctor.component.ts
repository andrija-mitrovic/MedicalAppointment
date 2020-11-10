import { Component, OnInit } from '@angular/core';
import { DoctorService } from 'src/app/_services/doctor.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.scss']
})
export class DoctorComponent implements OnInit {

  constructor(private doctorService: DoctorService) { }

  ngOnInit() {
    this.createDoctorForm();
  }

  createDoctorForm() {
    
  }
}
