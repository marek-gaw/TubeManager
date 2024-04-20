import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { NgIf } from '@angular/common';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-import',
  standalone: true,
  imports: [
    FormsModule,
    NgIf
  ],
  templateUrl: './import.component.html',
  styleUrl: './import.component.css'
})
export class ImportComponent {

  requiredFileType: string;

  fileName = '';
  uploadProgress: number = 0;
  uploadSub: Subscription = Subscription.EMPTY;

  constructor(private http: HttpClient) {
    this.requiredFileType = ".skytube";
  }

  onClickOpenFile(path: string): void {
    console.log("path:", path);
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];

    if (file) {

      this.fileName = file.name;

      const formData = new FormData();

      formData.append("thumbnail", file);

      const upload$ = this.http.post("/api/thumbnail-upload", formData);

      upload$.subscribe();
    }
  }
}
