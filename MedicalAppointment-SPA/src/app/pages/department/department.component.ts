import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Department } from 'src/app/_models/department';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { DepartmentService } from 'src/app/_services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss']
})
export class DepartmentComponent implements OnInit {
  departmentForm: FormGroup;
  department: Department;
  departments: Department[];

  constructor(private departmentService: DepartmentService,
              private fb: FormBuilder,
              private router: Router,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.createDepartmentForm();
    this.departmentService.getDepartments().subscribe((departments: Department[]) => {
      this.departments=departments;
    }, error => {
      this.alertify.error;
    });
  }

  createDepartmentForm() {
    this.departmentForm = this.fb.group({
      name: ['', Validators.required]
    });
  }

  createDepartment(){
    if(this.departmentForm.valid) {
      console.log('asas');
      this.department = Object.assign({}, this.departmentForm.value);
      this.departmentService.createDepartment(this.department).subscribe(() => {
        this.departmentService.getDepartments().subscribe((departments: Department[]) => {
          this.departments=departments;
        }, error => {
          this.alertify.error(error);
        });
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  deleteDepartment(id: number){
    this.departmentService.deleteDepartment(id).subscribe(() => {
      this.departments.splice(this.departments.findIndex(p=>p.departmentId==id), 1);
    }, error => {
      this.alertify.error(error);
    });
  }
}
