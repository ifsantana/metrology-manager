import { Routes, RouterModule } from '@angular/router';
import { RegisterActualPointComponent } from './components/commands/actual/register.actual.point.component';
import { RegisterNominalPointComponent } from './components/commands/nominal/register.nominal.point.componente';
import { HomeComponent } from './components/home.component';
import { LoginComponent } from './components/login.component';
import { ListActualPointsComponent } from './components/queries/actual/list.actual.points.component';
import { ListNominalPointsComponent } from './components/queries/nominal/list.nominal.points.component';
import { AuthenticationGuard } from './services/authentication.guard';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthenticationGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'points/nominals', component: ListNominalPointsComponent },
  { path: 'points/nominals/register', component: RegisterNominalPointComponent },
  { path: 'points/nominals/:id/actuals', component: ListActualPointsComponent },
  { path: 'points/nominals/:id/actuals/register', component: RegisterActualPointComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
