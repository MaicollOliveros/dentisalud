import { Component, OnInit } from '@angular/core';
import { Cita } from 'src/app/models/cita';
import { CitaService } from 'src/app/services/cita.service';

@Component({
  selector: 'app-hoy',
  templateUrl: './hoy.component.html',
  styleUrls: ['./hoy.component.css']
})
export class HoyComponent implements OnInit {

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
  constructor(private citaService: CitaService) { }

  ngOnInit(): void {
    
    this.citaService.get().subscribe(result => {
      this.citas = result;
      console.log(result);
    });
  }

}
