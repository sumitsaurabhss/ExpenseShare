import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const adminGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const service = inject(AuthService);
  if (service.isAdmin()) return true;
  else {
    alert("You don't have admin access. Access denied.");
    router.navigate(['']);
    return false;
  }
}; 