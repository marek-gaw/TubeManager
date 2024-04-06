import { Routes } from '@angular/router';
import { AlbumComponent } from './components/album/album.component';

export const routes: Routes = [
    { path: '', redirectTo: 'bookmarks', pathMatch: 'full' },
    { path: 'bookmarks', component: AlbumComponent }
];
