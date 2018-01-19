import { CustomerRequest } from './../models/models';
import { Injectable, Inject } from '@angular/core';

import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

//import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class DataService {
   
    private readonly customerBaseUrl: string;
    private readonly movieBaseUrl: string;
    private readonly rentalBaseUrl: string;
    private readonly accountBaseUrl: string;

    //private readonly BaseUrl: string;
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string){
        this.customerBaseUrl = baseUrl + 'api/customer'; 
        this.movieBaseUrl = baseUrl + 'api/movie';   
        this.rentalBaseUrl = baseUrl + 'api/rental'; 
        this.accountBaseUrl = baseUrl + 'api/security'; 
    }

    getSession() {
        return this.http.get(this.accountBaseUrl + '/session/')
            .map(res => res.json());
    }


    create(customer: CustomerRequest){
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.post(this.customerBaseUrl, customer, { headers })
            .map(res => res.json());  
    }

    update(customer: CustomerRequest){        
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.put(this.customerBaseUrl + '/' + customer.customerId, customer, { headers})
            .map(res => res.json());  
    }

    delete(id: number) {
        return this.http.delete(this.customerBaseUrl + '/' + id)
            .map(res => res.json());  
    }

    getCustomer(id: number) {
        return this.http.get(this.customerBaseUrl + '/'+ id)
            .map(res => res.json());  
    }

    getCustomers(filter: any) {
        return this.http.get(this.customerBaseUrl + '?' + this.toqueryString(filter))
            .map(res => res.json());  
    }

    getMovie(id: number) {
        return this.http.get(this.movieBaseUrl + '/' + id)
            .map(res => res.json());
    }

    getMovies(filter: any) {
        return this.http.get(this.movieBaseUrl + '?' + this.toqueryString(filter))
            .map(res => res.json());
    }

    getRental(id: number) {
        return this.http.get(this.rentalBaseUrl + '/' + id)
            .map(res => res.json());
    }

    getRentals(filter: any) {
        return this.http.get(this.rentalBaseUrl + '?' + this.toqueryString(filter))
            .map(res => res.json());
    }


    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

    private toqueryString(obj: any) {
        //prop = value
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined && value !== '') {
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
            }
        }

        return parts.join("&");
    }
}
