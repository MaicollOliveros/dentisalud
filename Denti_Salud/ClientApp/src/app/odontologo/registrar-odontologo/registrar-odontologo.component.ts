import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Odontologo } from 'src/app/models/odontologo';
import { OdontologoService } from 'src/app/services/odontologo.service';

@Component({
  selector: 'app-registrar-odontologo',
  templateUrl: './registrar-odontologo.component.html',
  styleUrls: ['./registrar-odontologo.component.css']
})
export class RegistrarOdontologoComponent implements OnInit {
  formGroup: FormGroup;
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
  constructor(private odontologoService:OdontologoService,
    private modalService: NgbModal,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
  }
  private buildForm() {
    this.formGroup = this.formBuilder.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      tipoIdentificacion: ['', Validators.required],
      identificacion: ['', Validators.required],
      correo: ['', Validators.required],
      genero: ['', Validators.required],
      direccion: ['', Validators.required],
      telefono: ['', Validators.required],
      salario: [0, Validators.required],
      cargo: ['', Validators.required],
    });
  }
  add() {
    this.odontologo = this.formGroup.value;
    this.odontologoService.post(this.odontologo).subscribe((p) => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Odontologo registrado exitosamente! :)';
        this.odontologo = p;
      }
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  get control() {
    return this.formGroup.controls;
  }

}
