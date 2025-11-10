import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router, UrlTree } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean | UrlTree {
    const expectedRoles: string[] = (route.data?.['roles'] as string[] || []).map(r => r.toLowerCase().trim());

    const userRole = this.authService.getRole()?.toLowerCase().trim() || '';
    console.log(userRole)
    console.log(expectedRoles)

    if (!userRole || !expectedRoles.includes(userRole)) {
      console.log('here1')
      return this.router.parseUrl('/login');
    }
      console.log('here')

    return true;
  }
}
