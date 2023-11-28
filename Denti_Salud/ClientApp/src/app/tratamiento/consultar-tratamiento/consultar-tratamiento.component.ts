import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Tratamiento } from 'src/app/models/tratamiento';
import { TratamientoService } from 'src/app/services/tratamiento.service';

@Component({
  selector: 'app-consultar-tratamiento',
  templateUrl: './consultar-tratamiento.component.html',
  styleUrls: ['./consultar-tratamiento.component.css']
})
export class ConsultarTratamientoComponent implements OnInit {

  tratamientos: Tratamiento[]
  tratamiento: Tratamiento = {
    idTratamiento: 0,
    nombre: '',
    descripcion: '',
  }
  searchText: string
  constructor(
    private tratamientoService: TratamientoService,
    private modalService: NgbModal,
    private handleError: HandleHttpErrorService,
  ) {}

  ngOnInit(): void {
    this.get();
  }
  get() {
    this.tratamientoService.get().subscribe((result) => {
      this.tratamientos = result
      console.log(result)
    });
  }

}
