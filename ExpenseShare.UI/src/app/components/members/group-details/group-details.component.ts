import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GroupService } from 'src/app/services/group.service';
import { GroupDetailsDto } from 'src/app/models/group-details-dto';

@Component({
  selector: 'app-group-details',
  templateUrl: './group-details.component.html',
  styleUrls: ['./group-details.component.css']
})
export class GroupDetailsComponent implements OnInit {
  groupId: string | null = null;
  groupDetails: GroupDetailsDto | null = null;

  constructor(
    private route: ActivatedRoute,
    private groupService: GroupService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.groupId = this.route.snapshot.paramMap.get('id');
    if (this.groupId) {
      this.groupService.getGroupDetails(this.groupId).
      subscribe({
        next :(groupDetails) => {
          this.groupDetails = groupDetails;
        },
        error :(error) => {
          console.error('Error fetching group details', error);
        }
      });
    }
  }

  goToExpense(expenseId: string): void {
    this.router.navigate([`/expense-details/${expenseId}`]);
  }

  createExpense(): void {
    this.router.navigate([`/create-expense/${this.groupId}`]);
  }

  deleteGroup(): void {
    if (this.groupId) {
      this.groupService.deleteGroup(this.groupId)
        .subscribe({
          next: () => {
            alert('Group deleted successfully.');
            this.router.navigate(['']);
          },
          error: (error) => {
            console.error('Error deleting group', error);
            alert('Error deleting group');
          }
        });
    }
  }
}
