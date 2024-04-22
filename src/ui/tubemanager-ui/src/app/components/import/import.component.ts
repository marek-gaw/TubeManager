import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpEventType, HttpRequest, HttpResponse } from '@angular/common/http';
import { NgIf } from '@angular/common';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-import',
  standalone: true,
  imports: [
    FormsModule,
    NgIf,
  ],
  templateUrl: './import.component.html',
  styleUrl: './import.component.css'
})
export class ImportComponent {

  requiredFileType: string;

  fileName = '';
  uploadProgress: number = 0;
  uploadSub: Subscription = Subscription.EMPTY;
  importStatus: string = "";

  constructor(private http: HttpClient) {
    this.requiredFileType = ".skytube";
  }

  onClickOpenFile(path: string): void {
    console.log("path:", path);
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];

    console.log(event.target.files[0]);

    if (file) {

      this.fileName = file.name;

      const formData = new FormData();

      formData.append("file", file);
      formData.append("Content-Type", "multipart/form-data; boundary=WebAppBoundary");
      formData.append("Content-Disposition", "form-data; name=\"file\"; filename=\"${file.name}\"");

      const upload$ = this.http.post("http://localhost:5126/import", formData, { observe: 'response' });

      upload$.subscribe((res) => {
        if (res.status == 200) {
          console.log(res);
          this.importStatus = res.statusText;
        }
      });
    }
  }
}
