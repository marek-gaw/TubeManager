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
  editedTag: Tags;

  constructor(private tagsService: TagsService) {
    this.tags = [];
    this.editedTag = { id:"", title:"" };
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
    console.log(`onAddTag:${val}`);
    this.tagsService.create(val)
      .subscribe(tag => this.tags.push({
        id: tag.id,
        title: tag.title
      }));
  }

  onEditTag(tag: Tags): void {
    console.log(`onEditTag for tag: ${tag.id}|${tag.title}`);
    this.editedTag = tag;
  }

  onSaveEditedTag(id:string, title:string): void {
    console.log(`onSaveEditTag for tag: ${id}|${title}`);
    this.tagsService.edit({id:id, title:title})
      .subscribe(tag => {
        const idx = this.tags.findIndex(o => o.id == tag.id);
        this.tags[idx] = tag;
      })
  }

  onDeleteTag(tag: Tags): void {
    console.log(`onDeleteTag for tag: ${tag.id} | ${tag.title}`);
    this.tagsService.delete(tag)
      .subscribe(t => {
        const idx = this.tags.indexOf(tag);
        this.tags.splice(idx, 1);
      })
  }
}
