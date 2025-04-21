import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportInfoComponent } from './import-info.component';

describe('ImportInfoComponent', () => {
  let component: ImportInfoComponent;
  let fixture: ComponentFixture<ImportInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ImportInfoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ImportInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
