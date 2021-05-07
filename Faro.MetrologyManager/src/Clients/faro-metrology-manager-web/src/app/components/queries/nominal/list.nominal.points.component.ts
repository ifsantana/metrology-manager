import { Component, OnInit } from '@angular/core';
import { NominalPoint } from '../../../models/nominal.point';
import { User } from '../../../models/user';
import { AlertService } from '../../../services/alert.service';
import { NominalPointsService } from '../../../services/nominal.point.service';

@Component({
  moduleId: module.id,
  templateUrl: 'list.nominal.points.component.html'
})
export class ListNominalPointsComponent implements OnInit {
  nominalPoints?: Array<NominalPoint> = [];
  currentUser: User;
  constructor(private nominalPointsService: NominalPointsService, private alertService: AlertService) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser') || "");
  }

  ngOnInit(): void {
    this.nominalPointsService.getAll().subscribe(
      items => {
        this.nominalPoints = items.data?.nominalPointsCollection ?? [];
        this.alertService.success('Load successful', true);
      },
      error => {
        this.alertService.error(error._body);
      });
  }

  delete(id: any) {

  }
}
