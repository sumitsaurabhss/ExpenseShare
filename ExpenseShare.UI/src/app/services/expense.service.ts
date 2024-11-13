import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExpenseDetailsDto } from '../models/expense-details-dto';
import { ExpenseDto } from '../models/expense-dto';
import { SettleDto } from '../models/settle-dto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  private apiUrl = environment.baseUrl + 'api/expense';

  constructor(private http: HttpClient) { }

  addExpense(expenseDto: ExpenseDto): Observable<any> {
    return this.http.post(`${this.apiUrl}`, expenseDto);
  }

  getExpenseDetails(id: string): Observable<ExpenseDetailsDto> {
    return this.http.get<ExpenseDetailsDto>(`${this.apiUrl}/${id}`);
  }

  settleExpense(settleDto: SettleDto): Observable<any> {
    console.log(`From Service: ${settleDto}`);
    return this.http.post(`${this.apiUrl}/settle`, settleDto);
  }
}
