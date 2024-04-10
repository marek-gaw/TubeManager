import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  recentSelected: boolean = false
  bookmarksSelected: boolean = false
  importSelected: boolean = false
  authorSelected: boolean = false

  selectedNavItem: string[] = [
    'recent', 'bookmarks', 'import', 'author'
  ]

  onSelect(element: string): void {
    switch(element){
      case 'recent': {
        this.recentSelected = true
        this.bookmarksSelected = false
        this.importSelected = false
        this.authorSelected = false
        break;
      }
      case 'bookmarks': {
        this.recentSelected = false
        this.bookmarksSelected = true
        this.importSelected = false
        this.authorSelected = false
        break;
      }
      case 'import': {
        this.recentSelected = false
        this.bookmarksSelected = false
        this.importSelected = true
        this.authorSelected = false
        break;
      }
      case 'author': {
        this.recentSelected = false
        this.bookmarksSelected = false
        this.importSelected = false
        this.authorSelected = true
        break;
      }
      default: {
        this.recentSelected = false
        this.bookmarksSelected = false
        this.importSelected = false
        this.authorSelected = false
      }
    }
  }
}
