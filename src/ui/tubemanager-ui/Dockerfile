FROM node:18-alpine AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run ng build --prod

FROM nginx:alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/dist/tubemanager-ui/browser /usr/share/nginx/html

EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]