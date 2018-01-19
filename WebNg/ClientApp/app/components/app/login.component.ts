import { DataService } from '././../../services/data.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Http, Headers } from "@angular/http";
import 'rxjs/add/operator/map';


/**
 * @title Inputs in a form
 */
@Component({
    // selector: 'input-form-example',
    templateUrl: 'login.component.html',
    // styleUrls: ['input-form-example.css'],
})
export class LoginComponent implements OnInit {
   
    errorMessage: string;
    sec: any = {
        user: "",
        password: ""
    };
    returnUrl: string;

    constructor(private router: Router,
        private route: ActivatedRoute,
        private http: Http,
        private dataService: DataService
    ) {
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/rental';
    }

    ngOnInit(): void {
      
    }
   
    onSubmit() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');        
         this.http.post('api/security/login', this.sec, { headers })
            .map(res => res.json())
             .subscribe(res => {
                 alert(this.returnUrl);
                this.router.navigate([this.returnUrl]);
            }, (err) => {
                //alert(JSON.stringify(err))
                this.errorMessage = err._body;
            });

    }
}
