#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "postgres" --dbname "postgres" <<-EOSQL
    CREATE USER yatb_slave WITH PASSWORD 'yatb';
    CREATE DATABASE yatb WITH OWNER 'yatb_slave';
EOSQL

psql -v ON_ERROR_STOP=1 --username "yatb_slave" --dbname "yatb" <<-EOSQL
    CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
EOSQL
