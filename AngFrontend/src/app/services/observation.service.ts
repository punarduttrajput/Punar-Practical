import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ObservationService {
  private apiUrl = 'https://localhost:7095/api/Data'; 

  constructor(private http: HttpClient) { }

  getObservation(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/getdata`).pipe(
      tap(response => {
        console.log('API Response:', response);
      })
    );
  }

  saveObservation(data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/updatedata`, data).pipe(
      tap(response => {
        console.log('Save Response:', response);
      })
    );
  }
}
