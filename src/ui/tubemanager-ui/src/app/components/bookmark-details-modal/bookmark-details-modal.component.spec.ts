import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookmarkDetailsModalComponent } from './bookmark-details-modal.component';

describe('BookmarkDetailsModalComponent', () => {
  let component: BookmarkDetailsModalComponent;
  let fixture: ComponentFixture<BookmarkDetailsModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookmarkDetailsModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BookmarkDetailsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
