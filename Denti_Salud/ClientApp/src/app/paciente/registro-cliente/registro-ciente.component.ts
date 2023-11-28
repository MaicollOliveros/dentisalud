import { Component, OnInit } from '@angular/core';
import { PacienteService } from 'src/app/services/PacienteService';
import { Paciente } from '../../models/Paciente';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';


@Component({
  selector: 'app-registro-ciente',
  templateUrl: './registro-ciente.component.html',
  styleUrls: ['./registro-ciente.component.css']
})
export class RegistroCienteComponent implements OnInit {
  formGroup: FormGroup;
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
  constructor(private pacienteService:PacienteService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

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
    });
  }
  
  add() {
    this.paciente = this.formGroup.value;
    this.pacienteService.post(this.paciente).subscribe((p) => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Paciente registrado exitosamente! :)';
        this.paciente = p;
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