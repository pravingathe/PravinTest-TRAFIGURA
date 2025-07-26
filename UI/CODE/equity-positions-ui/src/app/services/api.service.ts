import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ApiService {
  private apiBase = 'https://localhost:7084/api'; // your backend address

  constructor(private http: HttpClient) {}

  addTransaction(data: any): Observable<any> {
    return this.http.post(`${this.apiBase}/transactions`, data);
  }
  getTransactions(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiBase}/transactions`);
  }
  getPositions(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiBase}/positions`);
  }
}
