import { DataService } from '././../../services/data.service';
import { RentalRequest, KeyNamePair, CustomerRequest, movieRequest } from '././../../models/models';
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
    templateUrl: 'returned-form.component.html',
    // styleUrls: ['input-form-example.css'],
})
export class ReturnedFormComponent implements OnInit {    
    private id: number = 0;
    rental: any = {
        customer: {

        }
    };
    titleDesc = "Devolver";
    errorMessage: string;
   
    constructor(private router: Router,
        private route: ActivatedRoute,
       private http: Http,
       private dataService: DataService
    ) { }

    ngOnInit(): void {
        this.route.params.subscribe((params: Params) => {
            this.id = + params['id'];
            if (this.id !== 0 && !isNaN(this.id)) {               
                // buscar el registro
                this.getRental();
            }
        });
    }

    getRental() {
        //alert(this.id);
        this.dataService.getRental(this.id)
            .subscribe(p => (this.rental = p),
            error => this.errorMessage = <any>error
            );
    }
               

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/rental']);
    }

    onSubmit() {                        
        if (confirm("Seguro que desea procesar?")) {
            let headers = new Headers();
            headers.append('Content-Type', 'application/json');
           // alert(JSON.stringify(rentalSend))
            this.http.post('api/rental/returned/' + this.id, { headers })
                .map(res => res.json())
                    .subscribe(res => {
                        this.router.navigate(['/rental']);
                }, (err) => {
                    //alert(JSON.stringify(err))
                        this.errorMessage = err._body;
                    });                      
        }
       
    }
}
