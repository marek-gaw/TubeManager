# Spikes

## db-scaffold

Spike to explore how to scaffold and map existing database with Entity Framework.

Results: SQLite database `bookmarks.sb` succesfully scaffolded by Entity Framework. Model created manually, because of data format (all relevant data are stored in a single cloumn with JSON content).

## yt-dlp for video metadata

`yt-dlp` tool allows to download video metadata, including description, video length etc. Data might be saved to file or streamed to console.

1. Video metadata dumped to console as JSON

`yt-dlp https://www.youtube.com/watch\?v\=PDqr1lpS3xU --write-description --write-info-json --skip-download --dump-json`
