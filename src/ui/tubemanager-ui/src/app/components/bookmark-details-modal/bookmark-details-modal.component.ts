import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { NgbActiveModal, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { Bookmark } from '../../interfaces/bookmark';
import { NgFor } from '@angular/common';
import { Tags } from '../../interfaces/tags';
import { TagsService } from '../../services/tags.service';

@Component({
  selector: 'app-bookmark-details-modal',
  standalone: true,
  imports: [
    NgFor,
    NgbDropdownModule
  ],
  templateUrl: './bookmark-details-modal.component.html',
  styleUrl: './bookmark-details-modal.component.css'
})
export class BookmarkDetailsModalComponent {
  activeModal = inject(NgbActiveModal);
  @Input() bookmark?: Bookmark;
  tags: Tags[] = [];
  @Output() updatedTags = new EventEmitter<Tags[]>();

  constructor(private tagsService: TagsService) { }

  ngOnInit(): void {

  }

  onShowDropdown(): void {
    console.log(`Dropdown opened`)
    this.tagsService.getAll().subscribe(data => {
      this.tags = data;
      console.log(data);
    })
  }

  onKeyUp(ev: KeyboardEvent): void {
    console.log(`event:${ev}`);
    var value = ev.key;

  }

  onDropdownPosClicked(tag: Tags): void {
    console.log(`tag: ${tag.id} | ${tag.title}`);
    this.bookmark?.tags.push(tag);
  }

  onClose(): void {
    // console.log(`onClose: ${JSON.stringify(this.bookmark)}`);
    console.log(`onClose: tags to update: ${JSON.stringify(this.bookmark?.tags)}`)
    // this.updatedTags.emit(this.bookmark?.tags);
    this.activeModal.close(this.bookmark?.tags);
    
  }
}
