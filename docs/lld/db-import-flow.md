# Database import flow

## Overview

Process implemented as a state machine.

1. Extract db files from ZIP archive
2. Read all data from bookmarks.db
3. Read all data from channels.db
4. Transform data into common format and store in tubemanager.db

## Flow

```mermaid
sequenceDiagram
    actor User
    participant API
    participant orchestrator
    participant importer

    API->>orchestrator: import(path_to_archive)
    orchestrator->>importer: extractZip(path_to_archive)
    importer->>orchestrator: status(path_to_directory)
    orchestrator->>importer: import(path_bookmarks.db)
    importer->>orchestrator: status()
    orchestrator->>importer: import(path_channels.db)
    importer->>orchestrator: status()
    orchestrator->>API: status() 
```
