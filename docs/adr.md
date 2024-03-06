# Architecture Decision Record

## 001: Skip dockerization in first stage

First step of the project should be as simple as it is possible. Delivery with Docker containers is certainly desired and eventually should be implemented, but is not required to run the application locally.

Alternatives: dockerize from the day 1

## 002: Bootstrap as a styling framework

Bootstrap is well-established in Angular world, it is easy to find many tutorials and examples.

Card component might be very useful as a base for "movie tile".

Alternatives: Material, PrimeNG
