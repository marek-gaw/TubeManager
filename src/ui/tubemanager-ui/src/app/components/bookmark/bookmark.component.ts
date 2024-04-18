import { Component, Input } from '@angular/core';
import { Bookmark } from '../../interfaces/bookmark';
import { NgIf, SlicePipe } from '@angular/common';
import { SlicePipeFormat } from './SlicePipeFormat';
import { YouTubePlayer } from '@angular/youtube-player';

@Component({
  selector: 'bookmark',
  standalone: true,
  imports: [ 
    SlicePipe,
    NgIf,
    YouTubePlayer
  ],
  templateUrl: './bookmark.component.html',
  styleUrl: './bookmark.component.css'
})

export class BookmarkComponent {

  @Input() bookmark?: Bookmark;
  slicePipeformat: SlicePipeFormat = {
    start: 0,
    end: 50,
    folded: true
  }

  toggleDescription(): void {
    if(this.slicePipeformat.folded) {
      let descLen = this.bookmark?.description.length ?? 1000;
      this.slicePipeformat.end = descLen;
      this.slicePipeformat.folded = false;
    } else {
      this.slicePipeformat.end = 50;
      this.slicePipeformat.folded = true;
    }
  }
}
