import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Paciente } from 'src/app/models/Paciente';
import { PacienteService } from 'src/app/services/PacienteService';

@Component({
  selector: 'app-consulta-paciente',
  templateUrl: './consulta-paciente.component.html',
  styleUrls: ['./consulta-paciente.component.css']
})
export class ConsultaPacienteComponent implements OnInit {

  pacientes: Paciente[];
  paciente: Paciente = {
    nombre: "",
    apellido: "",
    fechaNacimiento: null,
    tipoIdentificacion: "",
    identificacion: "",
    correo: "",
    genero: "",
    direccion: "",
    telefono: "",
  };
  searchText: string;
  constructor(private pacienteService:PacienteService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.get();
  }
  get() {
    this.pacienteService.get().subscribe(result => {
      this.pacientes = result;
      console.log(result);
    });
  }

}
