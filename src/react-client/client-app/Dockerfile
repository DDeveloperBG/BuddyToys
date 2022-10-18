FROM node as react_build 

WORKDIR /app

COPY ./client-app /app/ 

RUN npm install --silent

RUN npm run build 

#prepare nginx
FROM nginx

COPY --from=react_build /app/build /usr/share/nginx/html

RUN rm /etc/nginx/conf.d/default.conf

COPY client-app/nginx.conf /etc/nginx/conf.d

#fire up nginx
EXPOSE 80
CMD ["nginx","-g","daemon off;"]