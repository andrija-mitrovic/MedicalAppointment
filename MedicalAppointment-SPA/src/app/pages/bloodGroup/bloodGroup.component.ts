import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BloodGroup } from 'src/app/_models/bloodGroup';
import { BloodGroupService } from 'src/app/_services/bloodGroup.service';

@Component({
  selector: 'app-bloodGroup',
  templateUrl: './bloodGroup.component.html',
  styleUrls: ['./bloodGroup.component.scss']
})
export class BloodGroupComponent implements OnInit {
  bloodGroupForm: FormGroup;
  bloodGroup: BloodGroup;
  bloodGroups: BloodGroup[];

  constructor(private bloodGroupService: BloodGroupService,
              private fb: FormBuilder,
              private router: Router) { }

  ngOnInit() {
    this.createBloodGroupForm();
    this.bloodGroupService.getBloodGroups().subscribe((bloodGroups: BloodGroup[]) => {
      this.bloodGroups=bloodGroups;
    });
  }

  createBloodGroupForm() {
    this.bloodGroupForm = this.fb.group({
      name: ['', Validators.required]
    });
  }

  createBloodGroup(){
    if(this.bloodGroupForm.valid) {
      this.bloodGroup = Object.assign({}, this.bloodGroupForm.value);
      this.bloodGroupService.createBloodGroup(this.bloodGroup).subscribe(() => {
        this.bloodGroupService.getBloodGroups().subscribe((bloodGroups: BloodGroup[]) => {
          this.bloodGroups=bloodGroups;
        });
      });
    }
  }

  deleteBloodGroup(id: number){
    this.bloodGroupService.deleteBloodGroup(id).subscribe(() => {
      this.bloodGroups.splice(this.bloodGroups.findIndex(p=>p.bloodGroupId==id), 1);
    });
  }
}
