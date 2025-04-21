import { Component } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';
import { BookmarksService } from '../../services/bookmarks.service';
import { Bookmark } from '../../interfaces/bookmark';
import { BookmarkResponse } from '../../interfaces/bookmarkresponse';

@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [],
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.css'
})
export class SearchBarComponent {

  @Output() queryEvent = new EventEmitter<BookmarkResponse>();

  constructor(private bookmarksService: BookmarksService) {}

  ngOnInit(): void {}

  onSearchIconClick(value: string) {
    this.onQuery(value);
  }
  onQuery(queryString: string) {
    this.bookmarksService.getQueryPaged(1,9, queryString).subscribe(response => {
      console.log("getQueryPaged:");
      console.log(response);
      
      this.queryEvent.emit(response);
    });
  }

}
