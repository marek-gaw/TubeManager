import { Component } from '@angular/core';
import { MovieComponent } from '../movie/movie.component';
import { Movie } from '../../interfaces/movie'
import { MOVIES } from '../../mocks/movies-mock'
import { NgFor } from '@angular/common';
import { BookmarksServiceService } from '../../services/bookmarks-service.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-album',
  standalone: true,
  imports: [
    MovieComponent,
    NgFor,
    HttpClientModule
  ],
  templateUrl: './album.component.html',
  styleUrl: './album.component.css'
})
export class AlbumComponent {

  movies = MOVIES;

  constructor(private bookmarksService: BookmarksServiceService) { }

  ngOnInit(): void {
    this.fetchBookmarks();
  }

  fetchBookmarks(): void {
    this.bookmarksService.getAll()
      .subscribe({
        next: (data) => {
          this.movies = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }

}
