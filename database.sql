create table type(
TY_ID int auto_increment primary key,
TY_NAME varchar(100) not null
);

create table user(
US_ID int auto_increment primary key,
US_USERNAME varchar(100) not null,
US_PASSWORD varchar(100) not null,
US_NAME varchar(100) not null,
US_TY_ID int not null,
US_SALARY int,
US_STATUS int not null default 1,
foreign key(US_TY_ID) references type(TY_ID)
);

create table item(
IT_ID int auto_increment primary key,
IT_NAME varchar(100) not null,
IT_PRICE int not null,
IT_STOCK int not null,
IT_STATUS int not null default 1
);

create table htrans(
HT_ID int auto_increment primary key,
HT_INVOICE_NUMBER varchar(10) not null,
HT_TOTAL int not null,
HT_STATUS int not null default 1
)

create table dtrans(
DT_ID int auto_increment primary key,
DT_IT_ID int not null,
DT_AMOUNT int not null,
DT_SUBTOTAL int not null,
DT_HT_ID int not null,
DT_STATUS int not null default 1,
foreign key(DT_IT_ID) references item(IT_ID),
foreign key(DT_HT_ID) references htrans(HT_ID)
)

create table order(
OD_ID int auto_increment primary key,
OD_STATUS int not null default 1
);