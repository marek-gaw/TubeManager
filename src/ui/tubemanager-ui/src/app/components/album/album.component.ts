import { Component } from '@angular/core';
import { BookmarkComponent } from '../bookmark/bookmark.component';
import { Bookmark } from '../../interfaces/bookmark';
import { NgFor } from '@angular/common';
import { BookmarksService } from '../../services/bookmarks.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { YouTubePlayer } from '@angular/youtube-player';

@Component({
  selector: 'app-album',
  standalone: true,
  imports: [
    BookmarkComponent,
    NgFor,
    HttpClientModule,
    CommonModule,
    YouTubePlayer
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
  videoToPlay: string = "mVjYG9TSN88";

  constructor(private bookmarksService: BookmarksService) {
    this.bookmarks = [];
  }

  ngOnInit(): void {
    this.fetchPage(1, 10);
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

    console.log(`Page changed to ${page}, page size: ${this.pageSize}`);
    this.currentPage = page;
    this.fetchPage(page, this.pageSize);
  }

  numSequence(n: number): Array<number> {

    var start, end: number;

    if (this.currentPage < 5) {
      start = 1;
      end = this.currentPage+10;
    } else{
      start = this.currentPage-5;
      end = this.currentPage+5;
    }

    if(this.currentPage > (this.totalPages-5)) {
      end = this.totalPages;
      start= this.totalPages-10;
    } 

    return this.range(start, end, 1)
  }

  pagesSequence(): Array<number> {
    return new Array(10,20,50,100);
  }

  isCurrent(n: number): boolean {
    if (n == this.currentPage) {
      return true;
    } else {
      return false;
    }
  }

  onPageSizeSelected(size:number) {
    this.pageSize = size;
    console.log(`Page size set to: ${this.pageSize}`)
    this.fetchPage(1, this.pageSize);
  }

  range(start: number, end: number, step: number): Array<number> {
     var arr: number[] = new Array();
  
    for (let i = start; i <= end; i += step) {
      arr.push(i)
    }  
    return arr;
  }

  setVideoToPlay(url: string): void {
    this.videoToPlay = url;
    console.log(`Player link set to: ${this.videoToPlay}`);
  }
}
