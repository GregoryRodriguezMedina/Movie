import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { DataService } from "../../services/data.service";

@Injectable()
export class AuthGuard implements CanActivate {
    valid: boolean;
    constructor(private router: Router, private dataService: DataService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        this.dataService.getSession()
            .subscribe(r => this.valid = r);

        if (this.valid) {
            // logged in so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}