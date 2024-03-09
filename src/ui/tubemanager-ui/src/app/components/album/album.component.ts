import { Component } from '@angular/core';
import { MovieComponent } from '../movie/movie.component';
import { Movie } from '../../interfaces/movie'
import { MOVIES } from '../../mocks/movies-mock'
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-album',
  standalone: true,
  imports: [
    MovieComponent,
    NgFor
  ],
  templateUrl: './album.component.html',
  styleUrl: './album.component.css'
})
export class AlbumComponent {

  movies = MOVIES;

}
