import { Component } from '@angular/core';
import { BookmarkComponent } from '../bookmark/bookmark.component';
import { Bookmark } from '../../interfaces/bookmark';
import { NgFor } from '@angular/common';
import { BookmarksService } from '../../services/bookmarks.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-album',
  standalone: true,
  imports: [
    BookmarkComponent,
    NgFor,
    HttpClientModule,
    CommonModule
  ],
  templateUrl: './album.component.html',
  styleUrl: './album.component.css'
})
export class AlbumComponent {

  bookmarks: Bookmark[];
  currentPage: number = 1;
  pageSize: number = 15;
  totalPages: number = 10;

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

  fetchPage(page: number, pageSize: number): void {
    this.bookmarksService.getPage(page, pageSize).subscribe(data => {
      this.bookmarks = data;
      console.log(data);
    });
  }

  onPageChange(page: number): void {
    console.log(`Page changed to ${page}`);
    this.currentPage = page;
    this.fetchPage(page, this.pageSize);
  }

  numSequence(n: number): Array<number> { 
    return Array(n); 
  } 
}
