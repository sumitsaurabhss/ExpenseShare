import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ExpenseService } from 'src/app/services/expense.service';
import { GroupService } from 'src/app/services/group.service';
import { ExpenseDto } from 'src/app/models/expense-dto';
import { GroupMembersDto } from 'src/app/models/group-members-dto';

@Component({
  selector: 'app-create-expense',
  templateUrl: './create-expense.component.html',
  styleUrls: ['./create-expense.component.css']
})
export class CreateExpenseComponent implements OnInit {
  expenseDto: ExpenseDto = {
    description: '',
    amount: 0,
    groupId: '',
    paidByMemberId: '',
    splitAmongMemberIds: []
  };
  groupMembers: GroupMembersDto = { groupId: '', memberIds: [], memberNames: [] };
  selectedMembers: { id: string, name: string, selected: boolean }[] = [];

  constructor(private expenseService: ExpenseService,
    private route: ActivatedRoute,
    private groupService: GroupService,
    private router: Router) { }

  ngOnInit(): void {
    this.expenseDto.groupId = this.route.snapshot.paramMap.get('groupId')!;
    if (this.expenseDto.groupId) {
      this.groupService.getGroupMembers(this.expenseDto.groupId).
        subscribe({
          next: (groupMembers) => {
            this.groupMembers = groupMembers;
            this.selectedMembers = groupMembers.memberIds.map((id, index) => ({
              id: id,
              name: groupMembers.memberNames[index],
              selected: false
            }));
          },
          error: (error) => {
            console.error('Error fetching group details', error);
          }
        });
    }
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.expenseDto.splitAmongMemberIds = this.selectedMembers
        .filter(member => member.selected)
        .map(member => member.id);

      if(this.expenseDto.splitAmongMemberIds.length < 1)
        alert("An expense should have at least 1 member.");
      else {
        this.expenseService.addExpense(this.expenseDto).
        subscribe({
          next :(response) => {
            alert('Expense added successfully.');
            form.resetForm();
            //this.router.navigate
          },
          error :(error) => {
            console.error('Error creating expense', error);
            alert('Error creating expense');
          }
        });
      }
    }
  }

  // onGroupIdChange(groupId: string): void {
  //   if (groupId) {
  //     this.groupService.getGroupMembers(groupId).
  //     subscribe({
  //       next :(groupMembers) => {
  //         this.groupMembers = groupMembers;
  //         this.selectedMembers = groupMembers.memberIds.map((id, index) => ({
  //           id: id,
  //           name: groupMembers.memberNames[index],
  //           selected: false
  //         }));
  //       },
  //       error :(error) => {
  //         console.error('Error fetching group members', error);
  //       }
  //     });
  //   }
  // }
}
