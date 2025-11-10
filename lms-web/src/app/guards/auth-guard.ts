import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router, UrlTree } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean | UrlTree {
    if (!this.authService.isAuthenticated()) {
      return this.router.parseUrl('/login');
    }

    const expectedRoles: string[] = route.data?.['roles']?.map((r: string) => r.toLowerCase()) || [];
    const userRole = this.authService.getRole()?.toLowerCase() || '';

    if (expectedRoles.length > 0 && !expectedRoles.includes(userRole)) {
      return this.router.parseUrl('/login');
    }

    return true;
  }
}
