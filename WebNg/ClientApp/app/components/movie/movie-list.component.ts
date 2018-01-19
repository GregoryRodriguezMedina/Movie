import { DataService } from '././../../services/data.service';
import { movieRequest } from '././../../models/models';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-movie-list',
    templateUrl: './movie-list.component.html',
    //styleUrls: ['./vehicle-list.component.scss']
})
export class MovieListComponent implements OnInit {
    private readonly PAGE_SIZE = 15;
    
    queryResult: any = {
        itemCount: 0,
        items: []
    };
   
    query: any = {
        per_page: this.PAGE_SIZE,
        page: 1
    };

    constructor(private movieService: DataService) { }

    ngOnInit() {       
        this.populateMovies();       
    }

    onFilterChange() {
        this.query.page = 1;       

        this.populateMovies();
    }

    private populateMovies() {
        this.movieService.getMovies(this.query)
            //.map(r => r.json() as movieRequest[])
            .subscribe(queryResult => this.queryResult = queryResult);       
    }

    resetFilter() {        
        this.query = {
            page: 1,
            per_page: this.PAGE_SIZE
        };
        this.populateMovies();
    }    
}
