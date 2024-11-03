import { Routes } from '@angular/router';
import { ImportComponent } from './components/import/import.component';
import { TagsComponent } from './components/tags/tags.component';
import { ChannelsComponent } from './components/channels/channels.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { NewBookmarkComponent } from './components/new-bookmark/new-bookmark.component';
import { AlbumComponent } from './components/album/album.component';

export const routes: Routes = [
    { path: '', redirectTo: 'bookmarks', pathMatch: 'full' },
    { path: 'bookmarks', component: AlbumComponent },
    { path: 'new-bookmark', component: NewBookmarkComponent },
    { path: 'import', component: ImportComponent },
    { path: 'tags', component: TagsComponent },
    { path: 'channels', component: ChannelsComponent },
    { path: 'categories', component: CategoriesComponent }
];
