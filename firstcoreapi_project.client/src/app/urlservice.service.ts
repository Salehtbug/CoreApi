import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlserviceService {

  constructor(private http: HttpClient) { }
    
  getall() { return this.http.get('https://localhost:7088/api/Category') }

  addcategory(data: any) { return this.http.post('https://localhost:7088/api/Category' ,data) }

  deletecategory(id: number) {
    return this.http.delete(`https://localhost:7088/api/Category/${id}`);
  }

  getById(id: number) {
    return this.http.get(`https://localhost:7088/api/Category/${id}`);
  }


  updatecategory(id: number, category: any) { return this.http.put(`https://localhost:7088/api/Category/${id}`, category) }
}
