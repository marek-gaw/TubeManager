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
  prevDisabled: boolean = true;
  nextDisabled: boolean = false;

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
      this.totalPages = data.totalPages;
      this.bookmarks = data.data;
      console.log(data);
    });
  }

  onPageChange(page: number): void {
    if (page >= this.totalPages) {
      page = this.totalPages;
      this.nextDisabled = true;
    } else {
      this.nextDisabled = false;
    }
    if (page <= 1) {
      page = 1;
      this.prevDisabled = true;
    } else {
      this.prevDisabled = false;
    }

    console.log(`Page changed to ${page}`);
    this.currentPage = page;
    this.fetchPage(page, this.pageSize);
  }

  numSequence(n: number): Array<number> { 
    return Array.from(Array(n-1)).map((e,i)=>i+1)
  } 

  isCurrent(n: number): boolean {
    if (n==this.currentPage) {
      return true;
    } else {
      return false;
    }
  }
}
