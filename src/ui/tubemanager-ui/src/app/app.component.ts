import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MoviesComponent } from './movies/movies.component';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    HeaderComponent,
    MoviesComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TubeManager';
}
