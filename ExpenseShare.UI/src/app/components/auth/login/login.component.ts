import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequestDto } from 'src/app/models/login-request-dto';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userCredentials: LoginRequestDto = {
    email: '',
    password: ''
  };

  isAdmin: boolean = false;

  constructor(private authService: AuthService, private router: Router) {
  }

  ngOnInit(): void {
    this.isAdmin = this.authService.isAdmin();
    if(this.authService.isAuthenticated())
      this.redirect();
  }

  redirect() {
    if (this.isAdmin === true) {
      this.router.navigate(['admin']);
    }
    else 
      this.router.navigate(['user-details']);
  }


  userLogin() {
    if (this.userCredentials.email && this.userCredentials.password) {
      this.authService.login(this.userCredentials)
        .subscribe({
          next: (response) => {
            console.log(response);
            if (response.token !== null) {
              console.log("Success Login");
              localStorage.setItem('user', JSON.stringify(response));
              this.isAdmin = response.isAdmin;

              this.router.navigate(['nav']).then(() => {
                window.location.reload();
              });

              this.redirect();
            }
            else {
              alert("Invalid Credentials");
              this.userCredentials.email = '';
              this.userCredentials.password = '';
            }
          },
          error: (error) => {
            alert("Invalid Credentials");
            this.userCredentials.password = '';
            // console.log("Invalid Credentials");
          }
        })
    }
  }
}
