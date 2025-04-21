import { DatePipe, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { ImportInfoService } from '../../services/importInfo.service';

@Component({
  selector: 'app-import-info',
  standalone: true,
  imports: [
    NgFor,
    DatePipe
  ],
  templateUrl: './import-info.component.html',
  styleUrl: './import-info.component.css'
})
export class ImportInfoComponent {

  importInfo: ImportInfo[]

  constructor(private importInfoService: ImportInfoService) {
    this.importInfo = [
      new ImportInfo(),
      new ImportInfo()
    ];
  }

  ngOnInit(): void {
    this.getAllImportInfo();
  }

  getAllImportInfo(): void {
    this.importInfoService.getAll().subscribe(data => {
      this.importInfo = data;
      console.log(data);
    })
  }
}

export class ImportInfo {
  timestamp: Date = new Date();
  bookmarkCount: Number = 0;  
}
