import { Component } from '@angular/core';
import { Movie } from '../interfaces/movies'
import { MOVIES } from '../mocks/movies-mock'
import { NgFor, NgIf } from '@angular/common';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-movies',
  standalone: true,
  imports: [
    NgFor, NgIf, FormsModule
  ],
  templateUrl: './movies.component.html',
  styleUrl: './movies.component.css'
})
export class MoviesComponent {

  movies = MOVIES;
  selectedMovie? : Movie;

  onSelect(movie: Movie): void {
    this.selectedMovie = movie;
  }

}
