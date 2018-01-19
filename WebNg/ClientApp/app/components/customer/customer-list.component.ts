import { DataService } from '././../../services/data.service';
import { CustomerRequest } from '././../../models/models';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-customer-list',
    templateUrl: './customer-list.component.html',
    //styleUrls: ['./vehicle-list.component.scss']
})
export class CustomerListComponent implements OnInit {
    private readonly PAGE_SIZE = 15;
    
    queryResult: any = {
        itemCount: 0,
        items: []
    };
   
    query: any = {
        per_page: this.PAGE_SIZE,
        page: 1
    };

    constructor(private customerService: DataService) { }

    ngOnInit() {       
        this.populateVehicles();       
    }

    onFilterChange() {
        this.query.page = 1;       

        this.populateVehicles();
    }

    private populateVehicles() {
        this.customerService.getCustomers(this.query)
            //.map(r => r.json() as CustomerRequest[])
            .subscribe(queryResult => this.queryResult = queryResult);       
    }

    resetFilter() {        
        this.query = {
            page: 1,
            per_page: this.PAGE_SIZE
        };
        this.populateVehicles();
    }    
}
