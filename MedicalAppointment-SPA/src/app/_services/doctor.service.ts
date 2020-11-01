import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Doctor } from '../_models/doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
baseUrl=environment.apiUrl;

constructor(private httpClient: HttpClient) { }

getDoctor(id: number){
  return this.httpClient.get(this.baseUrl+'doctors/'+id);
}

getDoctors(){
  return this.httpClient.get(this.baseUrl+'doctors');
}

createDoctor(doctor: Doctor){
  return this.httpClient.post(this.baseUrl+'doctors/', doctor);
}

updateDoctor(id: number, doctor: Doctor){
  return this.httpClient.put(this.baseUrl+'doctors/'+id, doctor);
}

deleteDoctor(id: number){
  return this.httpClient.delete(this.baseUrl+'doctors/'+id);
}
}
