import { DataService } from '././../../services/data.service';
import { RentalRequest, KeyNamePair, CustomerRequest, movieRequest } from '././../../models/models';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Http, Headers } from "@angular/http";
import 'rxjs/add/operator/map';
import { IMyDpOptions } from 'mydatepicker';


/**
 * @title Inputs in a form
 */
@Component({
    // selector: 'input-form-example',
    templateUrl: 'rental-form.component.html',
    // styleUrls: ['input-form-example.css'],
})
export class RentalFormComponent implements OnInit {    
    private readonly PAGE_SIZE = 15;

    public myDatePickerOptions: IMyDpOptions = {       
        dateFormat: 'dd/mm/yyyy',
    };

    movies: any[];
    customers: any[];
    //movies.pust(movie);

    rental: any = {
        customerId: 0,
        movieId: 0,
        dateTo: "",
        movies: []
    };

    titleDesc = 'Alquilar';
    errorMessage: string;
    id: number = 0;
    edit: boolean = false;
   // api: string = 'api/rental';

    constructor(private router: Router,
        private route: ActivatedRoute,
       private http: Http,
       private dataService: DataService
    ) { }

    ngOnInit(): void {
        this.dataService.getCustomers({
            per_page: this.PAGE_SIZE,
            page: 1
        }).subscribe(result => this.customers = result.items);


        this.dataService.getMovies({
            per_page: this.PAGE_SIZE,
            page: 1
        }).subscribe(result => this.movies = result.items);
    }
    private listMovie: number[] = [];

    private exists(id: number) {
        let len = this.listMovie.length;
        let ex = false;

        for (var i = 0; i <= len; i++) {
            if (this.listMovie[i] === id) {
                ex = true;
                break;
            }
        }

        return ex;
    }

   // selectedMovie: any;

    onSelect(movie: any) {
      //  this.selectedMovie = movie;

        let id = movie.movieId;
        let exists = this.exists(id);       
        if (!exists) {
            this.listMovie.push(id);
        }
        else {
            let index = this.listMovie.indexOf(id);           
            this.listMovie.splice(index, 1);
        }
    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/rental']);
    }

    onSubmit() {                
        if (this.listMovie.length <= 0) {
            alert("Debe agregar almenos una pelicula al carrito.");
            return;
        }
        //alert(JSON.stringify(this.rental.dateTo.date));
        let date = this.rental.dateTo.date;
        let d = new Date(date.year + "-" + date.month + "-" + date.day);
        /*
        if (Date.now < d) {
            alert("La fecha de entrega no debe ser menor a la fecha actual.");
            return;
        }
        */
        let rentalSend: any = {
            dateTo: d,
            movies: this.listMovie,
            customerId: this.rental.customerId
        };

        //*
        if (confirm("Seguro que desea procesar?")) {
            let headers = new Headers();
            headers.append('Content-Type', 'application/json');
           // alert(JSON.stringify(rentalSend))
            this.http.post('api/rental', rentalSend, { headers })
                .map(res => res.json())
                    .subscribe(res => {
                        this.router.navigate(['/rental']);
                }, (err) => {
                    //alert(JSON.stringify(err))
                        this.errorMessage = err._body;
                    });                      
        }
        //*/
         //if (this.edit)
         //    this.rentalService.update(this.rental);
         //else this.rentalService.create(this.rental);
    }
}
