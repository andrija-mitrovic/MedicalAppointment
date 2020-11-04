import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Appointment } from '../_models/appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  baseUrl=environment.apiUrl;

  constructor(private httpClient: HttpClient) { }
  
  getAppointment(id: number){
    return this.httpClient.get(this.baseUrl+'appointments/'+id);
  }
  
  getAppointments(){
    return this.httpClient.get(this.baseUrl+'appointments');
  }
  
  createAppointment(appointment: Appointment){
    return this.httpClient.post(this.baseUrl+'appointments', appointment);
  }
  
  updateAppointment(id: number, appointment: Appointment){
    return this.httpClient.put(this.baseUrl+'appointments/'+id, appointment);
  }
  
  deleteAppointment(id: number){
    return this.httpClient.delete(this.baseUrl+'appointments/'+id);
  }
}
