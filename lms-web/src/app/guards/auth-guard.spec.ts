import { TestBed } from '@angular/core/testing';
import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { AuthGuard } from './auth-guard';
import { AuthService } from '../services/auth.service';

describe('AuthGuard with role', () => {
  let guard: AuthGuard;
  let authServiceSpy: jasmine.SpyObj<AuthService>;
  let routerSpy: jasmine.SpyObj<Router>;
  let routeSnapshot: ActivatedRouteSnapshot;

  beforeEach(() => {
    authServiceSpy = jasmine.createSpyObj('AuthService', ['isAuthenticated', 'getRole']);
    routerSpy = jasmine.createSpyObj('Router', ['navigate']);

    TestBed.configureTestingModule({
      providers: [
        AuthGuard,
        { provide: AuthService, useValue: authServiceSpy },
        { provide: Router, useValue: routerSpy }
      ]
    });

    guard = TestBed.inject(AuthGuard);
    routeSnapshot = new ActivatedRouteSnapshot();
  });

  it('should allow route if authenticated and role matches', () => {
    authServiceSpy.isAuthenticated.and.returnValue(true);
    authServiceSpy.getRole.and.returnValue('instructor');
    routeSnapshot.data = { role: 'instructor' };

    expect(guard.canActivate(routeSnapshot)).toBeTrue();
  });

  it('should block route if authenticated but role does not match', () => {
    authServiceSpy.isAuthenticated.and.returnValue(true);
    authServiceSpy.getRole.and.returnValue('student');
    routeSnapshot.data = { role: 'instructor' };

    const result = guard.canActivate(routeSnapshot);
    expect(result).toBeFalse();
    expect(routerSpy.navigate).toHaveBeenCalledWith(['/login']);
  });

  it('should redirect to login if not authenticated', () => {
    authServiceSpy.isAuthenticated.and.returnValue(false);
    routeSnapshot.data = { role: 'instructor' };

    const result = guard.canActivate(routeSnapshot);
    expect(result).toBeFalse();
    expect(routerSpy.navigate).toHaveBeenCalledWith(['/login']);
  });
});
