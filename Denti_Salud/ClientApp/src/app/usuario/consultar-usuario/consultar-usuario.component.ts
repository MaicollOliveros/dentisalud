import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HandleHttpErrorService } from 'src/app/@base/handle-http-error.service';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-consultar-usuario',
  templateUrl: './consultar-usuario.component.html',
  styleUrls: ['./consultar-usuario.component.css']
})
export class ConsultarUsuarioComponent implements OnInit {
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
    private handleError: HandleHttpErrorService,
  ) {}

  ngOnInit(): void {
    this.get();
  }
  get() {
    this.userService.get().subscribe((result) => {
      this.users = result
      console.log(result)
    });
  }

}
