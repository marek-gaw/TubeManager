# Requirements

## Must Have (first 100 days)

- [x] Import data from SkyTube
  - [x] Application consumes archive made by SkyTube and imports bookmarks stored.
  - [x] Import process is "addition only": existing bookmarks identified by url are not modified or deleted. Only those bookmarks, that do not exist in TubeManager, are imported.
- [x] Archive import
  - [x] User can import bookmarks
  - [x] User can import channels
- [ ] Manage data
  - [x] Each bookmark might be assigned to single category.
  - [x] User can assign many tags to single bookmark.
  - [x] The same tag might be assigned to many bookmarks.
  - [ ] User might remove tags from a bookmark
  - [ ] User can add single bookmark manually
- [x] Display
  - [x] Bookmarks are displayed as cards with: thumbnail, title and part of the description
  - [x] Bookmarks are shown on pages
  - [x] User can set a number of bookmarks per page
  - [x] User can play a video in embedded player after clicking video thumbnail
- [ ] Tags
  - [x] User can list all existing tags
  - [x] User can assign multiple tags to the bookmark
  - [x] User can remove selected tag from the bookmark

## Good to Have

- [ ] Category management
  - [ ] User can list all bookmarks assigned to the category.
  - [x] Category might be empty (no bookmarks assigned).
- [ ] Tag management
  - [x] Single bookmark might be assinged with no tags at all
  - [x] Tag might be assigned to multiple bookmarks.
  - [x] Tags can be added/modified/deleted.
  - [x] There is no default tag for each new bookmark.
  - [ ] User can see how many bookmarks uses given tag
- [ ] Channel management
  - [ ] Information about subscribed channels can be extracted from SkyTube archive. This information should be presented in a similiar way as bookmarks.
  - [ ] Bookmark can be assigned to a channel.
- [ ] Playlists
  - [ ] User can define it's own playlist.
  - [ ] If this is possible, interface should allow to play video (embedded player). Otherwise, respective link should be opened.
- [ ] Import data from SkyTube
  - [ ] User can see a summary of the import process: how many bookmarks were present, how many of them have been imported etc.
- [ ] Search
  - [ ] User can search for a video by Title

## Ideas to explore

1. Categories might form a tree (category assigned to a different category).
2. Tags can be assigned to bookmark or channel.
3. Adding multiple bookmarks to the category.
4. Adding multiple tags to the bookmark.
