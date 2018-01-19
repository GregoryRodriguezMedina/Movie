import { DataService } from '././../../services/data.service';
import { CustomerRequest } from '././../../models/models';
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
    templateUrl: 'customer-form.component.html',
    // styleUrls: ['input-form-example.css'],
})
export class CustomerFormComponent implements OnInit {
    customer: CustomerRequest =
    {
        customerId: 0,
        firstName: '',
        lastName: '',
        suffix: '',
        address: '',
        mobilPhone: '',
        homePhone: '',
        email: ''
    };

    title = 'Nuevo Registro';
    errorMessage: string;
    id: number = 0;
    edit: boolean = false;
   // api: string = 'api/customer';

    constructor(private router: Router,
        private route: ActivatedRoute,
        private http: Http,
        private customerService: DataService
    ) { }

    ngOnInit(): void {
        this.route.params.subscribe((params: Params) => {
            this.id = + params['id'];
            if (this.id !== 0 && !isNaN(this.id)) {
                // Modo edit
                this.edit = true;
                // buscar el registro
                this.getCustomer();
            }
        });
    }

    getCustomer() {
        //alert(this.id);
        this.customerService.getCustomer(this.id)
            .subscribe(p => this.onCustomerRetrieved(p),
            error => this.errorMessage = <any>error
            );
    }

    onCustomerRetrieved(customer: CustomerRequest) {
        this.customer = customer;
        //console.log(JSON.stringify(customer));
        this.title = `Modificar Registro  ${this.customer.lastName + ' ' + customer.firstName}`;
    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/customer']);
    }

    onSubmit() {
        // alert(`customer : ${JSON.stringify(this.customer)}`);
        if (confirm("Seguro que desea procesar?")) {
            let headers = new Headers();
            headers.append('Content-Type', 'application/json');

            var $result = (this.edit) ? this.http.put('api/customer/' + this.customer.customerId, this.customer, { headers })
                : this.http.post('api/customer', this.customer, { headers });


               
            $result .map(res => res.json())
                    .subscribe(res => {
                        this.router.navigate(['/customer']);
                    }, (err) => {
                        this.errorMessage = <any>err;
                    });           

            //if (this.edit) {

            //    this.http.put('api/customer/' + this.customer.customerId, this.customer, { headers })
            //        .map(res => res.json())
            //        .subscribe(res => {
            //            this.router.navigate(['/customer']);
            //        }, (err) => {
            //            this.errorMessage = <any>err;
            //        });
            //} else {
            //    this.http.post('api/customer', this.customer, { headers })
            //        .map(res => res.json())
            //        .subscribe(res => {
            //        this.router.navigate(['/customer']);
            //    }, (err) => {
            //        this.errorMessage = <any>err;
            //    });
            //}
        }

         //if (this.edit)
         //    this.customerService.update(this.customer);
         //else this.customerService.create(this.customer);
    }
}
