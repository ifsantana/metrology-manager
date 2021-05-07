import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../services/alert.service';
import { AuthenticationService } from '../services/authentication.service';
import { User } from "../models/user";

@Component({
  moduleId: module.id,
  templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
  model: any = {};
  loading = false;
  returnUrl: any;
  currentUser!: User;

  constructor(private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService, private alertService: AlertService) {
    
  }

  ngOnInit() {

    // reset login status
    this.authenticationService.logout(this.currentUser);

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login() {
    this.loading = true;
    let success = this.authenticationService.login(this.model.email, this.model.password);
    if (success) {
          this.alertService.success('Login successful', true);
          this.router.navigate([this.returnUrl]);
        }
        else {
          this.alertService.error("errorrrr");
          this.loading = false;
      };
  }
}
