import { Injectable } from '@angular/core';
import { DataService } from "./data.service";

@Injectable()
export class AuthService {
    data: any;

    constructor(private dataService: DataService) { }
    /*
    get isLoggedIn() {
       this.dataService.getSession()
            .subscribe(b => this.data = b);       

        return this.data || false;
    }
    */
    get isLoggedIn() {
        return true;
    }
    get isSuperAdmin() {
        return true;
    }
}