import { Component, Input, inject } from '@angular/core';
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
}
