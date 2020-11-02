import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Patient } from '../_models/patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
baseUrl=environment.apiUrl;

constructor(private httpClient: HttpClient) { }

getPatient(id: number){
  return this.httpClient.get(this.baseUrl+'patients/'+id);
}

getPatients(){
  return this.httpClient.get(this.baseUrl+'patients');
}

createPatinet(patient: Patient){
  return this.httpClient.post(this.baseUrl+'patients', patient);
}

updatePatient(id: number, patient: Patient){
  return this.httpClient.put(this.baseUrl+'patients/'+id, patient);
}

deletePatient(id: number){
  return this.httpClient.delete(this.baseUrl+'patients/'+id);
}

}
