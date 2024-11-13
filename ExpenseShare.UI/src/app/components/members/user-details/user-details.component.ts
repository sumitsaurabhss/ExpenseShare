import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';
import { UserDto } from 'src/app/models/user-dto';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  userDetails: UserDto | null = null;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadUserDetails();
  }

  public loadUserDetails(): void {
    const userId = this.authService.getUserId();
    console.log(userId);
    this.userService.getUserDues(userId)
    .subscribe({
      next: (user: UserDto) => {
        this.userDetails = user;
      },
      error: (error) => {
        console.error('Error fetching user details', error);
      }
    });
  }

  goToGroup(groupId: string): void {
    this.router.navigate([`/group-details/${groupId}`]);
  }

  createGroup(): void {
    this.router.navigate(['/create-group']);
  }
}
