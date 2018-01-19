export class CustomerRequest {
    customerId: number;
    firstName: string;
    lastName: string;
    suffix: string;
    address: string;
    mobilPhone: string;
    homePhone: string;
    email: string;
}

export class movieRequest {
    movieId: number;
    title: string;
    synopsis: string;
    duration: number;
    quantityAvailable: number;
    rentalPrice: number;
}

export class KeyNamePair {
    key: string;
    name: string;    
}

export class CustomerResponse {
    customer: string;
    mobilPhone: string;
    address: string;
}

export class RentalRequest {
    customerId: number;
    dateFrom: any;
    dateTo: any;
    movies: number[];
}

export class RentalResponse {
    rentalId: number;
    customer: CustomerResponse;
    dateFrom: any;
    dateTo: any;
    movies:KeyNamePair[]
}
