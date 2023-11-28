import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Odontologo } from 'src/app/models/odontologo';
import { OdontologoService } from 'src/app/services/odontologo.service';

@Component({
  selector: 'app-consultar-odontologo',
  templateUrl: './consultar-odontologo.component.html',
  styleUrls: ['./consultar-odontologo.component.css']
})
export class ConsultarOdontologoComponent implements OnInit {

  odontologos: Odontologo[];
  odontologo: Odontologo = {
    nombre: "",
    apellido: "",
    fechaNacimiento: null,
    tipoIdentificacion: "",
    identificacion: "",
    correo: "",
    genero: "",
    direccion: "",
    telefono: "",
    salario: 0,
    cargo: "",
    
  };
  searchText: string;
  constructor(private odontologoService:OdontologoService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    
    this.get();
  }
  get() {
    this.odontologoService.get().subscribe(result => {
      this.odontologos = result;
      console.log(result);
    });
  }

}
