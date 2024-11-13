import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExpenseService } from 'src/app/services/expense.service';
import { AuthService } from 'src/app/services/auth.service';
import { ExpenseDetailsDto } from 'src/app/models/expense-details-dto';
import { SettleDto } from 'src/app/models/settle-dto';

@Component({
  selector: 'app-expense-details',
  templateUrl: './expense-details.component.html',
  styleUrls: ['./expense-details.component.css']
})
export class ExpenseDetailsComponent implements OnInit {
  expenseId: string | null = null;
  expenseDetails: ExpenseDetailsDto | null = null;
  settleDto: SettleDto = {
    id : '',
    paidByMemberId : ''
  }

  constructor(
    private route: ActivatedRoute,
    private expenseService: ExpenseService,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.expenseId = this.route.snapshot.paramMap.get('id');
    if (this.expenseId) {
      this.expenseService.getExpenseDetails(this.expenseId)
      .subscribe({
        next :(expenseDetails) => {
          this.expenseDetails = expenseDetails;
        },
        error :(error) => {
          console.error('Error fetching expense details', error);
        }
      });
    }
  }

  settleExpense(): void {
    this.settleDto.paidByMemberId = this.authService.getUserId();
    console.log(`from component: ${this.settleDto.paidByMemberId}`);
    console.log(`from component: ${this.expenseDetails!.id}`);
    if (this.expenseDetails && this.settleDto.paidByMemberId) {
      this.settleDto.id = this.expenseDetails!.id;
      console.log(`from component: ${this.settleDto.id}`);
      this.expenseService.settleExpense(this.settleDto).
      subscribe({
        next :(response) => {
          alert('Expense settled successfully.');
          window.location.reload();
        },
        error: (error) => {
          console.error('Error settling expense', error);
          alert('Error settling expense');
        }
      });
    }
  }

  goToExpense(expenseId: string): void {
    this.router.navigate(['/expense-details', expenseId]);
  }
}
