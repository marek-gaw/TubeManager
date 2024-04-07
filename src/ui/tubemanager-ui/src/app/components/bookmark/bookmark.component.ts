import { Component, Input } from '@angular/core';
import { Bookmark } from '../../interfaces/bookmark';
import { NgIf } from '@angular/common';

@Component({
  selector: 'bookmark',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './bookmark.component.html',
  styleUrl: './bookmark.component.css'
})
export class BookmarkComponent {

  @Input() bookmark?: Bookmark;

}
