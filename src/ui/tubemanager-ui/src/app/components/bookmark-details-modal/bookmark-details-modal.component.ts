import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { NgbActiveModal, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { Bookmark } from '../../interfaces/bookmark';
import { NgClass, NgFor } from '@angular/common';
import { Tags } from '../../interfaces/tags';
import { TagsService } from '../../services/tags.service';
import { CategoriesService } from '../../services/categories.service';
import { Category } from '../../interfaces/category';
import { BookmarksService } from '../../services/bookmarks.service';

@Component({
  selector: 'app-bookmark-details-modal',
  standalone: true,
  imports: [
    NgFor,
    NgClass,
    NgbDropdownModule
  ],
  templateUrl: './bookmark-details-modal.component.html',
  styleUrl: './bookmark-details-modal.component.css'
})
export class BookmarkDetailsModalComponent {
  activeModal = inject(NgbActiveModal);
  @Input() bookmark?: Bookmark | undefined = {
    id: '',
    title: '',
    channel: '',
    videoUrl: '',
    description: '',
    thumbnailUrl: '',
    tags: [],
    category: { id: '', name: '', description: '' }
  };
  tags: Tags[] = [];
  categories: Category[] = [];
  @Output() updatedTags = new EventEmitter<Tags[]>();

  constructor(private tagsService: TagsService, 
    private categoriesService: CategoriesService,
    private bookmarksService: BookmarksService) { }

  ngOnInit(): void { }

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

  onTagBadgeClick(tag: Tags): void {
    console.log(`onTagBadgeClick - tag to delete: ${JSON.stringify(tag)}`);
    const idx = this.tags.indexOf(tag);
    this.tags.splice(idx, 1);
    const id = this.bookmark?.tags.indexOf(tag);
    if (id != undefined) {
      this.bookmark?.tags.splice(id, 1);
    }
    
    this.bookmarksService.removeTagFromBookmark(this.bookmark?.id, tag.id).subscribe(data => {
      console.log(`DELETE tag from bookmark: ${data}`);
    })    
  }

  onCategoryBadgeClick(): void {
    console.log(`onCategoryBadgeClick - removing category`);
    
    if (this.bookmark != null) {
      if (this.bookmark.category != null) {
        this.bookmark.category = undefined;
      }
    }

    this.bookmarksService.updateCategory(this.bookmark?.id, undefined).subscribe(data => {
      console.log(`Update category from bookmark: ${data}`);
    })    
  }

  onClose(): void {
    // console.log(`onClose: ${JSON.stringify(this.bookmark)}`);
    console.log(`onClose: tags to update: ${JSON.stringify(this.bookmark?.tags)}, category to set: ${this.bookmark?.category}`)
    // this.updatedTags.emit(this.bookmark?.tags);
    this.activeModal.close(this.bookmark);
  }

  // categories
  onShowDropdownCategory(): void {
    console.log(`Category Dropdown opened`)
    this.categoriesService.getAll().subscribe(data => {
      this.categories = data;
      console.log(data);
    })
  }

  onCategoryDropdownPosClicked(category: Category): void {
    console.log(`category: ${category.id} | ${category.name}`);
    (this.bookmark as Bookmark).category = category;
    this.bookmarksService.updateCategory(this.bookmark?.id, category.id).subscribe(data => {
      console.log(data);
    })
  }
}
