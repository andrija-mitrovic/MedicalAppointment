import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BloodGroup } from '../_models/bloodGroup';

@Injectable({
  providedIn: 'root'
})
export class BloodGroupService {
  baseUrl=environment.apiUrl;

  constructor(private httpClient: HttpClient) { }
  
  getBloodGroup(id: number){
    return this.httpClient.get(this.baseUrl+'bloodgroups/'+id);
  }
  
  getBloodGroups(){
    return this.httpClient.get(this.baseUrl+'bloodgroups');
  }
  
  createBloodGroup(bloodGroup: BloodGroup){
    return this.httpClient.post(this.baseUrl+'bloodGroups', bloodGroup);
  }
  
  updateBloodGroup(id: number, bloodGroup: BloodGroup){
    return this.httpClient.put(this.baseUrl+'bloodGroups/'+id, bloodGroup);
  }
  
  deleteBloodGroup(id: number){
    return this.httpClient.delete(this.baseUrl+'bloodGroups/'+id);
  }
}
