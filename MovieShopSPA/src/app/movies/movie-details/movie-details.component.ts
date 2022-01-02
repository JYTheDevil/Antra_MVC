import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  id: number = 0;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.paramMap.subscribe(
      p => {
        this.id = Number(p.get('id'));
        console.log('MovieId: ' + this.id);
        // get the movie id from the current URL and call Movie Service and show the movie details

      }
    );

  }

}
