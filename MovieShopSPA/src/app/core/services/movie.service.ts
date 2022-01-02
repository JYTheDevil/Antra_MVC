import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }


  // Home Component will call this method
  // Array of move card model
  // Observables, RXJS

  getTopGrossingMovies(): Observable<MovieCard[]> {

    // we need to make a call to the API https://localhost:7225/api/Movies/toprevenue
    // HttpClient class comes from HttpClientModule in angular

    // https://localhost:7225/api/
    return this.http.get<MovieCard[]>(`${environment.apiBaseUrl}movies/toprevenue`);

  }

  getMovieDtails(id: number) {
    // call the api to get movie details, create the model based on json data and return the model
  }

}

// Depedency Injection
// var movies = dbContext.Movies.Where(x => x.revenue>10000).ToList();
// Toutube channels => ABC => posts videos 
// you wanna get the notifcation of when new video is posted => 
// two types, finite observable and infinite observable (stream of data) until you cancel
// Http Call => 