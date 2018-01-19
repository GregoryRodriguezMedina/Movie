import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
//import { HttpClientModule } from '@angular/common/http';

import { MyDatePickerModule } from 'mydatepicker';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { CustomerListComponent } from './components/customer/customer-list.component';
import { CustomerFormComponent } from './components/customer/customer-form.component';
import { DataService } from './services/data.service';

import { MovieListComponent } from './components/movie/movie-list.component';
import { MovieFormComponent } from './components/movie/movie-form.component';


import { RentalListComponent } from './components/rental/rental-list.component';
import { RentalFormComponent } from './components/rental/rental-form.component';
import { ReturnedFormComponent } from './components/rental/returned-form.component';

import { PaginationComponent } from './components/shared/pagination.component'

import { LoginComponent } from './components/app/login.component';
import { AuthGuard } from "./components/shared/AuthGuard";
//import { CookieService } from "angular2-cookie/services/cookies.service";



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CustomerListComponent,
        CustomerFormComponent,        
        MovieListComponent,
        MovieFormComponent,    
        RentalListComponent,
        RentalFormComponent,   
        ReturnedFormComponent,
        HomeComponent,
        PaginationComponent,
        LoginComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        MyDatePickerModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'customer', component: CustomerListComponent, canActivate: [AuthGuard] },            
            { path: 'customer/new', component: CustomerFormComponent, canActivate: [AuthGuard] },
            { path: 'customer/:id', component: CustomerFormComponent, canActivate: [AuthGuard]  },

            { path: 'movie', component: MovieListComponent, canActivate: [AuthGuard]  },
            { path: 'movie/new', component: MovieFormComponent, canActivate: [AuthGuard]  },
            { path: 'movie/:id', component: MovieFormComponent, canActivate: [AuthGuard]  },

            { path: 'rental', component: RentalListComponent, canActivate: [AuthGuard]  },
            { path: 'rental/new', component: RentalFormComponent, canActivate: [AuthGuard]  },
            { path: 'rental/returned/:id', component: ReturnedFormComponent, canActivate: [AuthGuard]  },

            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        DataService,
        AuthGuard
        //CookieService 
    ]
})
export class AppModuleShared {
}
