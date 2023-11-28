import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Recepcionista } from 'src/app/models/recepcionista';
import { RecepcionistaService } from 'src/app/services/recepcionista.service';

@Component({
  selector: 'app-consultar-recepcionista',
  templateUrl: './consultar-recepcionista.component.html',
  styleUrls: ['./consultar-recepcionista.component.css']
})
export class ConsultarRecepcionistaComponent implements OnInit {
  recepcionistas: Recepcionista[]
  recepcionista: Recepcionista = {
    nombre: '',
    apellido: '',
    fechaNacimiento: null,
    tipoIdentificacion: '',
    identificacion: '',
    correo: '',
    genero: '',
    direccion: '',
    telefono: '',
    salario: 0,
  }
  searchText: string
  constructor(
    private recepcionistaService: RecepcionistaService,
    private modalService: NgbModal,
    private handleError: HandleHttpErrorService,
  ) {}

  ngOnInit(): void {
    this.get();
  }
  get() {
    this.recepcionistaService.get().subscribe((result) => {
      this.recepcionistas = result
      console.log(result)
    });
  }
}
