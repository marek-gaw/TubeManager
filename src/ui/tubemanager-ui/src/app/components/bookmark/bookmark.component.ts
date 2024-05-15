import { Component, Input, Output, EventEmitter, inject } from '@angular/core';
import { Bookmark } from '../../interfaces/bookmark';
import { NgFor, NgIf, SlicePipe } from '@angular/common';
import { SlicePipeFormat } from './SlicePipeFormat';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BookmarkDetailsModalComponent } from '../bookmark-details-modal/bookmark-details-modal.component';
import { Tags } from '../../interfaces/tags';
import { BookmarksService } from '../../services/bookmarks.service';

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

  constructor(private bookmarksService: BookmarksService) { }

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
    // modalRef.componentInstance.updatedTags.subscribe((result: any) => {
    //   console.log(result);
    // });
    modalRef.result.then((result: Tags[]) => {
      if (result) {
        console.log(`modalRef.result.then: ${JSON.stringify(result)}`);
        modalRef.componentInstance.bookmark.tags = result;

        var tags: string[] = [];
        result.forEach( i => {
          console.log(`i.id: ${i.id}`);
          tags.push(i.id);
        });

        const payload= {
          tags
        }

        console.log(`data: ${JSON.stringify(payload)}`);

        this.bookmarksService.update(modalRef.componentInstance.bookmark.id, payload).subscribe(data => {
          console.log(data);
        });
      }
    });
  } 

}

