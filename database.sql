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
  PRIMARY KEY (`AB_ID`),
  KEY `AB_US_ID` (`AB_US_ID`),
  CONSTRAINT `absen_ibfk_1` FOREIGN KEY (`AB_US_ID`) REFERENCES `user` (`US_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `absen` */

/*Table structure for table `day` */

DROP TABLE IF EXISTS `day`;

CREATE TABLE `day` (
  `DA_ID` int(11) NOT NULL AUTO_INCREMENT,
  `DA_NAME` varchar(50) NOT NULL,
  PRIMARY KEY (`DA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `day` */

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `dtrans_item` */

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `htrans_item` */

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;

/*Data for the table `note` */

insert  into `note`(`NO_ID`,`NO_CREATION_DATETIME`,`NO_TEXT`,`NO_US_ID`) values 
(1,'2022-05-21 15:47:07','User 1 ini adalah contoh user dengan tipe Sales Supervisor.',1),
(2,'2022-05-21 15:47:07','User 2 ini adalah contoh user dengan tipe Salesperson.',2),
(3,'2022-05-21 15:47:07','User 3 ini adalah contoh user dengan tipe Admin.',3),
(4,'2022-05-21 15:47:07','User 4 ini adalah contoh user dengan tipe Inventory and Delivery Manager.',4),
(5,'2022-05-21 15:47:07','User 5 ini adalah contoh user dengan tipe Human Resource.',5);

/*Table structure for table `toko` */

DROP TABLE IF EXISTS `toko`;

CREATE TABLE `toko` (
  `TOKO_ID` int(11) NOT NULL AUTO_INCREMENT,
  `TOKO_NAME` varchar(500) NOT NULL,
  PRIMARY KEY (`TOKO_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

/*Data for the table `toko` */

insert  into `toko`(`TOKO_ID`,`TOKO_NAME`) values 
(1,'Toko Cat Haha'),
(2,'Toko Cat Hehe'),
(3,'Toko Cat Hoho');

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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;

/*Data for the table `user` */

insert  into `user`(`US_ID`,`US_USERNAME`,`US_PASSWORD`,`US_NAME`,`US_EMAIL`,`US_PHONE`,`US_ADDRESS`,`US_TY_ID`,`US_SALARY`,`US_STATUS`) values 
(1,'user1','user1','User 1','user1@examplemail.com','0123456789','Jalan User 1',1,1234567890,1),
(2,'user2','user2','User 2','user2@examplemail.com','0123456789','Jalan User 2',2,1234567890,1),
(3,'user3','user3','User 3','user3@examplemail.com','0123456789','Jalan User 3',3,1234567890,1),
(4,'user4','user4','User 4','user4@examplemail.com','0123456789','Jalan User 4',4,1234567890,1),
(5,'user5','user5','User 5','user5@examplemail.com','0123456789','Jalan User 5',5,1234567890,1),
(6,'sales1','sales1','Sales 1','sales1@examplemail.com','0123456789','Jalan Sales 1',2,1234567890,1),
(7,'sales2','sales2','Sales 2','sales2@examplemail.com','0123456789','Jalan Sales 2',2,1234567890,1),
(8,'sales3','sales3','Sales 3','sales3@examplemail.com','0123456789','Jalan Sales 3',2,1234567890,1),
(9,'sales4','sales4','Sales 4','sales4@examplemail.com','0123456789','Jalan Sales 4',2,1234567890,1);

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
  CONSTRAINT `visit_ibfk_1` FOREIGN KEY (`V_US_ID`) REFERENCES `user` (`US_ID`),
  CONSTRAINT `visit_ibfk_2` FOREIGN KEY (`V_TOKO_ID`) REFERENCES `toko` (`TOKO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `visit` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
