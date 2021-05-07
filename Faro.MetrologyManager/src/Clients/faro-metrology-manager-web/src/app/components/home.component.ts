import { Component, OnDestroy, OnInit } from '@angular/core';
import { User } from '../models/user';
import { AuthenticationService } from "../services/authentication.service";
import { Router } from "@angular/router";

@Component({
  moduleId: module.id,
  templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit, OnDestroy {
  currentUser: User;
  header: any;

  constructor(private authenticationService: AuthenticationService, private router: Router) {
    let user = localStorage.getItem('currentUser');
    this.currentUser = JSON.parse(user || "");
  }

  ngOnInit() {

  }

  ngOnDestroy(): void {

  }
}
