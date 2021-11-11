import { ClienteDetailService } from './../../shared/cliente-detail.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ClienteDetail } from 'src/app/shared/cliente-detail.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-client-crud',
  templateUrl: './client-crud.component.html',
  styleUrls: ['./client-crud.component.css']
})
export class ClientCrudComponent implements OnInit {

  titulo = 'Clientes';


  constructor(public service:ClienteDetailService,private toastr:ToastrService) {}

  

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:ClienteDetail){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onSubmit(form:NgForm){
   if(this.service.formData.id == 0)
      this.insertRecord(form);
    else{
      this.updateRecord(form);
    }
  }

  insertRecord(form:NgForm){
    this.service.postClienteDetail().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Salvo com sucesso','Cliente registrado')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form:NgForm){
    this.service.putClienteDetail().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Editado com sucesso','Resgistro alterado')
      },
      err => { console.log(err); }
    );
  }

  onDelete(id:number){
    if(confirm('Tem certeza que quer apagar?')){
      this.service.deleteClienteDetail(id)
      .subscribe(
        res=>{
          this.service.refreshList();
          this.toastr.error("cliente apagado com sucesso","Excluido");
        },
        err =>{console.log(err)}
      )
    }
  }


  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new ClienteDetail();
  }

}
