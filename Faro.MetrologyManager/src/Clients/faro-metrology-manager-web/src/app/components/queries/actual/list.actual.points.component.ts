import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActuallPoint } from '../../../models/actual.point';
import { User } from '../../../models/user';
import { ActualPointsService } from '../../../services/actual.point.service';
import { AlertService } from '../../../services/alert.service';

@Component({
  moduleId: module.id,
  templateUrl: 'list.actual.points.component.html'
})
export class ListActualPointsComponent implements OnInit {
  actualPoints?: Array<ActuallPoint> = [];
  currentUser: User;
  public nominalPointId: any;
  constructor(private route: ActivatedRoute, private router: Router, private actualPointsService: ActualPointsService, private alertService: AlertService) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser') || "");
  }

  ngOnInit(): void {
    this.nominalPointId = this.route.snapshot.paramMap.get('id') ?? "";
    this.loadActualPoints();
  }

  private loadActualPoints() {
    this.actualPointsService.getByNominalPointId(this.nominalPointId).subscribe(items => {
      this.actualPoints = items.data?.actualPointsCollection ?? [];
    });
  }

  delete(id: any) {
    this.actualPointsService.delete(this.currentUser.name, id).subscribe(() => { this.loadActualPoints(); });
  }
}
