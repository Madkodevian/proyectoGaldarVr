CREATE DATABASE IF NOT EXISTS galdarvr;
USE galdarvr;

CREATE TABLE IF NOT EXISTS user (
    codUser INT PRIMARY KEY NOT NULL,
    lastName VARCHAR(80) NOT NULL,
    firstName VARCHAR(50),
    email VARCHAR(40)
);

CREATE TABLE IF NOT EXISTS account (
    codAccount INT PRIMARY KEY NOT NULL,
    activities VARCHAR(200) NOT NULL,
    userComment VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS vrwalk (
    codVRWalk INT PRIMARY KEY NOT NULL,
    scene INT NOT NULL,
    information VARCHAR(100)
);