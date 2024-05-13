import { Component, Input, Output, EventEmitter, ViewChild, ElementRef, inject } from '@angular/core';
import { Bookmark } from '../../interfaces/bookmark';
import { NgFor, NgIf, SlicePipe } from '@angular/common';
import { SlicePipeFormat } from './SlicePipeFormat';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BookmarkDetailsModalComponent } from '../bookmark-details-modal/bookmark-details-modal.component';

@Component({
  selector: 'bookmark',
  standalone: true,
  imports: [
    SlicePipe,
    NgIf,
    NgFor
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
  @Output() videoLink = new EventEmitter<string>();
  private modalService = inject(NgbModal);

  toggleDescription(): void {
    if (this.slicePipeformat.folded) {
      let descLen = this.bookmark?.description.length ?? 1000;
      this.slicePipeformat.end = descLen;
      this.slicePipeformat.folded = false;
    } else {
      this.slicePipeformat.end = 50;
      this.slicePipeformat.folded = true;
    }
  }

  onThumbnailSelected(url: string): void {
    this.videoLink.emit(url);
  }

  onDetailsClick(b: Bookmark): void {
    console.log(`onDetailsClick: ${JSON.stringify(b)}`)
    const modalRef = this.modalService.open(BookmarkDetailsModalComponent, {
      size: 'lg',
      centered: true,
      scrollable: true
    });
    modalRef.componentInstance.bookmark = b;
  }

}

