import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { Tratamiento } from 'src/app/models/tratamiento';
import { TratamientoService } from 'src/app/services/tratamiento.service';

@Component({
  selector: 'app-registrar-tratamiento',
  templateUrl: './registrar-tratamiento.component.html',
  styleUrls: ['./registrar-tratamiento.component.css']
})
export class RegistrarTratamientoComponent implements OnInit {

  formGroup: FormGroup;
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
    private formBuilder: FormBuilder,
    private handleError: HandleHttpErrorService,
  ) {}

  ngOnInit(): void {
    this.buildForm();
  }
  buildForm() {
    this.formGroup = this.formBuilder.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
    });
  }

  add() {
    this.tratamiento = this.formGroup.value;
    this.tratamientoService.post(this.tratamiento).subscribe((p) => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = 'Resultado Operación'
        messageBox.componentInstance.message =
          'Tratamiento registrado exitosamente! :)'
        this.tratamiento = p
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
