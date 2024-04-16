import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Bookmark } from '../interfaces/bookmark';
import { Observable } from 'rxjs';

const baseUrl = 'http://localhost:5126/bookmarks'

@Injectable({
  providedIn: 'root'
})
export class BookmarksService {

  constructor(private http:HttpClient) { }

    getAll(): Observable<Bookmark[]> {
      return this.http.get<Bookmark[]>(`${baseUrl}`);
    }

    getPage(page: number, pageSize: number): Observable<Bookmark[]> {
      return this.http.get<Bookmark[]>(`${baseUrl}?page=${page}&pageSize=${pageSize}`);
    }

    get(id: any): Observable<Bookmark> {
      return this.http.get<Bookmark>(`${baseUrl}/${id}`);
    }

    create(data: any): Observable<any> {
      return this.http.post(baseUrl, data);
    }

    update(id: any, data: any): Observable<any> {
      return this.http.put(`${baseUrl}/${id}`, data);
    }
    
    delete(id: any): Observable<any> {
      return this.http.delete(`${baseUrl}/${id}`);
    }

}
