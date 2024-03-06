import { Component } from '@angular/core';
import { Movie } from '../interfaces/movies'
import { MOVIES } from '../mocks/movies-mock'
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-movies',
  standalone: true,
  imports: [
    NgFor
  ],
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.css'
})
export class MoviesComponent {

  movies = MOVIES;
}
