import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Department } from 'src/app/_models/department';
import { DepartmentService } from 'src/app/_services/department.service';
import { DoctorService } from 'src/app/_services/doctor.service';

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
              private toaster: ToastrService,
              private doctorService: DoctorService,
              private router: Router) { }

  ngOnInit() {
    this.createDepartmentForm();
    this.departmentService.getDepartments().subscribe((departments: Department[]) => {
      this.departments=departments;
    });
  }

  createDepartmentForm() {
    this.departmentForm = this.fb.group({
      name: ['', Validators.required]
    });
  }

  createDepartment(){
    if(this.departmentForm.valid) {
      this.department = Object.assign({}, this.departmentForm.value);
      this.departmentService.createDepartment(this.department).subscribe(() => {
        this.departmentService.getDepartments().subscribe((departments: Department[]) => {
          this.departments=departments;
        });
      });
    }
  }

  deleteDepartment(id: number){
    this.departmentService.deleteDepartment(id).subscribe(() => {
      this.departments.splice(this.departments.findIndex(p=>p.departmentId==id), 1);
    });
  }
}
