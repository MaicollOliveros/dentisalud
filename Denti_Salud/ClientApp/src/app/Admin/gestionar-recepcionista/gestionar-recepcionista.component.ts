import { Component, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component'
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service'
import { Recepcionista } from 'src/app/models/recepcionista'
import { RecepcionistaService } from 'src/app/services/recepcionista.service'

@Component({
  selector: 'app-gestionar-recepcionista',
  templateUrl: './gestionar-recepcionista.component.html',
  styleUrls: ['./gestionar-recepcionista.component.css'],
})
export class GestionarRecepcionistaComponent implements OnInit {
  formGroup: FormGroup;
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
    private formBuilder: FormBuilder,
    private handleError: HandleHttpErrorService,
  ) {}

  ngOnInit(): void {
    this.buildForm();
  }
  buildForm() {
    this.formGroup = this.formBuilder.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      tipoIdentificacion: ['', Validators.required],
      identificacion: ['', Validators.required],
      salario: ['', Validators.required],
      genero: ['', Validators.required],
      telefono: ['', Validators.required],
      direccion: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email]],
    });
  }

  add() {
    this.recepcionista = this.formGroup.value;
    this.recepcionistaService.post(this.recepcionista).subscribe((p) => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = 'Resultado Operación'
        messageBox.componentInstance.message =
          'Recepcionista registrada exitosamente! :)'
        this.recepcionista = p
      }
    })
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
