import { Component } from '@angular/core';
import { BookmarkComponent } from '../bookmark/bookmark.component';
import { Bookmark } from '../../interfaces/bookmark';
import { NgFor } from '@angular/common';
import { BookmarksService } from '../../services/bookmarks.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-album',
  standalone: true,
  imports: [
    BookmarkComponent,
    NgFor,
    HttpClientModule
  ],
  templateUrl: './album.component.html',
  styleUrl: './album.component.css'
})
export class AlbumComponent {

  bookmarks: Bookmark[];

  constructor(private bookmarksService: BookmarksService) {
    this.bookmarks = [];
   }

  ngOnInit(): void {
    this.fetchBookmarks();
  }

  fetchBookmarks(): void {
    this.bookmarksService.getAll()
      .subscribe({
        next: (data) => {
          this.bookmarks = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }

}
