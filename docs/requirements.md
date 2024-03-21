# Requirements

## Must Have

1. Import data from SkyTube
   1. Application consumes archive made by SkyTube and imports bookmarks stored.
   2. Import process is "addition only": existing bookmarks identified by url are not modified or deleted. Only those bookmarks, that do not exist in TubeManager, are imported.
2. Manage data
   1. Each bookmark might be assigned to single category.
   2. User can assign many tags to single bookmark.
   3. The same tag might be assigned to many bookmarks.

## Good to Have

1. Category management
   1. All bookmarks belongs to category "Default". This category cannot be deleted.
   2. User can list all bookmarks assigned to the category.
   3. Categories different than "Default" can be added/modified/deleted.
   4. Category might be empty (no bookmarks assigned).
2. Tag management
   1. Single bookmark might be assinged with no tags at all
   2. Tag might be assigned to multiple bookmarks.
   3. Tags can be added/modified/deleted.
   4. There is no default tag for each new bookmark.
3. Channel management
   1. Information about subscribed channels can be extracted from SkyTube archive. This information should be presented in a similiar way as bookmarks.
   2. Bookmark can be assigned to a channel.
4. Playlists
   1. User can define it's own playlist.
   2. If this is possible, interface should allow to play video (embedded player). Otherwise, respective link should be opened.

## Ideas to explore

1. Categories might form a tree (category assigned to a different category).
2. Tags can be assigned to bookmark or channel.
3. Adding multiple bookmarks to the category.
4. Adding multiple tags to the bookmark.
