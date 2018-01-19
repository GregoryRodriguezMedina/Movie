import { Component } from '@angular/core';
import { AuthService } from "../../services/AuthService";
//import { CookieService } from 'angular2-cookie/services/cookies.service';


@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    constructor(private auth: AuthService) { }

    isLogin() {
        // return this.auth.isLoggedIn; 
        return true;
        //  return (this.cookieService.get('currentUser'));//localStorage.getItem('currentUser'));
    }
}
