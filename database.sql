create database db_toko_cat;
use db_toko_cat;

create table type(
TY_ID int auto_increment primary key,
TY_NAME varchar(100) not null
);

insert into type(TY_ID, TY_NAME) values(1, 'Sales Supervisor');
insert into type(TY_ID, TY_NAME) values(2, 'Salesperson');
insert into type(TY_ID, TY_NAME) values(3, 'Admin');
insert into type(TY_ID, TY_NAME) values(4, 'Inventory and Delivery Manager');
insert into type(TY_ID, TY_NAME) values(5, 'Human Resource');

create table user(
US_ID int auto_increment primary key,
US_USERNAME varchar(100) not null,
US_PASSWORD varchar(100) not null,
US_NAME varchar(100) not null,
US_EMAIL varchar(100),
US_PHONE varchar(20),
US_ADDRESS varchar(500),
US_TY_ID int not null,
US_SALARY int not null default 100000,
US_STATUS int not null default 1,
foreign key(US_TY_ID) references type(TY_ID)
);

insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY, US_STATUS) values(1, 'user1', 'user1', 'User 1', 'user1@examplemail.com', '0123456789', 'Jalan User 1', 1, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY, US_STATUS) values(2, 'user2', 'user2', 'User 2', 'user2@examplemail.com', '0123456789', 'Jalan User 2', 2, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY, US_STATUS) values(3, 'user3', 'user3', 'User 3', 'user3@examplemail.com', '0123456789', 'Jalan User 3', 3, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY, US_STATUS) values(4, 'user4', 'user4', 'User 4', 'user4@examplemail.com', '0123456789', 'Jalan User 4', 4, 1234567890, 1);
insert into user(US_ID, US_USERNAME, US_PASSWORD, US_NAME, US_EMAIL, US_PHONE, US_ADDRESS, US_TY_ID, US_SALARY, US_STATUS) values(5, 'user5', 'user5', 'User 5', 'user5@examplemail.com', '0123456789', 'Jalan User 5', 5, 1234567890, 1);

create table note(
NO_ID int auto_increment primary key,
NO_CREATION_DATETIME datetime not null default now(),
NO_TEXT varchar(1000) not null,
NO_US_ID int not null,
foreign key(NO_US_ID) references user(US_ID)
);

insert into note(NO_ID, NO_TEXT, NO_US_ID) values(1, 'User 1 ini adalah contoh user dengan tipe Sales Supervisor.', 1);
insert into note(NO_ID, NO_TEXT, NO_US_ID) values(2, 'User 2 ini adalah contoh user dengan tipe Salesperson.', 2);
insert into note(NO_ID, NO_TEXT, NO_US_ID) values(3, 'User 3 ini adalah contoh user dengan tipe Admin.', 3);
insert into note(NO_ID, NO_TEXT, NO_US_ID) values(4, 'User 4 ini adalah contoh user dengan tipe Inventory and Delivery Manager.', 4);
insert into note(NO_ID, NO_TEXT, NO_US_ID) values(5, 'User 5 ini adalah contoh user dengan tipe Human Resource.', 5);

-- create table item(
-- IT_ID int auto_increment primary key,
-- IT_NAME varchar(100) not null,
-- IT_PRICE int not null,
-- IT_STOCK int not null,
-- IT_STATUS int not null default 1
-- );

-- create table htrans(
-- HT_ID int auto_increment primary key,
-- HT_INVOICE_NUMBER varchar(10) not null,
-- HT_TOTAL int not null,
-- HT_STATUS int not null default 1
-- )

-- create table dtrans(
-- DT_ID int auto_increment primary key,
-- DT_IT_ID int not null,
-- DT_AMOUNT int not null,
-- DT_SUBTOTAL int not null,
-- DT_HT_ID int not null,
-- DT_STATUS int not null default 1,
-- foreign key(DT_IT_ID) references item(IT_ID),
-- foreign key(DT_HT_ID) references htrans(HT_ID)
-- )

-- create table order(
-- OD_ID int auto_increment primary key,
-- OD_STATUS int not null default 1
-- );