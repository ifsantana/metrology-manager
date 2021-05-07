import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { Blocker } from './Blocker';
import { AlertComponent } from './components/alert.component';
import { RegisterNominalPointComponent } from './components/commands/nominal/register.nominal.point.componente';
import { HomeComponent } from './components/home.component';
import { LoginComponent } from './components/login.component';
import { ListActualPointsComponent } from './components/queries/actual/list.actual.points.component';
import { ListNominalPointsComponent } from './components/queries/nominal/list.nominal.points.component';
import { Notifier } from './notifier';
import { ActualPointsService } from './services/actual.point.service';
import { AlertService } from './services/alert.service';
import { AuthenticationGuard } from './services/authentication.guard';
import { AuthenticationService } from './services/authentication.service';
import { NominalPointsService } from './services/nominal.point.service';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { RegisterActualPointComponent } from './components/commands/actual/register.actual.point.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    AlertComponent,
    ListNominalPointsComponent,
    ListActualPointsComponent,
    RegisterNominalPointComponent,
    RegisterActualPointComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserModule,
    routing,
    NgxMaskModule.forRoot(),
  ],
  providers: [
    AlertService,
    AuthenticationGuard,
    AuthenticationService,
    Blocker,
    Notifier,
    NominalPointsService,
    ActualPointsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
