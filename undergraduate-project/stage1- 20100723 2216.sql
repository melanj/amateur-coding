-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.1.45-community


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema stock
--

CREATE DATABASE IF NOT EXISTS stock;
USE stock;

--
-- Temporary table structure for view `itemview`
--
DROP TABLE IF EXISTS `itemview`;
DROP VIEW IF EXISTS `itemview`;
CREATE TABLE `itemview` (
  `ItemCode` int(10) unsigned,
  `Description` varchar(200),
  `CategoryID` int(10) unsigned,
  `Category` varchar(200),
  `UnitPrice` double unsigned,
  `Quantity` int(10) unsigned,
  `MinOrderQty` int(10) unsigned,
  `ReorderQty` int(10) unsigned,
  `SupplierID` int(10) unsigned,
  `Supplier` varchar(200)
);

--
-- Temporary table structure for view `receiveditemtoday`
--
DROP TABLE IF EXISTS `receiveditemtoday`;
DROP VIEW IF EXISTS `receiveditemtoday`;
CREATE TABLE `receiveditemtoday` (
  `itemCode` int(10) unsigned,
  `Quantity` int(10) unsigned,
  `receivedDate` datetime
);

--
-- Temporary table structure for view `salesview`
--
DROP TABLE IF EXISTS `salesview`;
DROP VIEW IF EXISTS `salesview`;
CREATE TABLE `salesview` (
  `InvoiceDate` date,
  `InvoiceNo` int(10) unsigned,
  `Customer` varchar(200),
  `PaymentTerm` tinyint(1),
  `Amount` double
);

--
-- Temporary table structure for view `solditemtoday`
--
DROP TABLE IF EXISTS `solditemtoday`;
DROP VIEW IF EXISTS `solditemtoday`;
CREATE TABLE `solditemtoday` (
  `itemCode` int(10) unsigned,
  `Quantity` decimal(33,0)
);

--
-- Definition of table `customer`
--

DROP TABLE IF EXISTS `customer`;
CREATE TABLE `customer` (
  `CusCode` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) NOT NULL,
  `Address` varchar(500) NOT NULL,
  `Phone` varchar(10) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Type` tinyint(1) unsigned NOT NULL,
  `Notes` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`CusCode`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` (`CusCode`,`Name`,`Address`,`Phone`,`Email`,`Type`,`Notes`) VALUES 
 (1,'POS Customer','','','',0,'');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;


--
-- Definition of trigger `T_InsertCustomer`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_InsertCustomer`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_InsertCustomer` AFTER INSERT ON `customer` FOR EACH ROW BEGIN
SET @details=CONCAT(', Name: ', NEW.Name);
CALL transaction('Insert Customer',NEW.CusCode,@details);
END $$

DELIMITER ;

--
-- Definition of trigger `T_UpdateCustomer`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_UpdateCustomer`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_UpdateCustomer` AFTER UPDATE ON `customer` FOR EACH ROW BEGIN
SET @details = IF(OLD.Address<>NEW.Address,CONCAT(', Address: ',OLD.Address, ' to ', NEW.Address),'');
SET @details = IF(OLD.Phone<>NEW.Phone,CONCAT(@details,', Phone: ',OLD.Phone, ' to ', NEW.Phone),@details);
SET @details = IF(OLD.Email<>NEW.Email,CONCAT(@details,', Email: ',OLD.Email, ' to ', NEW.Email),@details);
SET @details = IF(OLD.Notes<>NEW.Notes,CONCAT(@details,', Notes: ',OLD.Notes, ' to ', NEW.Notes),@details);
CALL transaction('Update Customer',OLD.CusCode,@details);
END $$

DELIMITER ;

--
-- Definition of table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
CREATE TABLE `invoice` (
  `InvoiceNo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `CusCode` int(10) unsigned NOT NULL,
  `InvoiceDate` datetime NOT NULL,
  `Total` double NOT NULL,
  `IsCredit` tinyint(1) NOT NULL,
  `IsPaid` tinyint(1) NOT NULL,
  PRIMARY KEY (`InvoiceNo`),
  KEY `FK_invoice_1` (`CusCode`),
  CONSTRAINT `FK_invoice_1` FOREIGN KEY (`CusCode`) REFERENCES `customer` (`CusCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `invoice`
--

/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;


--
-- Definition of trigger `T_InsertInvoice`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_InsertInvoice`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_InsertInvoice` AFTER INSERT ON `invoice` FOR EACH ROW BEGIN
SET @details=CONCAT(', Total: ', NEW.Total);
CALL transaction('Insert Invoice',NEW.InvoiceNo,@details);
END $$

DELIMITER ;

--
-- Definition of trigger `T_UpdateInvoice`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_UpdateInvoice`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_UpdateInvoice` AFTER UPDATE ON `invoice` FOR EACH ROW BEGIN
SET @details=', Paid: true ';
CALL transaction('Update Invoice',NEW.InvoiceNo,@details);
END $$

DELIMITER ;

--
-- Definition of table `item`
--

DROP TABLE IF EXISTS `item`;
CREATE TABLE `item` (
  `ItemCode` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Description` varchar(200) NOT NULL,
  `Category` int(10) unsigned NOT NULL,
  `UnitPrice` double unsigned NOT NULL,
  `Quantity` int(10) unsigned NOT NULL,
  `MinOrderQty` int(10) unsigned NOT NULL,
  `ReorderQty` int(10) unsigned NOT NULL,
  `SupCode` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ItemCode`),
  KEY `FK_1` (`Category`),
  KEY `FK_item_2` (`SupCode`),
  CONSTRAINT `FK_1` FOREIGN KEY (`Category`) REFERENCES `itemcategory` (`CatID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_item_2` FOREIGN KEY (`SupCode`) REFERENCES `supplier` (`SupCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `item`
--

/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` (`ItemCode`,`Description`,`Category`,`UnitPrice`,`Quantity`,`MinOrderQty`,`ReorderQty`,`SupCode`) VALUES 
 (1,'Gel pen set - 12 colour',1,0,205,50,25,1),
 (2,'Modeling Clay - 12 colours',1,0,296,100,50,1),
 (3,'Modeling Clay - 18 colours',1,0,398,100,50,2),
 (4,'Little President Color Pencils -12 Colors',1,0,295,100,50,1),
 (5,'Little President Color Pencils -24 Colors',1,0,196,100,50,1),
 (6,'Atlas Color Pencils - 6 colour',1,0,198,100,50,1),
 (7,'3 star colour pencils - 24 colours',1,0,299,100,50,1),
 (8,'Atlas Platigum Set - 12 Colors',1,0,199,100,50,1),
 (9,'Atlas Platigum Set - 24 Colors',1,0,199,100,50,1),
 (10,'HB Pencils  (12pcs)',1,0,0,100,50,1),
 (11,'Non shaping pencils   (12pcs)',1,0,0,100,50,1),
 (12,'Atlas colour pastal - 12 Colors ',1,0,0,100,50,3),
 (13,'Atlas colour pastal - 24 Colors',1,0,0,100,50,1),
 (14,'Homeran Pastal - 12 Colors',2,0,0,100,50,2),
 (15,'Homeran Pastal - 24 Colors',3,0,0,100,50,3),
 (16,'Reeves Water colour - 12 Colors',4,0,0,100,50,4),
 (17,'Scissors - (6pcs/Box)',4,0,0,100,50,4),
 (18,'Stationery holder (Transparent)',3,0,0,100,50,3),
 (19,'Oxford Instrument box',2,0,0,100,50,2),
 (20,'Paper Clip 32mm  (Box)',2,0,0,100,50,2),
 (21,'Giant Gem Clip 50mm  (Box)',2,0,0,100,50,2),
 (22,'Photocopy paper Modi MX 75 GSM (Ream)',3,0,0,200,50,2),
 (23,'Imation Data CD - 25 Bulk Pack',5,0,0,10,10,2),
 (24,'Imation Data CD - 50 Bulk Pack ',5,0,0,10,10,2),
 (25,'Imation Floppy Diskettes 1.4MB - 10 Pack',5,0,0,10,10,2),
 (27,'Imation Data CD (700 MB) with Cover',5,0,0,50,25,2),
 (28,'Imation DVD with cover',5,0,0,50,25,2),
 (29,'Imation Data CD Rewritable (700MB)',5,0,0,50,25,2),
 (30,'Canon Print Cartridge 24 colour',5,0,0,10,5,2),
 (32,'Canon Print Cartridge BC-05',5,0,0,20,10,2),
 (33,'Computer Printer Ribbon',5,0,0,20,10,2),
 (34,'HP Ribbon Cartridge HP21',5,0,0,20,10,2),
 (35,'Toshiba Print Toner',5,0,0,50,25,1),
 (36,'Printrite Universal Ink Refill',5,0,0,100,50,2),
 (37,'Floppy Diskette Storage box ',5,0,0,100,50,1);
/*!40000 ALTER TABLE `item` ENABLE KEYS */;


--
-- Definition of trigger `T_InsertItem`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_InsertItem`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_InsertItem` AFTER INSERT ON `item` FOR EACH ROW BEGIN
SET @details=CONCAT('Description: ', NEW.Description);
CALL transaction('Insert Item',NEW.ItemCode,@details);
END $$

DELIMITER ;

--
-- Definition of trigger `T_UpdateItem`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_UpdateItem`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_UpdateItem` AFTER UPDATE ON `item` FOR EACH ROW BEGIN
SET @details = IF(OLD.Description<>NEW.Description,CONCAT(', Description: ',OLD.Description, ' to ', NEW.Description),'');
SET @details = IF(OLD.UnitPrice<>NEW.UnitPrice,CONCAT(@details,', UnitPrice: ',OLD.UnitPrice, ' to ', NEW.UnitPrice),@details);
SET @details = IF(OLD.Quantity<>NEW.Quantity,CONCAT(@details,', Quantity: ',OLD.Quantity, ' to ', NEW.Quantity),@details);
SET @details = IF(OLD.MinOrderQty<>NEW.MinOrderQty,CONCAT(@details,', MinOrderQty: ',OLD.MinOrderQty, ' to ', NEW.MinOrderQty),@details);
SET @details = IF(OLD.ReorderQty<>NEW.ReorderQty,CONCAT(@details,', ReorderQty: ',OLD.ReorderQty, ' to ', NEW.ReorderQty),@details);
CALL transaction('Update Item',NEW.ItemCode,@details);
END $$

DELIMITER ;

--
-- Definition of table `itemcategory`
--

DROP TABLE IF EXISTS `itemcategory`;
CREATE TABLE `itemcategory` (
  `CatID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Description` varchar(200) NOT NULL,
  PRIMARY KEY (`CatID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `itemcategory`
--

/*!40000 ALTER TABLE `itemcategory` DISABLE KEYS */;
INSERT INTO `itemcategory` (`CatID`,`Description`) VALUES 
 (1,'School Stationery'),
 (2,'General Stationery'),
 (3,'Computer Stationery'),
 (4,'Packaging Materials'),
 (5,'Filling & Storage Products'),
 (6,'Exercise Books , CR Books & Note Books '),
 (7,'White, Magnetic, Notice & Flip Chart Boards'),
 (8,'Pens, Markers, Highlighters, Pencils');
/*!40000 ALTER TABLE `itemcategory` ENABLE KEYS */;


--
-- Definition of trigger `T_InsertCategory`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_InsertCategory`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_InsertCategory` AFTER INSERT ON `itemcategory` FOR EACH ROW BEGIN
SET @details=CONCAT(', Description: ', NEW.Description);
CALL transaction('Insert Category',NEW.CatID,@details);
END $$

DELIMITER ;

--
-- Definition of table `order`
--

DROP TABLE IF EXISTS `order`;
CREATE TABLE `order` (
  `OrderNo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SupCode` int(10) unsigned NOT NULL,
  `OrderDate` datetime NOT NULL,
  `Total` double NOT NULL DEFAULT '0',
  `received` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`OrderNo`),
  KEY `FK_Order_1` (`SupCode`),
  CONSTRAINT `FK_Order_1` FOREIGN KEY (`SupCode`) REFERENCES `supplier` (`SupCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `order`
--

/*!40000 ALTER TABLE `order` DISABLE KEYS */;
/*!40000 ALTER TABLE `order` ENABLE KEYS */;


--
-- Definition of trigger `T_InsertOrder`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_InsertOrder`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_InsertOrder` AFTER INSERT ON `order` FOR EACH ROW BEGIN
SET @details=CONCAT(', Date: ', NEW.OrderDate);
CALL transaction('Insert Order',NEW.OrderNo,@details);
END $$

DELIMITER ;

--
-- Definition of trigger `T_UpdateOrder`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_UpdateOrder`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_UpdateOrder` AFTER UPDATE ON `order` FOR EACH ROW BEGIN
SET @details=CONCAT(', Received : ', NEW.OrderDate);
CALL transaction('Insert Order',NEW.OrderNo,@details);
END $$

DELIMITER ;

--
-- Definition of table `orderitem`
--

DROP TABLE IF EXISTS `orderitem`;
CREATE TABLE `orderitem` (
  `Ref` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ItemCode` int(10) unsigned NOT NULL,
  `OrderNo` int(10) unsigned NOT NULL,
  `Quantity` int(10) unsigned NOT NULL,
  `UnitCost` double unsigned NOT NULL,
  PRIMARY KEY (`Ref`),
  KEY `FK_orderitem_1` (`OrderNo`),
  KEY `FK_orderitem_2` (`ItemCode`),
  CONSTRAINT `FK_orderitem_1` FOREIGN KEY (`OrderNo`) REFERENCES `order` (`OrderNo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_orderitem_2` FOREIGN KEY (`ItemCode`) REFERENCES `item` (`ItemCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orderitem`
--

/*!40000 ALTER TABLE `orderitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderitem` ENABLE KEYS */;


--
-- Definition of table `payment`
--

DROP TABLE IF EXISTS `payment`;
CREATE TABLE `payment` (
  `Ref` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `InvoiceNo` int(10) unsigned NOT NULL,
  `PaidDate` datetime NOT NULL,
  `Amount` double unsigned NOT NULL,
  `Balance` double NOT NULL,
  PRIMARY KEY (`Ref`),
  KEY `FK_payment_1` (`InvoiceNo`),
  CONSTRAINT `FK_payment_1` FOREIGN KEY (`InvoiceNo`) REFERENCES `invoice` (`InvoiceNo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `payment`
--

/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;


--
-- Definition of trigger `T_InsertPayment`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_InsertPayment`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_InsertPayment` AFTER INSERT ON `payment` FOR EACH ROW BEGIN
SET @details=CONCAT(', Amount: ', NEW.Amount);
CALL transaction('Insert Payment',NEW.Ref,@details);
END $$

DELIMITER ;

--
-- Definition of table `receiveditem`
--

DROP TABLE IF EXISTS `receiveditem`;
CREATE TABLE `receiveditem` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ItemRef` int(10) unsigned NOT NULL,
  `Quantity` int(10) unsigned NOT NULL,
  `receivedDate` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_receiveditem_2` (`Quantity`) USING BTREE,
  KEY `FK_receiveditem_1` (`ItemRef`) USING BTREE,
  CONSTRAINT `FK_receiveditem_1` FOREIGN KEY (`ItemRef`) REFERENCES `orderitem` (`Ref`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `receiveditem`
--

/*!40000 ALTER TABLE `receiveditem` DISABLE KEYS */;
/*!40000 ALTER TABLE `receiveditem` ENABLE KEYS */;


--
-- Definition of table `solditem`
--

DROP TABLE IF EXISTS `solditem`;
CREATE TABLE `solditem` (
  `Ref` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ItemCode` int(10) unsigned NOT NULL,
  `InvoiceNo` int(10) unsigned NOT NULL,
  `Quantity` int(10) unsigned NOT NULL,
  `UnitPrice` double unsigned NOT NULL,
  PRIMARY KEY (`Ref`),
  KEY `FK_SoldItem_1` (`ItemCode`),
  KEY `FK_SoldItem_2` (`InvoiceNo`),
  CONSTRAINT `FK_SoldItem_1` FOREIGN KEY (`ItemCode`) REFERENCES `item` (`ItemCode`),
  CONSTRAINT `FK_SoldItem_2` FOREIGN KEY (`InvoiceNo`) REFERENCES `invoice` (`InvoiceNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `solditem`
--

/*!40000 ALTER TABLE `solditem` DISABLE KEYS */;
/*!40000 ALTER TABLE `solditem` ENABLE KEYS */;


--
-- Definition of table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
CREATE TABLE `supplier` (
  `SupCode` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) NOT NULL,
  `Address` varchar(500) NOT NULL,
  `Phone` varchar(10) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `Email` varchar(200) NOT NULL,
  PRIMARY KEY (`SupCode`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `supplier`
--

/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` (`SupCode`,`Name`,`Address`,`Phone`,`Description`,`Email`) VALUES 
 (1,'East Star Stationery  Co Ltd','Galle','0915570508','Book vender','atlas@slt.lk'),
 (2,'Unitech Office Supplies','Malabe','0110000000','Book vender','spc@slt.lk'),
 (3,'Fair System Office Supplies','Galle','0910000000','Book vender','hac@slt.lk'),
 (4,'New Century Company','Matara, Sri Lanka','0415555555','Book supplier','test@slt.lk');
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;


--
-- Definition of trigger `T_InsertSupplier`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_InsertSupplier`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_InsertSupplier` AFTER INSERT ON `supplier` FOR EACH ROW BEGIN
SET @details=CONCAT(', Name: ', NEW.Name);
CALL transaction('Insert Supplier',NEW.SupCode,@details);
END $$

DELIMITER ;

--
-- Definition of trigger `T_UpdateSupplier`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_UpdateSupplier`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_UpdateSupplier` AFTER UPDATE ON `supplier` FOR EACH ROW BEGIN
SET @details = IF(OLD.Address<>NEW.Address,CONCAT(', Address: ',OLD.Address, ' to ', NEW.Address),'');
SET @details = IF(OLD.Phone<>NEW.Phone,CONCAT(@details,', Phone: ',OLD.Phone, ' to ', NEW.Phone),@details);
SET @details = IF(OLD.Email<>NEW.Email,CONCAT(@details,', Email: ',OLD.Email, ' to ', NEW.Email),@details);
SET @details = IF(OLD.Description<>NEW.Description,CONCAT(@details,', Description: ',OLD.Description, ' to ', NEW.Description),@details);
CALL transaction('Update Customer',OLD.SupCode,@details);
END $$

DELIMITER ;

--
-- Definition of table `transaction_log`
--

DROP TABLE IF EXISTS `transaction_log`;
CREATE TABLE `transaction_log` (
  `user_id` varchar(50) NOT NULL,
  `subject` varchar(50) NOT NULL,
  `subjectRef` varchar(20) NOT NULL,
  `description` varchar(500) NOT NULL,
  `time` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=FIXED;

--
-- Dumping data for table `transaction_log`
--

/*!40000 ALTER TABLE `transaction_log` DISABLE KEYS */;
INSERT INTO `transaction_log` (`user_id`,`subject`,`subjectRef`,`description`,`time`) VALUES 
 ('admin','Insert Category','1',', Description: School Stationery','2010-07-23 22:00:26'),
 ('admin','Insert Category','2',', Description: General Stationery','2010-07-23 22:00:38'),
 ('admin','Insert Category','3',', Description: Computer Stationery','2010-07-23 22:02:03'),
 ('admin','Insert Category','4',', Description: Packaging Materials','2010-07-23 22:02:28'),
 ('admin','Insert Category','5',', Description: Filling & Storage Products','2010-07-23 22:02:41'),
 ('admin','Insert Category','6',', Description: Exercise Books , CR Books & Note Books ','2010-07-23 22:02:54'),
 ('admin','Insert Category','7',', Description: White, Magnetic, Notice & Flip Chart Boards','2010-07-23 22:03:42'),
 ('admin','Insert Category','8',', Description: Pens, Markers, Highlighters, Pencils','2010-07-23 22:05:07'),
 ('admin','Insert Supplier','1',', Name: East Star Stationery  Co Ltd','2010-07-23 22:13:08'),
 ('admin','Insert Supplier','2',', Name: Unitech Office Supplies','2010-07-23 22:13:08'),
 ('admin','Insert Supplier','3',', Name: Fair System Office Supplies','2010-07-23 22:13:08'),
 ('admin','Insert Supplier','4',', Name: New Century Company','2010-07-23 22:13:08'),
 ('admin','Insert Item','1','Description: Gel pen set - 12 colour','2010-07-23 22:13:22'),
 ('admin','Insert Item','2','Description: Modeling Clay - 12 colours','2010-07-23 22:13:22'),
 ('admin','Insert Item','3','Description: Modeling Clay - 18 colours','2010-07-23 22:13:22'),
 ('admin','Insert Item','4','Description: Little President Color Pencils -12 Colors','2010-07-23 22:13:22'),
 ('admin','Insert Item','5','Description: Little President Color Pencils -24 Colors','2010-07-23 22:13:22'),
 ('admin','Insert Item','6','Description: Atlas Color Pencils - 6 colour','2010-07-23 22:13:22'),
 ('admin','Insert Item','7','Description: 3 star colour pencils - 24 colours','2010-07-23 22:13:22'),
 ('admin','Insert Item','8','Description: Atlas Platigum Set - 12 Colors','2010-07-23 22:13:22'),
 ('admin','Insert Item','9','Description: Atlas Platigum Set - 24 Colors','2010-07-23 22:13:22'),
 ('admin','Insert Item','10','Description: HB Pencils  (12pcs)','2010-07-23 22:13:22'),
 ('admin','Insert Item','11','Description: Non shaping pencils   (12pcs)','2010-07-23 22:13:22'),
 ('admin','Insert Item','12','Description: Atlas colour pastal - 12 Colors ','2010-07-23 22:13:22'),
 ('admin','Insert Item','13','Description: Atlas colour pastal - 24 Colors','2010-07-23 22:13:22'),
 ('admin','Insert Item','14','Description: Homeran Pastal - 12 Colors','2010-07-23 22:13:22'),
 ('admin','Insert Item','15','Description: Homeran Pastal - 24 Colors','2010-07-23 22:13:22'),
 ('admin','Insert Item','16','Description: Reeves Water colour - 12 Colors','2010-07-23 22:13:22'),
 ('admin','Insert Item','17','Description: Scissors - (6pcs/Box)','2010-07-23 22:13:22'),
 ('admin','Insert Item','18','Description: Stationery holder (Transparent)','2010-07-23 22:13:22'),
 ('admin','Insert Item','19','Description: Oxford Instrument box','2010-07-23 22:13:22'),
 ('admin','Insert Item','20','Description: Paper Clip 32mm  (Box)','2010-07-23 22:13:22'),
 ('admin','Insert Item','21','Description: Giant Gem Clip 50mm  (Box)','2010-07-23 22:13:22'),
 ('admin','Insert Item','22','Description: Photocopy paper Modi MX 75 GSM (Ream)','2010-07-23 22:13:22'),
 ('admin','Insert Item','23','Description: Imation Data CD - 25 Bulk Pack','2010-07-23 22:13:22'),
 ('admin','Insert Item','24','Description: Imation Data CD - 50 Bulk Pack ','2010-07-23 22:13:22'),
 ('admin','Insert Item','25','Description: Imation Floppy Diskettes 1.4MB - 10 Pack','2010-07-23 22:13:22'),
 ('admin','Insert Item','27','Description: Imation Data CD (700 MB) with Cover','2010-07-23 22:13:22'),
 ('admin','Insert Item','28','Description: Imation DVD with cover','2010-07-23 22:13:22'),
 ('admin','Insert Item','29','Description: Imation Data CD Rewritable (700MB)','2010-07-23 22:13:22'),
 ('admin','Insert Item','30','Description: Canon Print Cartridge 24 colour','2010-07-23 22:13:22'),
 ('admin','Insert Item','32','Description: Canon Print Cartridge BC-05','2010-07-23 22:13:22'),
 ('admin','Insert Item','33','Description: Computer Printer Ribbon','2010-07-23 22:13:22'),
 ('admin','Insert Item','34','Description: HP Ribbon Cartridge HP21','2010-07-23 22:13:22'),
 ('admin','Insert Item','35','Description: Toshiba Print Toner','2010-07-23 22:13:22'),
 ('admin','Insert Item','36','Description: Printrite Universal Ink Refill','2010-07-23 22:13:22'),
 ('admin','Insert Item','37','Description: Floppy Diskette Storage box ','2010-07-23 22:13:22');
/*!40000 ALTER TABLE `transaction_log` ENABLE KEYS */;


--
-- Definition of table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `UserName` varchar(20) NOT NULL,
  `FullName` varchar(45) NOT NULL,
  `Passwd` varchar(100) NOT NULL,
  `Category` tinyint(1) unsigned NOT NULL DEFAULT '3',
  PRIMARY KEY (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`UserName`,`FullName`,`Passwd`,`Category`) VALUES 
 ('admin','Administrtor','*4ACFE3202A5FF5CF467898FC58AAB1D615029441',1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;


--
-- Definition of trigger `T_InsertUser`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_InsertUser`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_InsertUser` AFTER INSERT ON `user` FOR EACH ROW BEGIN
SET @details=CONCAT(', Name: ', NEW.UserName, ', FullName: ' , NEW.FullName, ', Category: ',NEW.Category );
CALL transaction('Insert User','0',@details);
END $$

DELIMITER ;

--
-- Definition of trigger `T_UpdateUser`
--

DROP TRIGGER /*!50030 IF EXISTS */ `T_UpdateUser`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `T_UpdateUser` AFTER UPDATE ON `user` FOR EACH ROW BEGIN
SET @details=CONCAT(', Name: ', NEW.UserName);
CALL transaction('Change Password','0',@details);
END $$

DELIMITER ;

--
-- Definition of procedure `ClearDB`
--

DROP PROCEDURE IF EXISTS `ClearDB`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ClearDB`()
BEGIN
SET @restore='true';
DELETE FROM transaction_log;
DELETE FROM `user`;
DELETE FROM payment;
DELETE FROM receiveditem;
DELETE FROM orderitem;
DELETE FROM `order`;
DELETE FROM solditem;
DELETE FROM invoice;
DELETE FROM item;
DELETE FROM itemcategory;
DELETE FROM customer;
DELETE FROM supplier;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `CurrentInventory`
--

DROP PROCEDURE IF EXISTS `CurrentInventory`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CurrentInventory`()
BEGIN
DECLARE done INT DEFAULT 0;
DECLARE ItmCode,ItmQty,recQty,SldQty INT;
DECLARE ItemDesc VARCHAR(200);
DECLARE sq,rq INT default 0;
DECLARE RowCount, CurIndex int default 0;
DECLARE cur1 CURSOR FOR SELECT SQL_CALC_FOUND_ROWS itemCode,Description,Quantity FROM item;
DECLARE cur2 CURSOR FOR SELECT SQL_CALC_FOUND_ROWS Quantity FROM receiveditemtoday WHERE itemCode=ItmCode;
DECLARE cur3 CURSOR FOR SELECT SQL_CALC_FOUND_ROWS Quantity FROM solditemtoday WHERE itemCode=ItmCode;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
DROP TEMPORARY TABLE IF EXISTS Inventory;
CREATE TEMPORARY TABLE Inventory(ItemCode int,Description VARCHAR(200), Qty int, QtyIn int, QtyOut int);
OPEN cur1;
set RowCount = (Select FOUND_ROWS());
while CurIndex<RowCount do
FETCH cur1 INTO ItmCode, ItemDesc,ItmQty;
OPEN cur2;
FETCH cur2 INTO recQty;
set rq = (Select FOUND_ROWS());
CLOSE cur2;
OPEN cur3;
FETCH cur3 INTO SldQty;
set sq = (Select FOUND_ROWS());
CLOSE cur3;
if rq=1 AND sq=1 then
INSERT INTO Inventory VALUES (ItmCode,ItemDesc,ItmQty,recQty,SldQty);
elseif rq=1 AND sq=0 then
INSERT INTO Inventory VALUES (ItmCode,ItemDesc,ItmQty,recQty,0);
elseif rq=0 AND sq=1 then
INSERT INTO Inventory VALUES (ItmCode,ItemDesc,ItmQty,0,SldQty);
else
INSERT INTO Inventory VALUES (ItmCode,ItemDesc,ItmQty,0,0);
end if;
set CurIndex=CurIndex+1;
end while;
CLOSE cur1;
select * from Inventory;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `OrderitemView`
--

DROP PROCEDURE IF EXISTS `OrderitemView`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrderitemView`(OrderID int)
BEGIN
  DECLARE done INT DEFAULT 0;
  DECLARE cRef, ItmCode,cQuantity, RQuantity INT;
  DECLARE cUnitCost DOUBLE;
  DECLARE cDescription varchar(200);
  DECLARE datafound INT default 0;
  DECLARE RowCount, CurIndex int default 0;

 DECLARE cur1 CURSOR FOR SELECT SQL_CALC_FOUND_ROWS i.Ref, i.ItemCode, j.Description, i.Quantity, i.UnitCost FROM orderitem i, item j WHERE i.ItemCode=j.ItemCode AND i.OrderNo=OrderID;
  DECLARE cur2 CURSOR FOR SELECT SQL_CALC_FOUND_ROWS Quantity FROM receiveditem WHERE ItemRef=cRef;
  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

DROP TEMPORARY TABLE IF EXISTS OrderitemEx;
CREATE TEMPORARY TABLE OrderitemEx(Ref INT, ItemCode INT,Description varchar(200), Quantity INT,ReceivedQuantity INT,UnitCost DOUBLE);

OPEN cur1;
set RowCount = (Select FOUND_ROWS());

while CurIndex<RowCount do
FETCH cur1 INTO cRef, ItmCode,cDescription, cQuantity, cUnitCost;

OPEN cur2;
FETCH cur2 INTO RQuantity;
set datafound = (Select FOUND_ROWS());
CLOSE cur2;

if datafound=1 then
INSERT INTO OrderitemEx VALUES (cRef, ItmCode ,cDescription, cQuantity, RQuantity, cUnitCost);
else
INSERT INTO OrderitemEx VALUES (cRef, ItmCode ,cDescription, cQuantity,0, cUnitCost);
end if;

set CurIndex=CurIndex+1;
end while;

  CLOSE cur1;
select * from OrderitemEx;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `OrderView`
--

DROP PROCEDURE IF EXISTS `OrderView`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrderView`()
BEGIN
DECLARE done INT DEFAULT 0;
  DECLARE cRef,cOrderNo, ItmCode,cQuantity, RQuantity INT;
  DECLARE cUnitCost DOUBLE;
  DECLARE cDescription varchar(200);
  DECLARE cName varchar(200);
  DECLARE Cdate datetime;
  DECLARE Creceived BOOLEAN;
  DECLARE datafound INT default 0;
  DECLARE RowCount, CurIndex int default 0;

DECLARE cur1 CURSOR FOR SELECT SQL_CALC_FOUND_ROWS i.Ref,l.`Name`, i.OrderNo, k.OrderDate,k.received, i.ItemCode, j.Description, i.Quantity, i.UnitCost FROM orderitem i, item j,`order` k, supplier l WHERE i.ItemCode=j.ItemCode AND i.OrderNo=k.OrderNo AND k.SupCode=l.SupCode;
DECLARE cur2 CURSOR FOR SELECT SQL_CALC_FOUND_ROWS Quantity FROM receiveditem WHERE ItemRef=cRef;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

DROP TEMPORARY TABLE IF EXISTS OrderEx;
CREATE TEMPORARY TABLE OrderEx(SupName varchar(200),ORDno INT,ORDdate datetime,ORDreceived BOOLEAN, ItemCode INT,Description varchar(200), Quantity INT,ReceivedQuantity INT,UnitCost DOUBLE,EstAmount  DOUBLE,ActAmount DOUBLE);

OPEN cur1;
set RowCount = (Select FOUND_ROWS());

while CurIndex<RowCount do
FETCH cur1 INTO cRef,cName,cOrderNo,Cdate,Creceived, ItmCode,cDescription, cQuantity, cUnitCost;

OPEN cur2;
FETCH cur2 INTO RQuantity;
set datafound = (Select FOUND_ROWS());
CLOSE cur2;

if datafound=1 then
INSERT INTO OrderEx VALUES (cName,cOrderNo,Cdate,Creceived, ItmCode ,cDescription, cQuantity, RQuantity, cUnitCost,(cUnitCost*cQuantity),(cUnitCost*RQuantity));
else
INSERT INTO OrderEx VALUES (cName,cOrderNo,Cdate,Creceived, ItmCode ,cDescription, cQuantity,0, cUnitCost,(cUnitCost*cQuantity),0);
end if;

set CurIndex=CurIndex+1;
end while;

  CLOSE cur1;
select * from OrderEx order by ORDno;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `StockDemand`
--

DROP PROCEDURE IF EXISTS `StockDemand`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `StockDemand`(IN DateFrom varchar(10),IN DateTo varchar(10))
BEGIN
if DateFrom<>'' AND DateTo<>'' then
select `solditem`.`ItemCode` AS `ItemCode`,`item`.`Description` AS `Description`,sum(`solditem`.`Quantity`) AS `Quantity`,`solditem`.`UnitPrice` AS `unitprice`,sum((`solditem`.`Quantity` * `solditem`.`UnitPrice`)) AS `Total`
from ((`solditem` join `item`) join `invoice`)
where ((`item`.`ItemCode` = `solditem`.`ItemCode`)
and (`solditem`.`InvoiceNo` = `invoice`.`InvoiceNo`)
and (`invoice`.`InvoiceDate` between date(DateFrom) and date(DateTo))) group by `solditem`.`ItemCode`;
ELSE
select `solditem`.`ItemCode` AS `ItemCode`,`item`.`Description` AS `Description`,sum(`solditem`.`Quantity`) AS `Quantity`,`solditem`.`UnitPrice` AS `unitprice`,sum((`solditem`.`Quantity` * `solditem`.`UnitPrice`)) AS `Total`
from ((`solditem` join `item`) join `invoice`)
where ((`item`.`ItemCode` = `solditem`.`ItemCode`)
and (`solditem`.`InvoiceNo` = `invoice`.`InvoiceNo`)) group by `solditem`.`ItemCode`;
END IF;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `transaction`
--

DROP PROCEDURE IF EXISTS `transaction`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `transaction`(subject VARCHAR(50), subjectRef VARCHAR(20),description VARCHAR(500))
BEGIN
DECLARE cuser varchar(50);
if @user<>'' then
SET cuser=@user;
else
SET cuser=user();
end if;
if description<>''
then
if @restore='true' then
SET @restore='true';
else
INSERT into transaction_log (user_id,subject,subjectRef, description,time)
VALUES (cuser,subject,subjectRef,description,now());
end if;
end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of view `itemview`
--

DROP TABLE IF EXISTS `itemview`;
DROP VIEW IF EXISTS `itemview`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `itemview` AS select `i`.`ItemCode` AS `ItemCode`,`i`.`Description` AS `Description`,`i`.`Category` AS `CategoryID`,`j`.`Description` AS `Category`,`i`.`UnitPrice` AS `UnitPrice`,`i`.`Quantity` AS `Quantity`,`i`.`MinOrderQty` AS `MinOrderQty`,`i`.`ReorderQty` AS `ReorderQty`,`i`.`SupCode` AS `SupplierID`,`k`.`Name` AS `Supplier` from ((`item` `i` join `itemcategory` `j`) join `supplier` `k`) where ((`i`.`Category` = `j`.`CatID`) and (`i`.`SupCode` = `k`.`SupCode`));

--
-- Definition of view `receiveditemtoday`
--

DROP TABLE IF EXISTS `receiveditemtoday`;
DROP VIEW IF EXISTS `receiveditemtoday`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `receiveditemtoday` AS select `o`.`ItemCode` AS `itemCode`,`r`.`Quantity` AS `Quantity`,`r`.`receivedDate` AS `receivedDate` from (`receiveditem` `r` join `orderitem` `o`) where ((`r`.`ItemRef` = `o`.`Ref`) and (`r`.`receivedDate` = curdate())) group by `o`.`ItemCode`;

--
-- Definition of view `salesview`
--

DROP TABLE IF EXISTS `salesview`;
DROP VIEW IF EXISTS `salesview`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `salesview` AS select cast(`i`.`InvoiceDate` as date) AS `InvoiceDate`,`i`.`InvoiceNo` AS `InvoiceNo`,`j`.`Name` AS `Customer`,`i`.`IsCredit` AS `PaymentTerm`,`i`.`Total` AS `Amount` from (`invoice` `i` join `customer` `j`) where (`i`.`CusCode` = `j`.`CusCode`);

--
-- Definition of view `solditemtoday`
--

DROP TABLE IF EXISTS `solditemtoday`;
DROP VIEW IF EXISTS `solditemtoday`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `solditemtoday` AS select `a`.`ItemCode` AS `itemCode`,sum(`a`.`Quantity`) AS `Quantity` from (`solditem` `a` join `invoice` `b`) where ((`a`.`InvoiceNo` = `b`.`InvoiceNo`) and (`b`.`InvoiceDate` between curdate() and (curdate() + interval 1 day))) group by `a`.`ItemCode`;



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
