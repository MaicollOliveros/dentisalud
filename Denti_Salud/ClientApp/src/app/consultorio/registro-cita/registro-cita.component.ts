import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Cita } from 'src/app/models/cita';
import { Odontologo } from 'src/app/models/odontologo';
import { Paciente } from 'src/app/models/Paciente';
import { CitaService } from 'src/app/services/cita.service';
import { OdontologoService } from 'src/app/services/odontologo.service';
import { PacienteService } from 'src/app/services/PacienteService';

@Component({
  selector: 'app-registro-cita',
  templateUrl: './registro-cita.component.html',
  styleUrls: ['./registro-cita.component.css']
})
export class RegistroCitaComponent implements OnInit {
  pacientes: Paciente[];
  odontologos: Odontologo[];
  citas: Cita[];
  cita: Cita = {
    idPaciente: "",
    idOdontologo: "",
    horaInicio: null,
    horaFin: null,
    motivo: "",
    observaciones: "",
  };
  searchText: string;
  constructor(private citaService: CitaService,
    private modalService: NgbModal,
    private pacienteService: PacienteService,
    private odontologoService: OdontologoService
  ) { }

  ngOnInit(): void {
    
    // this.citaService.get().subscribe(result => {
    //   this.citas = result;
    //   console.log(result);
    // });
    this.getPaciente();
    this.getOdontologo();
  }
  private getPaciente() {
    this.pacienteService.get().subscribe(result => {
      this.pacientes = result;
      console.log(result);
    });
  }
  private getOdontologo() {
    this.odontologoService.get().subscribe(result => {
      this.odontologos = result;
      console.log(result);
    });
  }
  seleccionar(e):void {
    console.log("asdasdsad");
    console.log(e.target.value);
  }

  add() {
    console.log(this.cita);
    this.citaService.post(this.cita).subscribe((p) => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Cita registrada!';
        this.cita = p;
      }
    });
  }

}
