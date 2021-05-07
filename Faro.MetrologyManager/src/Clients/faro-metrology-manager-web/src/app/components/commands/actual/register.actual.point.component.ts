import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../../models/user';
import { ActualPointsService } from '../../../services/actual.point.service';
import { AlertService } from '../../../services/alert.service';

@Component({
  moduleId: module.id,
  templateUrl: 'register.actual.point.component.html'
})

export class RegisterActualPointComponent implements OnInit {
  model: any = {};
  loading = false;
  currentUser: User;
  public nominalPointId: any;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private actualPointsService: ActualPointsService,
    private alertService: AlertService) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser') || "");
  }
    ngOnInit(): void {
      this.nominalPointId = this.route.snapshot.paramMap.get('id') ?? "";
    }

  register() {
    this.loading = true;
    this.model.executionUser = this.currentUser.name;
    this.model.nominalPointId = this.nominalPointId;
    this.actualPointsService.create(this.model)
      .subscribe(
        data => {
          this.alertService.success('Registration successful', true);
          this.router.navigate([`/points/nominals/${this.nominalPointId}/actuals`]);
          this.loading = false;
        },
        error => {
          this.alertService.error(error._body);
          this.loading = false;
        });

  }
}
