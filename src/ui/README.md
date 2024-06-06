# TubeManager - ui

This directory contains UI project for TubeManager.

## How to build

```bash
npm install
```

## How to run locally

```bash
ng serve
```

## Build docker image

```bash
cd src/ui/tubemanager-ui
docker build -t tubemanager-ui:latest  --progress=plain .
```

## Run docker image

```bash
docker run -d -p 4200:4200 tubemanager-ui:latest
```