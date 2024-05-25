import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Category } from '../interfaces/category';
import { v4 as uuidv4 } from 'uuid';

const baseUrl= 'http://localhost:5126/category';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(baseUrl);
  }

  create(name: string, description: string): Observable<Category> {
    const category: Category = { 
      id: uuidv4(),
      name: name,
      description: description
    };
    return this.http.post<Category>(baseUrl, category, httpOptions);
  }

  edit(category: Category): Observable<Category> {
    const body = { 
      name: category.name,
      description: category.description  
    };
    return this.http.put<Category>(`${baseUrl}/${category.id}`, body, httpOptions)
  }

  delete(category: Category): Observable<Category> {
    return this.http.delete<Category>(`${baseUrl}/${category.id}`);
  }
}
