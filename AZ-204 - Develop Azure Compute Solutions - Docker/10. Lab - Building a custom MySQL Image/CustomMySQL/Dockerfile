FROM mysql as base

ENV MYSQL_ROOT_PASSWORD=Azure@123
ENV MYSQL_DATABASE=appdb

COPY 01.sql /docker-entrypoint-initdb.d/