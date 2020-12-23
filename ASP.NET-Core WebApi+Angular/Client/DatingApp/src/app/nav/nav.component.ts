import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  
  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe((user: User) => {
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.accountService.setCurrentUser(user);
        this.router.navigateByUrl('/members');
      }
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/");
  }
}
