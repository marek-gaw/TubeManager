# TubeManager

This application allows to manage links to (mainly) YouTube™ videos.

## Preface

The main reason to create this application is huge number of bookmarks gathered in [SkyTube](https://github.com/SkyTubeTeam/SkyTube). Despite of all goodies provided by this app, I cannot effectively manage bookmarks.

Since SkyTube allows to export bookmarks as a Sqlite file, it is quite easy to import those data and manage them.

## Details

- [Spikes](./spikes.md)

  Spikes allows to test certain ideas or prove technical feasibility. Those solutions won't be part of the end solution, so are taken out of the main project.

- [Architecture Decission Record](./adr.md)

  ADR helps to keep record of decisions made in the project adding some context to them, with rationale, why such decision was made.

- [Low Level Design]

  - [database import flow](./lld/db-import-flow.md)

## Project Goals

### Use Cases

- provide a way to manage links to streaming services like YouTube™
- manage backups created by SkyTube

### Learning

- Angular 17 and it's news concepts like standalone components
- How to build Cloud Native 12+ Factors App?
- Migration a web app to the Cloud

## Roadmap

The goal is to build working solution within first 100 days of the project, starting from 1st of March, 2024.

1. `A day of desiging may save us from weeks of coding`

    Time to think over the whole solution, try some ideas and clarify, how TubeManager sholud look like.

2. `It is dumb but it works, so it is not dumb`
  
    "Working software is better than beautiful software" - time to prove, that the idea is vaild and is achievable.

3. `Project as it should be`
  
    First iteration of properly designed application, that works locally

4. `Sky is the limit`

    From now on, project has desired feature set. All further features are considered as "nice to have", for example: deployment to Azure.

## Further details

- [Architecture Decision Record](./adr.md)
