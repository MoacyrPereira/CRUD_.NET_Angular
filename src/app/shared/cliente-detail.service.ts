import { Injectable } from '@angular/core';
import { ClienteDetail } from './cliente-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ClienteDetailService {

  constructor(private http:HttpClient){}

  readonly baseURL = 'http://localhost:58061/api/ClienteDetail'

  formData:ClienteDetail = new ClienteDetail();

  list : ClienteDetail[];


  postClienteDetail(){
   return this.http.post(this.baseURL, this.formData);
  }

  putClienteDetail(){
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  deleteClienteDetail(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as ClienteDetail[])
  }



}
