import { Component } from '@angular/core';
import { Category } from '../../interfaces/category';
import { CategoriesService } from '../../services/categories.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [
    NgFor
  ],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent {

  categories: Category[] = [];
  editedCategory: Category = {
    id: "",
    name: "",
    description: ""
  };

  constructor(private categoriesService: CategoriesService) { }

  ngOnInit(): void {
    this.getAllCategories();
  }

  getAllCategories(): void {
    this.categoriesService.getAll().subscribe(data => {
      this.categories = data;
      console.log(data);
    })
  }

  onAddCategory(name: string, desc: string): void {
    console.log(`onAddCategory: ${name}| ${desc}`);
    this.categoriesService.create(name, desc)
      .subscribe(category => this.categories.push({
        id: category.id,
        name: category.name,
        description: category.description
      }));
  }

  onEditCategory(category: Category): void {
    console.log(`onEditCategory: ${category.id}| ${category.name}`);
    this.editedCategory = category;
  }

  onSaveEditedCqtegory(id:string, name:string, description: string): void {
    console.log(`onSaveEditCategory: ${id}|${name}`);
    this.categoriesService.edit({id:id, name:name, description: description})
      .subscribe(c => {
        const idx = this.categories.findIndex(o => o.id == c.id);
        this.categories[idx] = c;
      })
  }

  onDeleteCategory(category: Category): void {
    console.log(`onDeleteCategory: ${category.id}| ${category.name}`);
    this.categoriesService.delete(category)
      .subscribe(c => {
        const i = this.categories.indexOf(category);
        this.categories.splice(i, 1);
      })
  }
}
