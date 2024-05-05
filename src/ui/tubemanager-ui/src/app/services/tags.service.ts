import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tags } from '../interfaces/tags';
import { Observable } from 'rxjs/internal/Observable';

const baseUrl = 'http://localhost:5126/tags';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class TagsService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Tags[]> {
    return this.http.get<Tags[]>(`${baseUrl}`);
  }

  create(name: string): Observable<any> {
    const tag: Tags = { title: name };
    return this.http.post<Tags>(baseUrl, tag, httpOptions);
  }
}
