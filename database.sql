/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE = ''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS = @@UNIQUE_CHECKS, UNIQUE_CHECKS = 0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS = @@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS = 0 */;
/*!40101 SET @OLD_SQL_MODE = @@SQL_MODE, SQL_MODE = 'NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES = @@SQL_NOTES, SQL_NOTES = 0 */;

create database if not exists db_toko_cat;
use db_toko_cat;

DROP TABLE IF EXISTS visit;
DROP TABLE IF EXISTS type;
DROP TABLE IF EXISTS note;
DROP TABLE IF EXISTS user;
DROP TABLE IF EXISTS toko;
DROP TABLE IF EXISTS dtrans_item;
DROP TABLE IF EXISTS htrans_item;
DROP TABLE IF EXISTS item;

create table type
(
    TY_ID   int auto_increment primary key,
    TY_NAME varchar(100) not null
);

insert into type(TY_ID, TY_NAME)
values (1, 'Sales Supervisor');
insert into type(TY_ID, TY_NAME)
values (2, 'Salesperson');
insert into type(TY_ID, TY_NAME)
values (3, 'Admin');
insert into type(TY_ID, TY_NAME)
values (4, 'Inventory and Delivery Manager');
insert into type(TY_ID, TY_NAME)
values (5, 'Human Resource');

create table user
(
    US_ID       int auto_increment primary key,
    US_USERNAME varchar(100) not null,
    US_PASSWORD varchar(100) not null,
    US_NAME     varchar(100) not null,
    US_EMAIL    varchar(100),
    US_PHONE    varchar(20),
    US_ADDRESS  varchar(500),
    US_TY_ID    int          not null,
    US_SALARY   int          not null default 100000,
    US_STATUS   int          not null default 1,
    foreign key (US_TY_ID) references type (TY_ID)
);

insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (1, 'user1', 'user1', 'User 1', 'user1@examplemail.com', '0123456789', 'Jalan User 1', 1, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (2, 'user2', 'user2', 'User 2', 'user2@examplemail.com', '0123456789', 'Jalan User 2', 2, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (3, 'user3', 'user3', 'User 3', 'user3@examplemail.com', '0123456789', 'Jalan User 3', 3, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (4, 'user4', 'user4', 'User 4', 'user4@examplemail.com', '0123456789', 'Jalan User 4', 4, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (5, 'user5', 'user5', 'User 5', 'user5@examplemail.com', '0123456789', 'Jalan User 5', 5, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (6, 'sales1', 'sales1', 'Sales 1', 'sales1@examplemail.com', '0123456789', 'Jalan Sales 1', 1, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (7, 'sales2', 'sales2', 'Sales 2', 'sales2@examplemail.com', '0123456789', 'Jalan Sales 2', 1, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (8, 'sales3', 'sales3', 'Sales 3', 'sales3@examplemail.com', '0123456789', 'Jalan Sales 3', 1, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY,
                 US_STATUS)
values (9, 'sales4', 'sales4', 'Sales 4', 'sales4@examplemail.com', '0123456789', 'Jalan Sales 4', 1, 1234567890, 1);

create table note
(
    NO_ID                int auto_increment primary key,
    NO_CREATION_DATETIME datetime      not null default now(),
    NO_TEXT              varchar(1000) not null,
    NO_US_ID             int           not null,
    foreign key (NO_US_ID) references user (US_ID)
);

insert into note(NO_ID, NO_TEXT, NO_US_ID)
values (1, 'User 1 ini adalah contoh user dengan tipe Sales Supervisor.', 1);
insert into note(NO_ID, NO_TEXT, NO_US_ID)
values (2, 'User 2 ini adalah contoh user dengan tipe Salesperson.', 2);
insert into note(NO_ID, NO_TEXT, NO_US_ID)
values (3, 'User 3 ini adalah contoh user dengan tipe Admin.', 3);
insert into note(NO_ID, NO_TEXT, NO_US_ID)
values (4, 'User 4 ini adalah contoh user dengan tipe Inventory and Delivery Manager.', 4);
insert into note(NO_ID, NO_TEXT, NO_US_ID)
values (5, 'User 5 ini adalah contoh user dengan tipe Human Resource.', 5);

create table toko
(
    TOKO_ID   INT AUTO_INCREMENT PRIMARY KEY,
    TOKO_NAME VARCHAR(500) NOT NULL
);

insert into toko (TOKO_ID, TOKO_NAME)
values (1, 'Toko Cat Haha');
insert into toko (TOKO_ID, TOKO_NAME)
values (2, 'Toko Cat Hehe');
insert into toko (TOKO_ID, TOKO_NAME)
values (3, 'Toko Cat Hoho');

create table visit
(
    V_ID      INT AUTO_INCREMENT PRIMARY KEY,
    V_TOKO_ID INT,
    V_TANGGAL DATETIME NOT NULL,
    V_STATUS  INT      NOT NULL,
    V_US_ID   INT      NOT NULL,
    FOREIGN KEY (V_US_ID) REFERENCES user (US_ID),
    FOREIGN KEY (V_TOKO_ID) REFERENCES toko (TOKO_ID)
);

insert into visit (V_ID, V_TOKO_ID, V_TANGGAL,V_STATUS, V_US_ID)
values (1, 1, '2017-04-06 13:30:12', 1, 2);
insert into visit (V_ID, V_TOKO_ID, V_TANGGAL,V_STATUS, V_US_ID)
values (2, 2, '2018-04-06 13:30:12', 1, 2);
insert into visit (V_ID, V_TOKO_ID, V_TANGGAL,V_STATUS, V_US_ID)
values (3, 3, '2019-04-06 13:30:12', 0, 2);

create table item(
	IT_ID int auto_increment primary key,
	IT_NAME varchar(100) not null,
	IT_PRICE int not null,
	IT_STOCK int not null,
	IT_STATUS int not null default 1
);

insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (1, 'CobaCat Warna Earthy Tone', 50000, 200, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (2, 'CobaCat Warna Burnt Orange', 45000, 150, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (3, 'CobaCat Warna Pastel', 60000, 100, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (4, 'CobaCat Warna Hazelnut', 40000, 100, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (5, 'CobaCat Warna Merah Bata', 50000, 250, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (6, 'CobaCat Warna Abu Lilac', 40000, 150, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (7, 'CobaCat Warna Coral', 50000, 100, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (8, 'CobaCat Warna Beige', 55000, 225, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (9, 'CobaCat Warna Broken White', 55000, 170, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (10, 'CobaCat Warna Peach', 45000, 200, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (11, 'CobaCat Warna Khaki', 30000, 100, 1);
insert into item(IT_ID, IT_NAME, IT_PRICE, IT_STOCK, IT_STATUS)
values (12, 'CobaCat Warna Ivory', 55000, 250, 1);

create table htrans_item(
	HT_ID int auto_increment primary key,
	HT_TO_ID int not null,
	HT_INVOICE_NUMBER varchar(10) not null,
	HT_TOTAL int not null,
	HT_STATUS int not null default 1,
	foreign key(HT_TO_ID) references toko(TOKO_ID)
);

create table dtrans_item(
	DT_ID int auto_increment primary key,
	DT_IT_ID int not null,
	DT_AMOUNT int not null,
	DT_SUBTOTAL int not null,
	DT_HT_ID int not null,
	DT_STATUS int not null default 1,
	foreign key(DT_IT_ID) references item(IT_ID),
	foreign key(DT_HT_ID) references htrans_item(HT_ID)
);

-- create table order(
-- OD_ID int auto_increment primary key,
-- OD_STATUS int not null default 1
-- );