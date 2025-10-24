import { ActivatedRouteSnapshot, CanActivate,  Router,  } from '@angular/router';
import { AuthService } from '../services/auth.service';

export class  RoleGuard implements CanActivate {
  constructor(private authService : AuthService, private router : Router){}

  canActivate(route: ActivatedRouteSnapshot): boolean{
    const expectedRoles = route.data['roles'] as Array<string>;
    const userRole = this.authService.getUserRole();

    if(!userRole || !expectedRoles.includes(userRole)){
      this.router.navigate(['/login']);
      return false;
    }

    return true;
  } 
}
