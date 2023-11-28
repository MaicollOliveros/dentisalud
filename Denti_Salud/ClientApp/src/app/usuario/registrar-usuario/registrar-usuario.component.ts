import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-registrar-usuario',
  templateUrl: './registrar-usuario.component.html',
  styleUrls: ['./registrar-usuario.component.css']
})
export class RegistrarUsuarioComponent implements OnInit {

  formGroup: FormGroup;
  users: User[]
  user: User = {
    userName: '',
    name: '',
    password: '',
    email: '',
    role: '',
  }
  searchText: string
  constructor(
    private userService: UserService,
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private handleError: HandleHttpErrorService,
  ) {}

  ngOnInit(): void {
    this.buildForm();
  }
  buildForm() {
    this.formGroup = this.formBuilder.group({
      userName: ['', Validators.required],
      name: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required],
      role: ['', Validators.required],
    });
  }

  add() {
    this.user = this.formGroup.value;
    this.userService.post(this.user).subscribe((p) => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = 'Resultado Operación'
        messageBox.componentInstance.message =
          'Usuario registrado exitosamente! :)'
        this.user = p
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
