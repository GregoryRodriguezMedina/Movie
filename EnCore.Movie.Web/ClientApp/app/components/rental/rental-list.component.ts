import { DataService } from '././../../services/data.service';
import { RentalResponse } from '././../../models/models';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-Rental-list',
    templateUrl: './Rental-list.component.html',
    //styleUrls: ['./vehicle-list.component.scss']
})
export class RentalListComponent implements OnInit {
    private readonly PAGE_SIZE = 15;
    
    queryResult: any = {
        itemCount: 0,
        items: []
    };
   
    query: any = {
        per_page: this.PAGE_SIZE,
        page: 1
    };

    constructor(private rentalService: DataService) { }

    ngOnInit() {       
        this.populateRentals();       
    }

    onFilterChange() {
        this.query.page = 1;       

        this.populateRentals();
    }

    private populateRentals() {
        this.rentalService.getRentals(this.query)            
            .subscribe(queryResult => this.queryResult = queryResult);       
    }

    resetFilter() {        
        this.query = {
            page: 1,
            per_page: this.PAGE_SIZE
        };
        this.populateRentals();
    }    
}
