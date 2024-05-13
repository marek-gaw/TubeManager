import { Component, Input, inject } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Bookmark } from '../../interfaces/bookmark';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-bookmark-details-modal',
  standalone: true,
  imports: [
    NgFor
  ],
  templateUrl: './bookmark-details-modal.component.html',
  styleUrl: './bookmark-details-modal.component.css'
})
export class BookmarkDetailsModalComponent {
  activeModal = inject(NgbActiveModal);
  @Input() bookmark?: Bookmark;
}
