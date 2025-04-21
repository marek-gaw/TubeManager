import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ImportInfo } from "../components/import-info/import-info.component";
import { Observable } from "rxjs/internal/Observable";

const baseUrl = 'http://localhost:5126/import-info';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
    })
};

@Injectable({ providedIn: 'root'})
export class ImportInfoService {

    constructor(private http: HttpClient) {}

    getAll(): Observable<ImportInfo[]> {
        return this.http.get<ImportInfo[]>(baseUrl)
    }    
}