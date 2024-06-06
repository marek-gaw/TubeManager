FROM node:18.17.1-alpine as build
WORKDIR /app
COPY . .
COPY package.json ./
RUN npm install
RUN npm run ng build

RUN npm run build
FROM nginx:stable
COPY --from=build /app/dist/tubemanager-ui /usr/share/ngnix/html
EXPOSE 4200
