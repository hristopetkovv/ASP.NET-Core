import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe((user: User) => {
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.accountService.setCurrentUser(user);
      }
    })
  }

  cancel() {
    this.cancelRegister.emit(false);    
  }

}