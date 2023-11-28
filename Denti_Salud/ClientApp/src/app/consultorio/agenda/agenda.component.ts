import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-agenda",
  templateUrl: "./agenda.component.html",
  styleUrls: ["./agenda.component.css"],
})
export class AgendaComponent implements OnInit {
  opcion: number = 0;
  constructor() {}

  ngOnInit(): void {}
  opcionHoy() {
    this.opcion = 1;
  }
  opcionCalendario() {
    this.opcion = 0;
  }
}
