import { Component } from '@angular/core';
import { MovieComponent } from '../movie/movie.component';
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

}
