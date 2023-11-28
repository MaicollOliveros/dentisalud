import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { GestionarConsultorioComponent } from "./consultorio/gestionar-consultorio/gestionar-consultorio.component";
import { AgendaComponent } from "./consultorio/agenda/agenda.component";
import { HoyComponent } from "./consultorio/agenda/hoy/hoy.component";
import { RegistroCienteComponent } from "./paciente/registro-cliente/registro-ciente.component";
import { InformesComponent } from "./informes/informes.component";
import { RegistroCitaComponent } from "./consultorio/registro-cita/registro-cita.component";
import { LoginComponent } from './login/login.component';
import { FooterComponent } from './footer/footer.component';
import { FiltroPersonaPipe } from './paciente/pipe/filtro-persona.pipe';
import { PacienteService } from "./services/PacienteService";
import { GestionarRecepcionistaComponent } from './Admin/gestionar-recepcionista/gestionar-recepcionista.component';
import { GestionarTratamientoComponent } from './Admin/gestionar-tratamiento/gestionar-tratamiento.component';
import { RecepcionistaService } from "./services/recepcionista.service";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { ConsultaPacienteComponent } from './paciente/consulta-paciente/consulta-paciente.component';
import { JwtInterceptor } from "./services/jwt.interceptor";
import { AuthGuard } from "./services/auth.guard";
import { RegistrarOdontologoComponent } from "./odontologo/registrar-odontologo/registrar-odontologo.component";
import { ConsultarOdontologoComponent } from "./odontologo/consultar-odontologo/consultar-odontologo.component";
import { ConsultarRecepcionistaComponent } from './Admin/consultar-recepcionista/consultar-recepcionista.component';
import { ConsultarTratamientoComponent } from './Admin/consultar-tratamiento/consultar-tratamiento.component';
import { RegistrarUsuarioComponent } from './usuario/registrar-usuario/registrar-usuario.component';
import { ConsultarUsuarioComponent } from './usuario/consultar-usuario/consultar-usuario.component';
import { RegistrarTratamientoComponent } from './tratamiento/registrar-tratamiento/registrar-tratamiento.component';
import { TratramientoConsultarComponent } from './tratamiento/tratramiento-consultar/tratramiento-consultar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GestionarConsultorioComponent,
    
    AgendaComponent,
    HoyComponent,
    RegistroCienteComponent,
    InformesComponent,
    RegistroCitaComponent,
    LoginComponent,
    FooterComponent,
    FiltroPersonaPipe,
    GestionarRecepcionistaComponent,
    AlertModalComponent,
    ConsultaPacienteComponent,
    RegistrarOdontologoComponent,
    ConsultarOdontologoComponent,
    ConsultarRecepcionistaComponent,
    ConsultarTratamientoComponent,
    RegistrarUsuarioComponent,
    ConsultarUsuarioComponent,
    RegistrarTratamientoComponent,
    TratramientoConsultarComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(
      [
        { path: "", component: HomeComponent, pathMatch: "full" },
        {
          path: "registrar-user",
          component: RegistrarUsuarioComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "consultar-user",
          component: ConsultarUsuarioComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "registrar-recepcionista",
          component: GestionarRecepcionistaComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "consultar-recepcionista",
          component: ConsultarRecepcionistaComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "registrar-tratamiento",
          component: RegistrarTratamientoComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "consultar-tratamiento",
          component: TratramientoConsultarComponent,
          canActivate: [AuthGuard]
        },
        // PENDIENTE COMPONENTE CONSULTAR TRATAMIENTOS
        {
          path: "agenda",
          component: AgendaComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "agenda/hoy",
          component: HoyComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "registrar-paciente",
          component: RegistroCienteComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "consultar-paciente",
          component: ConsultaPacienteComponent,
          canActivate: [AuthGuard]
        },
        {//BORRARLO
          path: "informes",
          component: InformesComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "consultorio/registro-cita",
          component: RegistroCitaComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "registrar-odontologo",
          component: RegistrarOdontologoComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "consultar-odontologo",
          component: ConsultarOdontologoComponent,
          canActivate: [AuthGuard]
        },
        {
          path: "login",
          component: LoginComponent,
        },
      ],
      { relativeLinkResolution: "legacy" }
    ),
    NgbModule,
  ],
  entryComponents:[AlertModalComponent],
  providers: [
    PacienteService,
    RecepcionistaService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
