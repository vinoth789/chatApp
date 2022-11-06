FROM node:lts-alpine as build-stage

ARG VITE_APP_API_URL
ENV VITE_APP_API_URL ${VITE_APP_API_URL}

WORKDIR /app
COPY ./Frontend/package*.json .
RUN npm install
COPY ./Frontend/ .

RUN npm run build

# production stage
FROM nginx:stable-alpine as production-stage

COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
