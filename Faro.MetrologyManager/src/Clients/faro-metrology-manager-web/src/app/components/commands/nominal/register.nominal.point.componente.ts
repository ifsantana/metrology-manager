import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../models/user';
import { AlertService } from '../../../services/alert.service';
import { NominalPointsService } from '../../../services/nominal.point.service';

@Component({
  moduleId: module.id,
  templateUrl: 'register.nominal.point.component.html'
})

export class RegisterNominalPointComponent {
  model: any = {};
  loading = false;
  currentUser: User;
  constructor(
    private router: Router,
    private nominalPointsService: NominalPointsService,
    private alertService: AlertService) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser') || "");
  }

  register() {
    this.loading = true;
    this.model.executionUser = this.currentUser.name;
    this.nominalPointsService.create(this.model)
      .subscribe(
        data => {
          this.alertService.success('Registration successful', true);
          this.router.navigate(['/points/nominals']);
          this.loading = false;
        },
        error => {
          this.alertService.error(error._body);
          this.loading = false;
        });

  }
}
