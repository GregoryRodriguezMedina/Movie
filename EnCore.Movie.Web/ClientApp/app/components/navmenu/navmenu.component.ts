import { Component } from '@angular/core';
//import { CookieService } from 'angular2-cookie/services/cookies.service';


@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    //constructor(private cookieService: CookieService) { }

    isLogin() {
        return true;
        //  return (this.cookieService.get('currentUser'));//localStorage.getItem('currentUser'));
    }
}
