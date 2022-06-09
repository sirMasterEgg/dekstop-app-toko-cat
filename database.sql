/*
SQLyog Community v13.1.9 (64 bit)
MySQL - 10.4.22-MariaDB : Database - db_toko_cat
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_toko_cat` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `db_toko_cat`;

/*Table structure for table `absen` */

DROP TABLE IF EXISTS `absen`;

CREATE TABLE `absen` (
  `AB_ID` int(11) NOT NULL AUTO_INCREMENT,
  `AB_US_ID` int(11) NOT NULL,
  `AB_DATE` datetime NOT NULL,
  `AB_TOKO_ID` int(11) NOT NULL,
  PRIMARY KEY (`AB_ID`),
  KEY `AB_US_ID` (`AB_US_ID`),
  KEY `absen_ibfk_2` (`AB_TOKO_ID`),
  CONSTRAINT `absen_ibfk_1` FOREIGN KEY (`AB_US_ID`) REFERENCES `user` (`US_ID`),
  CONSTRAINT `absen_ibfk_2` FOREIGN KEY (`AB_TOKO_ID`) REFERENCES `toko` (`TOKO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `absen` */

/*Table structure for table `day` */

DROP TABLE IF EXISTS `day`;

CREATE TABLE `day` (
  `DA_ID` int(11) NOT NULL AUTO_INCREMENT,
  `DA_NAME` varchar(50) NOT NULL,
  PRIMARY KEY (`DA_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;

/*Data for the table `day` */

insert  into `day`(`DA_ID`,`DA_NAME`) values 
(1,'Senin'),
(2,'Selasa'),
(3,'Rabu'),
(4,'Kamis'),
(5,'Jumat'),
(6,'Sabtu'),
(7,'Minggu');

/*Table structure for table `dtrans_item` */

DROP TABLE IF EXISTS `dtrans_item`;

CREATE TABLE `dtrans_item` (
  `DT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `DT_IT_ID` int(11) NOT NULL,
  `DT_AMOUNT` int(11) NOT NULL,
  `DT_SUBTOTAL` int(11) NOT NULL,
  `DT_HT_ID` int(11) NOT NULL,
  `DT_STATUS` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`DT_ID`),
  KEY `DT_IT_ID` (`DT_IT_ID`),
  KEY `DT_HT_ID` (`DT_HT_ID`),
  CONSTRAINT `dtrans_item_ibfk_1` FOREIGN KEY (`DT_IT_ID`) REFERENCES `item` (`IT_ID`),
  CONSTRAINT `dtrans_item_ibfk_2` FOREIGN KEY (`DT_HT_ID`) REFERENCES `htrans_item` (`HT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

/*Data for the table `dtrans_item` */

insert  into `dtrans_item`(`DT_ID`,`DT_IT_ID`,`DT_AMOUNT`,`DT_SUBTOTAL`,`DT_HT_ID`,`DT_STATUS`) values 
(1,1,10,500000,1,1),
(2,2,10,450000,2,1),
(3,3,10,600000,3,1),
(4,4,10,400000,4,1),
(5,5,10,500000,5,1),
(6,6,10,400000,1,1),
(7,7,10,500000,2,1),
(8,8,10,550000,3,1),
(9,9,10,550000,4,1),
(10,10,10,450000,5,1);

/*Table structure for table `htrans_item` */

DROP TABLE IF EXISTS `htrans_item`;

CREATE TABLE `htrans_item` (
  `HT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `HT_US_ID` int(11) NOT NULL,
  `HT_TO_ID` int(11) NOT NULL,
  `HT_DATE` datetime NOT NULL,
  `HT_INVOICE_NUMBER` varchar(12) NOT NULL,
  `HT_TOTAL` int(11) NOT NULL,
  `HT_STATUS` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`HT_ID`),
  KEY `HT_TO_ID` (`HT_TO_ID`),
  KEY `HT_US_ID` (`HT_US_ID`),
  CONSTRAINT `htrans_item_ibfk_1` FOREIGN KEY (`HT_TO_ID`) REFERENCES `toko` (`TOKO_ID`),
  CONSTRAINT `htrans_item_ibfk_2` FOREIGN KEY (`HT_US_ID`) REFERENCES `user` (`US_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

/*Data for the table `htrans_item` */

insert  into `htrans_item`(`HT_ID`,`HT_US_ID`,`HT_TO_ID`,`HT_DATE`,`HT_INVOICE_NUMBER`,`HT_TOTAL`,`HT_STATUS`) values 
(1,6,1,'2022-05-21 17:11:57','12205211001',900000,1),
(2,7,2,'2022-05-21 17:11:57','12205211002',950000,1),
(3,8,3,'2022-05-21 17:11:57','12205211003',1150000,1),
(4,9,4,'2022-05-21 17:11:57','12205211004',950000,1),
(5,10,5,'2022-05-21 17:11:57','12205211005',950000,1);

/*Table structure for table `item` */

DROP TABLE IF EXISTS `item`;

CREATE TABLE `item` (
  `IT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `IT_NAME` varchar(100) NOT NULL,
  `IT_PRICE` int(11) NOT NULL,
  `IT_STOCK` int(11) NOT NULL,
  `IT_STATUS` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`IT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;

/*Data for the table `item` */

insert  into `item`(`IT_ID`,`IT_NAME`,`IT_PRICE`,`IT_STOCK`,`IT_STATUS`) values 
(1,'CobaCat Warna Earthy Tone',50000,200,1),
(2,'CobaCat Warna Burnt Orange',45000,150,1),
(3,'CobaCat Warna Pastel',60000,100,1),
(4,'CobaCat Warna Hazelnut',40000,100,1),
(5,'CobaCat Warna Merah Bata',50000,250,1),
(6,'CobaCat Warna Abu Lilac',40000,150,1),
(7,'CobaCat Warna Coral',50000,100,1),
(8,'CobaCat Warna Beige',55000,225,1),
(9,'CobaCat Warna Broken White',55000,170,1),
(10,'CobaCat Warna Peach',45000,200,1),
(11,'CobaCat Warna Khaki',30000,100,1),
(12,'CobaCat Warna Ivory',55000,250,1);

/*Table structure for table `note` */

DROP TABLE IF EXISTS `note`;

CREATE TABLE `note` (
  `NO_ID` int(11) NOT NULL AUTO_INCREMENT,
  `NO_CREATION_DATETIME` datetime NOT NULL DEFAULT current_timestamp(),
  `NO_TEXT` varchar(1000) NOT NULL,
  `NO_US_ID` int(11) NOT NULL,
  PRIMARY KEY (`NO_ID`),
  KEY `NO_US_ID` (`NO_US_ID`),
  CONSTRAINT `note_ibfk_1` FOREIGN KEY (`NO_US_ID`) REFERENCES `user` (`US_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

/*Data for the table `note` */

insert  into `note`(`NO_ID`,`NO_CREATION_DATETIME`,`NO_TEXT`,`NO_US_ID`) values 
(1,'2022-05-21 15:47:07','User 1 ini adalah contoh user dengan tipe Sales Supervisor.',1),
(2,'2022-05-21 15:47:07','User 2 ini adalah contoh user dengan tipe Salesperson.',2),
(3,'2022-05-21 15:47:07','User 3 ini adalah contoh user dengan tipe Admin.',3),
(4,'2022-05-21 15:47:07','User 4 ini adalah contoh user dengan tipe Inventory and Delivery Manager.',4),
(5,'2022-05-21 15:47:07','User 5 ini adalah contoh user dengan tipe Human Resource.',5),
(6,'2022-06-09 17:56:08','Note dummy 1',6),
(7,'2022-06-09 17:56:08','Note dummy 2',7),
(8,'2022-06-09 17:56:08','Note dummy 3',8),
(9,'2022-06-09 17:56:08','Note dummy 4',9),
(10,'2022-06-09 17:56:08','Note dummy 5',10);

/*Table structure for table `timestamp_stok` */

DROP TABLE IF EXISTS `timestamp_stok`;

CREATE TABLE `timestamp_stok` (
  `TS_ID` int(11) NOT NULL AUTO_INCREMENT,
  `TS_IT_ID` int(11) NOT NULL,
  `TS_VALUE` int(11) NOT NULL,
  `TS_DATE` datetime NOT NULL DEFAULT current_timestamp(),
  `TS_STATUS` int(10) NOT NULL,
  PRIMARY KEY (`TS_ID`),
  KEY `timestamp_stok_ibfk_1` (`TS_IT_ID`),
  CONSTRAINT `timestamp_stok_ibfk_1` FOREIGN KEY (`TS_IT_ID`) REFERENCES `item` (`IT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4;

/*Data for the table `timestamp_stok` */

insert  into `timestamp_stok`(`TS_ID`,`TS_IT_ID`,`TS_VALUE`,`TS_DATE`,`TS_STATUS`) values 
(1,1,210,'2022-05-19 12:00:00',1),
(2,2,160,'2022-05-19 12:00:00',1),
(3,3,110,'2022-05-19 12:00:00',1),
(4,4,110,'2022-05-19 12:00:00',1),
(5,5,260,'2022-05-19 12:00:00',1),
(6,6,160,'2022-05-19 12:00:00',1),
(7,7,110,'2022-05-19 12:00:00',1),
(8,8,235,'2022-05-19 12:00:00',1),
(9,9,180,'2022-05-19 12:00:00',1),
(10,10,210,'2022-05-19 12:00:00',1),
(11,11,100,'2022-05-19 12:00:00',1),
(12,12,250,'2022-05-19 12:00:00',1),
(13,1,10,'2022-05-21 17:11:57',2),
(14,2,10,'2022-05-21 17:11:57',2),
(15,3,10,'2022-05-21 17:11:57',2),
(16,4,10,'2022-05-21 17:11:57',2),
(17,5,10,'2022-05-21 17:11:57',2),
(18,6,10,'2022-05-21 17:11:57',2),
(19,7,10,'2022-05-21 17:11:57',2),
(20,8,10,'2022-05-21 17:11:57',2),
(21,9,10,'2022-05-21 17:11:57',2),
(22,10,10,'2022-05-21 17:11:57',2);

/*Table structure for table `toko` */

DROP TABLE IF EXISTS `toko`;

CREATE TABLE `toko` (
  `TOKO_ID` int(11) NOT NULL AUTO_INCREMENT,
  `TOKO_NAME` varchar(500) NOT NULL,
  `TOKO_ALAMAT` varchar(500) NOT NULL,
  `TOKO_PHONE` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`TOKO_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

/*Data for the table `toko` */

insert  into `toko`(`TOKO_ID`,`TOKO_NAME`,`TOKO_ALAMAT`,`TOKO_PHONE`) values 
(1,'Toko Haha','Jl. Toko 1','0123456789'),
(2,'Toko Hehe','Jl. Toko 2','0123456789'),
(3,'Toko Hihi','Jl. Toko 3','0123456789'),
(4,'Toko Hoho','Jl. Toko 4','0123456789'),
(5,'Toko Huhu','Jl. Toko 5','0123456789');

/*Table structure for table `type` */

DROP TABLE IF EXISTS `type`;

CREATE TABLE `type` (
  `TY_ID` int(11) NOT NULL AUTO_INCREMENT,
  `TY_NAME` varchar(100) NOT NULL,
  PRIMARY KEY (`TY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

/*Data for the table `type` */

insert  into `type`(`TY_ID`,`TY_NAME`) values 
(1,'Sales Supervisor'),
(2,'Salesperson'),
(3,'Admin'),
(4,'Inventory and Delivery Manager'),
(5,'Human Resource');

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `US_ID` int(11) NOT NULL AUTO_INCREMENT,
  `US_USERNAME` varchar(100) NOT NULL,
  `US_PASSWORD` varchar(100) NOT NULL,
  `US_NAME` varchar(100) NOT NULL,
  `US_EMAIL` varchar(100) DEFAULT NULL,
  `US_PHONE` varchar(20) DEFAULT NULL,
  `US_ADDRESS` varchar(500) DEFAULT NULL,
  `US_TY_ID` int(11) NOT NULL,
  `US_SALARY` int(11) NOT NULL DEFAULT 100000,
  `US_STATUS` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`US_ID`),
  KEY `US_TY_ID` (`US_TY_ID`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`US_TY_ID`) REFERENCES `type` (`TY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;

/*Data for the table `user` */

insert  into `user`(`US_ID`,`US_USERNAME`,`US_PASSWORD`,`US_NAME`,`US_EMAIL`,`US_PHONE`,`US_ADDRESS`,`US_TY_ID`,`US_SALARY`,`US_STATUS`) values 
(1,'user1','b3daa77b4c04a9551b8781d03191fe098f325e67','User 1','user1@examplemail.com','0123456789','Jalan User 1',1,1234567890,1),
(2,'user2','a1881c06eec96db9901c7bbfe41c42a3f08e9cb4','User 2','user2@examplemail.com','0123456789','Jalan User 2',2,1234567890,1),
(3,'user3','0b7f849446d3383546d15a480966084442cd2193','User 3','user3@examplemail.com','0123456789','Jalan User 3',3,1234567890,1),
(4,'user4','06e6eef6adf2e5f54ea6c43c376d6d36605f810e','User 4','user4@examplemail.com','0123456789','Jalan User 4',4,1234567890,1),
(5,'user5','7d112681b8dd80723871a87ff506286613fa9cf6','User 5','user5@examplemail.com','0123456789','Jalan User 5',5,1234567890,1),
(6,'sales1','b669283569c1129056bd49700f2f21bd34ab866c','Sales 1','sales1@examplemail.com','0123456789','Jalan Sales 1',2,1234567890,1),
(7,'sales2','504d61eaf5e5a2290e78acd6bbcf7e08cbe66232','Sales 2','sales2@examplemail.com','0123456789','Jalan Sales 2',2,1234567890,1),
(8,'sales3','7f1bf5df1e39f792d0a90105ad4380523d8d517f','Sales 3','sales3@examplemail.com','0123456789','Jalan Sales 3',2,1234567890,1),
(9,'sales4','02581797e1744faf016b5f2654ac4b1c3310d77e','Sales 4','sales4@examplemail.com','0123456789','Jalan Sales 4',2,1234567890,1),
(10,'sales5','7b30747b5c6acee77259c8f0bdd38290dbe5c3fa','Sales 5','sales5@examplemail.com','0123456789','Jalan Sales 5',2,1234567890,1);

/*Table structure for table `visit` */

DROP TABLE IF EXISTS `visit`;

CREATE TABLE `visit` (
  `V_ID` int(11) NOT NULL AUTO_INCREMENT,
  `V_TOKO_ID` int(11) DEFAULT NULL,
  `V_DA_ID` int(11) NOT NULL,
  `V_STATUS` int(11) NOT NULL,
  `V_US_ID` int(11) NOT NULL,
  PRIMARY KEY (`V_ID`),
  KEY `V_US_ID` (`V_US_ID`),
  KEY `V_TOKO_ID` (`V_TOKO_ID`),
  KEY `V_DA_ID` (`V_DA_ID`),
  CONSTRAINT `visit_ibfk_1` FOREIGN KEY (`V_US_ID`) REFERENCES `user` (`US_ID`),
  CONSTRAINT `visit_ibfk_2` FOREIGN KEY (`V_TOKO_ID`) REFERENCES `toko` (`TOKO_ID`),
  CONSTRAINT `visit_ibfk_3` FOREIGN KEY (`V_DA_ID`) REFERENCES `day` (`DA_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4;

/*Data for the table `visit` */

insert  into `visit`(`V_ID`,`V_TOKO_ID`,`V_DA_ID`,`V_STATUS`,`V_US_ID`) values 
(1,1,1,0,2),
(2,2,2,0,6),
(3,3,3,0,7),
(4,4,4,0,8),
(5,5,5,0,9),
(6,1,6,0,10),
(7,2,7,0,2),
(8,3,1,0,6),
(9,4,2,0,7),
(10,5,3,0,8),
(11,1,4,0,9),
(12,2,5,0,10),
(13,3,6,0,2),
(14,4,7,0,6),
(15,5,1,0,7),
(16,1,2,0,8),
(17,2,3,0,9),
(18,3,4,0,10),
(19,4,5,0,2),
(20,5,6,0,6),
(21,1,7,0,7),
(22,2,1,0,8),
(23,3,2,0,9),
(24,4,3,0,10),
(25,5,4,0,2);

/* Function  structure for function  `generateCountAbsen` */

/*!50003 DROP FUNCTION IF EXISTS `generateCountAbsen` */;
DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` FUNCTION `generateCountAbsen`(idUser INT(11), idToko INT(11)
                                ) RETURNS int(11)
BEGIN
	                            DECLARE banyakAbsen INT;
	
	                            SELECT COUNT(*) INTO banyakAbsen FROM absen 
	                            WHERE ab_us_id = idUser AND DATE(ab_date) = DATE(NOW()) AND ab_toko_id = idToko;
	
	                            RETURN banyakAbsen;
                                END */$$
DELIMITER ;

/* Function  structure for function  `generateIDDtrans` */

/*!50003 DROP FUNCTION IF EXISTS `generateIDDtrans` */;
DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` FUNCTION `generateIDDtrans`() RETURNS varchar(50) CHARSET utf8mb4
BEGIN
	                            DECLARE idBesar INT;
	                            DECLARE banyak_dtrans INT;
	
	                            SELECT COUNT(*) INTO banyak_dtrans FROM dtrans_item;
	
	                            IF (banyak_dtrans > 0) THEN
		                            SELECT dt_id INTO idBesar FROM dtrans_item ORDER BY dt_id DESC LIMIT 1;
	                            ELSE 
		                            SET idBesar = 0;
	                            END IF;
	
	                            RETURN idBesar+1;
                                END */$$
DELIMITER ;

/* Function  structure for function  `generateIDHtrans` */

/*!50003 DROP FUNCTION IF EXISTS `generateIDHtrans` */;
DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` FUNCTION `generateIDHtrans`() RETURNS varchar(50) CHARSET utf8mb4
BEGIN
	                            DECLARE idBesar INT;
	                            DECLARE banyak_htrans INT;
	
	                            SELECT COUNT(*) INTO banyak_htrans FROM htrans_item;
	
	                            IF (banyak_htrans > 0) THEN
		                            SELECT ht_id INTO idBesar FROM htrans_item ORDER BY ht_id DESC LIMIT 1;
	                            ELSE 
		                            SET idBesar = 0;
	                            END IF;
	
	                            RETURN idBesar+1;
                                END */$$
DELIMITER ;

/* Function  structure for function  `generateInvoice` */

/*!50003 DROP FUNCTION IF EXISTS `generateInvoice` */;
DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` FUNCTION `generateInvoice`() RETURNS varchar(50) CHARSET utf8mb4
BEGIN
	                            DECLARE hasil VARCHAR(50);
	
	                            DECLARE banyakInvoice INT;
	
	                            SELECT CONCAT('1',SUBSTR(YEAR(NOW()),3,2),
	                            IF(MONTH(NOW()) >= 10, MONTH(NOW()), CONCAT('0',MONTH(NOW()))),
	                            IF(DAY(NOW())>=10, DAY(NOW()), CONCAT('0',DAY(NOW()))),
	                            '1') INTO hasil;
	
	                            SELECT COUNT(*) INTO banyakInvoice FROM htrans_item WHERE ht_invoice_number LIKE CONCAT(hasil, '%');
		
	                            SET hasil = CONCAT(hasil,LPAD(banyakInvoice+1,3,'0'));
	
	                            RETURN hasil;
                                END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
