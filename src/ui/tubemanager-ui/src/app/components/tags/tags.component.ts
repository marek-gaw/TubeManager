import { Component } from '@angular/core';
import { TagsService } from '../../services/tags.service';
import { Tags } from '../../interfaces/tags';
import { NgFor } from '@angular/common';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-tags',
  standalone: true,
  imports: [
    NgFor
  ],
  templateUrl: './tags.component.html',
  styleUrl: './tags.component.css'
})
export class TagsComponent {

  tags: Tags[];

  constructor(private tagsService: TagsService) {
    this.tags = [];
  }

  ngOnInit(): void {
    this.getAllTags();
  }

  getAllTags(): void {
    this.tagsService.getAll().subscribe(data => {
      this.tags = data;
      console.log(data);
    })
  }

  onAddTag(val: string): void {
    console.log(`tagName:${val}`);
    this.tagsService.create(val)
      .subscribe(tag => this.tags.push({
        id: tag.id,
        title: tag.title
      }));
  }

  onDeleteTag(tag: Tags): void {
    console.log(`onDeleteTag for tag: ${tag.id} | ${tag.title}`);
    this.tagsService.delete(tag)
      .subscribe(t => {
        const idx = this.tags.indexOf(tag);
        this.tags.splice(idx, 1)
      })
  }
}
