import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginRequestDto } from '../models/login-request-dto';
import { LoginResponseDto } from '../models/login-response-dto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = environment.baseUrl + 'api/auth';

  constructor(private http: HttpClient) { }

  login(loginRequest: LoginRequestDto): Observable<LoginResponseDto> {
    return this.http.post<LoginResponseDto>(`${this.apiUrl}/login`, loginRequest);
  }

  isAuthenticated(): boolean {
    const user = localStorage.getItem('user');
    return !!user;
  }

  isAdmin(): boolean {
    const user = JSON.parse(localStorage.getItem('user') || '{}');
    return user?.isAdmin || false;
  }

  getUserName(): string {
    const user = JSON.parse(localStorage.getItem('user') || '{}');
    return user?.name || '';
  }

  getUserId(): string {
    const user = JSON.parse(localStorage.getItem('user') || '{}');
    return user.id;
  }

  logout(): void {
    localStorage.removeItem('user');
  }
}
