import { DataService } from '././../../services/data.service';
import { movieRequest } from '././../../models/models';
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
    templateUrl: 'movie-form.component.html',
    // styleUrls: ['input-form-example.css'],
})
export class MovieFormComponent implements OnInit {
    movie: movieRequest =
    {
        movieId: 0,
        title: '',
        synopsis: '',
        duration: 0,
        quantityAvailable: 0,
        rentalPrice: 0,        
    };

    titleDesc = 'Nuevo Registro';
    errorMessage: string;
    id: number = 0;
    edit: boolean = false;
   // api: string = 'api/movie';

    constructor(private router: Router,
        private route: ActivatedRoute,
       private http: Http,
       private movieService: DataService
    ) { }

    ngOnInit(): void {
        this.route.params.subscribe((params: Params) => {
            this.id = + params['id'];
            if (this.id !== 0 && !isNaN(this.id)) {
                // Modo edit
                this.edit = true;
                // buscar el registro
                this.getmovie();
            }
        });
    }

    getmovie() {
        //alert(this.id);
        this.movieService.getMovie(this.id)
            .subscribe(p => this.onMovieRetrieved(p),
            error => this.errorMessage = <any>error
            );
    }

    onMovieRetrieved(movie: movieRequest) {
        this.movie = movie;
        //console.log(JSON.stringify(movie));
        this.titleDesc = `Modificar Registro  ${this.movie.title}`;
    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/movie']);
    }

    onSubmit() {
        // alert(`movie : ${JSON.stringify(this.movie)}`);
        if (confirm("Seguro que desea procesar?")) {
            let headers = new Headers();
            headers.append('Content-Type', 'application/json');

            var $result = (this.edit) ? this.http.put('api/movie/' + this.movie.movieId, this.movie, { headers })
                : this.http.post('api/movie', this.movie, { headers });


               
            $result .map(res => res.json())
                    .subscribe(res => {
                        this.router.navigate(['/movie']);
                    }, (err) => {
                        this.errorMessage = <any>err;
                    });                      
        }

         //if (this.edit)
         //    this.movieService.update(this.movie);
         //else this.movieService.create(this.movie);
    }
}
