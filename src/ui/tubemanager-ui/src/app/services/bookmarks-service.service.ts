import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Movie } from '../interfaces/movie';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookmarksServiceService {

  constructor(private http:HttpClient) { }

    getAll(): Observable<Movie[]> {
      return this.http.get<Movie[]>(baseUrl);
    }

    get(id: any): Observable<Movie> {
      return this.http.get<Movie>(`${baseUrl}/${id}`);
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
