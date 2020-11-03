import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Department } from '../_models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  baseUrl=environment.apiUrl;

  constructor(private httpClient: HttpClient) { }
  
  getDepartment(id: number){
    return this.httpClient.get(this.baseUrl+'departments/'+id);
  }
  
  getDepartments(){
    return this.httpClient.get(this.baseUrl+'departments');
  }
  
  createDepartment(department: Department){
    return this.httpClient.post(this.baseUrl+'departments', department);
  }
  
  updateDepartment(id: number, department: Department){
    return this.httpClient.put(this.baseUrl+'departments/'+id, department);
  }
  
  deleteDepartment(id: number){
    return this.httpClient.delete(this.baseUrl+'departments/'+id);
  }
}
