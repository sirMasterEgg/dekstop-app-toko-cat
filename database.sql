create database db_toko_cat;
use db_toko_cat;

create table type(
TY_ID int auto_increment primary key,
TY_NAME varchar(100) not null
);

insert into type(TY_ID, TY_NAME) values(1, "Sales Supervisor");
insert into type(TY_ID, TY_NAME) values(2, "Salesperson");
insert into type(TY_ID, TY_NAME) values(3, "Admin");
insert into type(TY_ID, TY_NAME) values(4, "Inventory and Delivery Manager");
insert into type(TY_ID, TY_NAME) values(5, "Human Resource");

create table user(
US_ID int auto_increment primary key,
US_USERNAME varchar(100) not null unique,
US_PASSWORD varchar(100) not null,
US_NAME varchar(100) not null,
US_EMAIL varchar(100),
US_PHONE varchar(20),
US_ADDRESS varchar(500),
US_TY_ID int not null,
US_SALARY int not null default 0,
US_STATUS int not null default 1,
foreign key(US_TY_ID) references type(TY_ID)
);

create table note(
NO_ID int auto_increment primary key,
NO_CREATION_DATETIME datetime not null default now(),
NO_TEXT varchar(1000) not null,
NO_US_ID int not null,
foreign key(NO_US_ID) references user(US_ID)
);

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