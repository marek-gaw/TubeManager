import { Routes } from '@angular/router';
import { AlbumComponent } from './components/album/album.component';
import { ImportComponent } from './components/import/import.component';
import { TagsComponent } from './components/tags/tags.component';
import { ChannelsComponent } from './components/channels/channels.component';

export const routes: Routes = [
    { path: '', redirectTo: 'bookmarks', pathMatch: 'full' },
    { path: 'bookmarks', component: AlbumComponent },
    { path: 'import', component: ImportComponent},
    { path: 'tags', component: TagsComponent},
    { path: 'channels', component: ChannelsComponent}
];
