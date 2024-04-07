import { TestBed } from '@angular/core/testing';

import { BookmarksServiceService } from './bookmarks.service';

describe('BookmarksServiceService', () => {
  let service: BookmarksServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookmarksServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
