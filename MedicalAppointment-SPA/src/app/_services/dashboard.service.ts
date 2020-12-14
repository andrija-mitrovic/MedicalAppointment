import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  baseUrl=environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  getDashboardData() {
    return this.httpClient.get(this.baseUrl+'dashboard');
  }
}
