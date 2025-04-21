import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Bookmark } from '../interfaces/bookmark';
import { Observable } from 'rxjs';
import { BookmarkResponse } from '../interfaces/bookmarkresponse';

const baseUrl = 'http://localhost:5126/bookmarks'

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class BookmarksService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Bookmark[]> {
    return this.http.get<Bookmark[]>(`${baseUrl}`);
  }

  getPage(page: number, pageSize: number): Observable<BookmarkResponse> {
    return this.http.get<BookmarkResponse>(`${baseUrl}?page=${page}&pageSize=${pageSize}`);
  }

  getQueryPaged(page: number, pageSize: number, query: string): Observable<BookmarkResponse> {
    return this.http.get<BookmarkResponse>(`${baseUrl}?page=${page}&pageSize=${pageSize}&query=${query}`);
  }

  get(id: any): Observable<Bookmark> {
    return this.http.get<Bookmark>(`${baseUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }

  updateTag(id: any, data: any): Observable<any> {
    console.log(`bookmarksService: update tag for bookmark: ${id}`);
    return this.http.put(`${baseUrl}/${id}/tags`, data);
  }

  updateCategory(bookmarkId: any, categoryId: any): Observable<any> {
    console.log(`bookmarksService: update category ${categoryId} for bookmark: ${bookmarkId}`);
    const body = {
      categoryId: categoryId
    }
    return this.http.put(`${baseUrl}/${bookmarkId}/category`, body, httpOptions);
  }

  removeTagFromBookmark(bookmarkId: any, tagId: any): Observable<any> {
    console.log(`bookmarksService: remove tag ${tagId} from bookmark: ${bookmarkId}`);
    const body = {
      TagsId: [tagId]
    };
    return this.http.request('delete', `${baseUrl}/${bookmarkId}/tags`, {
      body: body,
      headers: { 'Content-Type': 'application/json' }
    });
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }

}
