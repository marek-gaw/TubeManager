import { Component, Input } from '@angular/core';
import { Movie } from '../../interfaces/movie';
import { NgIf } from '@angular/common';

@Component({
  selector: 'movie',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './movie.component.html',
  styleUrl: './movie.component.css'
})
export class MovieComponent {

  @Input() movie?: Movie;

}
