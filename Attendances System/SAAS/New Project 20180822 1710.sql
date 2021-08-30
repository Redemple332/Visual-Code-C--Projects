-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.16


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema db_seas
--

CREATE DATABASE IF NOT EXISTS db_seas;
USE db_seas;

--
-- Definition of table `tbladmin`
--

DROP TABLE IF EXISTS `tbladmin`;
CREATE TABLE `tbladmin` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `un` varchar(45) DEFAULT NULL,
  `pw` varchar(45) DEFAULT NULL,
  `fn` varchar(45) DEFAULT NULL,
  `ln` varchar(45) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbladmin`
--

/*!40000 ALTER TABLE `tbladmin` DISABLE KEYS */;
INSERT INTO `tbladmin` (`id`,`un`,`pw`,`fn`,`ln`,`contact`,`email`) VALUES 
 (1,'GIRLIE','santos123','ADMIN',NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbladmin` ENABLE KEYS */;


--
-- Definition of table `tbleventattendance`
--

DROP TABLE IF EXISTS `tbleventattendance`;
CREATE TABLE `tbleventattendance` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `sid` int(10) unsigned DEFAULT NULL,
  `loginAM` varchar(45) DEFAULT NULL,
  `logoutAM` varchar(45) DEFAULT NULL,
  `loginPM` varchar(45) DEFAULT NULL,
  `logoutPM` varchar(45) DEFAULT NULL,
  `event_id` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbleventattendance`
--

/*!40000 ALTER TABLE `tbleventattendance` DISABLE KEYS */;
INSERT INTO `tbleventattendance` (`id`,`sid`,`loginAM`,`logoutAM`,`loginPM`,`logoutPM`,`event_id`) VALUES 
 (1,6,NULL,NULL,NULL,'6:53:47 PM',NULL),
 (2,8,NULL,'1:57:39 PM',NULL,'7:22:27 PM',NULL),
 (3,5,NULL,NULL,'2:00:56 PM','7:23:01 PM',NULL),
 (4,4,NULL,NULL,NULL,'7:23:15 PM',NULL),
 (5,7,NULL,NULL,NULL,'7:25:13 PM',NULL);
/*!40000 ALTER TABLE `tbleventattendance` ENABLE KEYS */;


--
-- Definition of table `tbleventslist`
--

DROP TABLE IF EXISTS `tbleventslist`;
CREATE TABLE `tbleventslist` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `theme` varchar(45) DEFAULT NULL,
  `place` varchar(45) DEFAULT NULL,
  `datefrom` varchar(45) DEFAULT NULL,
  `dtaeto` varchar(45) NOT NULL,
  `event_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbleventslist`
--

/*!40000 ALTER TABLE `tbleventslist` DISABLE KEYS */;
INSERT INTO `tbleventslist` (`id`,`name`,`theme`,`place`,`datefrom`,`dtaeto`,`event_id`) VALUES 
 (1,'Intramural','habang may oras may pag asa','sports complex','Saturday, August 18, 2018','',1);
/*!40000 ALTER TABLE `tbleventslist` ENABLE KEYS */;


--
-- Definition of table `tblstudentlist`
--

DROP TABLE IF EXISTS `tblstudentlist`;
CREATE TABLE `tblstudentlist` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fn` varchar(45) DEFAULT NULL,
  `ln` varchar(45) DEFAULT NULL,
  `level` varchar(45) DEFAULT NULL,
  `strand` varchar(45) DEFAULT NULL,
  `gender` varchar(45) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `age` varchar(45) DEFAULT NULL,
  `bdate` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `qrcode` varchar(45) DEFAULT NULL,
  `evnt_id` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblstudentlist`
--

/*!40000 ALTER TABLE `tblstudentlist` DISABLE KEYS */;
INSERT INTO `tblstudentlist` (`id`,`fn`,`ln`,`level`,`strand`,`gender`,`contact`,`age`,`bdate`,`address`,`qrcode`,`evnt_id`) VALUES 
 (4,'Marcelito','Cosicol','Grade 12','TVL-ICT  B','Female','09686','17','11/22/2000','Bgy. Tagburos','cosicolmarcelito',1),
 (5,'Junnel','Atun','Grade 12','TVL-ICT  B','Male','344','533','3535','Bgy. Tagburos','atunjunnel',1),
 (6,'Ivan','Hamid','Grade 12','TVL-ICT  B','Male','0954','19','12','Bgy. Irawan','hamidivan',1),
 (7,'mark','alfaro','Grade 12','TVL-ICT  B','Male','09897811234','18','12/30/2000','bgy.tagburos','alfaromark',1),
 (8,'Julie','Dandal','Grade 12','TVL-ICT  B','Female','544','534534','543534','3453454','435345345345',1),
 (9,'jon','Cosicol','fg','f','f','f','f','f','f','f',1),
 (10,'etwe','ewrw','ewr','werew','wer','werw','ewr','werwr','ewrew','',NULL),
 (11,'werw','ewr','wer','wer','wer','wer','we','werw','wer','',NULL),
 (12,'gdf','dfgd','dfgd','dfg','dfgd','dfg','dfg','','','1',NULL),
 (13,'zxczc','zxcz','zxcz','zxcz','zxcz','zxcz','zxcz','Wednesday, August 22, 2018','zxczz','324242423',1);
/*!40000 ALTER TABLE `tblstudentlist` ENABLE KEYS */;


--
-- Definition of table `tbluser`
--

DROP TABLE IF EXISTS `tbluser`;
CREATE TABLE `tbluser` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fn` varchar(45) NOT NULL,
  `ln` varchar(45) NOT NULL,
  `un` varchar(45) NOT NULL,
  `pw` varchar(45) NOT NULL,
  `contact` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `position` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbluser`
--

/*!40000 ALTER TABLE `tbluser` DISABLE KEYS */;
INSERT INTO `tbluser` (`id`,`fn`,`ln`,`un`,`pw`,`contact`,`email`,`position`,`status`) VALUES 
 (1,'Marcelito','Cosicol','mars','cos123','0920','@gmail','admin',''),
 (2,'Junnel','Atun','jun','atun123','0932','@gmail.com','user','');
/*!40000 ALTER TABLE `tbluser` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
