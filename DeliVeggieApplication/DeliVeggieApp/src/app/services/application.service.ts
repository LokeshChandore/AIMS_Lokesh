import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  apiUrl = 'https://localhost:7280/api/Messaging';
  constructor(private _httpClient: HttpClient) { }

  getProduct(): Observable<any[]> {
    var prod = this._httpClient.get<any[]>(`${this.apiUrl}/GetProducts`);
    return prod;
  }

  getProductById(id: any): Observable<any> {
    return this._httpClient.get<any>(`${this.apiUrl}/GetProduct/${id}`);
  }
}
