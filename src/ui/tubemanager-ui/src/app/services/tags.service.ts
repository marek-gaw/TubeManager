import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tags } from '../interfaces/tags';
import { Observable } from 'rxjs/internal/Observable';

const baseUrl = 'http://localhost:5126/tags';

@Injectable({
  providedIn: 'root'
})
export class TagsService {

  constructor(private http:HttpClient) { }

  getAll(): Observable<Tags[]> {
    return this.http.get<Tags[]>(`${baseUrl}`);
  }
}
