import { Component } from '@angular/core';
import { MoviesComponent } from '../../movies/movies.component';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-album',
  standalone: true,
  imports: [
    MoviesComponent,
    NgFor
  ],
  templateUrl: './album.component.html',
  styleUrl: './album.component.css'
})
export class AlbumComponent {

}
