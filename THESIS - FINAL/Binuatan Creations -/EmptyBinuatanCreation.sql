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
-- Create schema binuatan
--

CREATE DATABASE IF NOT EXISTS binuatan;
USE binuatan;

--
-- Definition of table `agency`
--

DROP TABLE IF EXISTS `agency`;
CREATE TABLE `agency` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `agency` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `agency`
--

/*!40000 ALTER TABLE `agency` DISABLE KEYS */;
/*!40000 ALTER TABLE `agency` ENABLE KEYS */;


--
-- Definition of table `allss`
--

DROP TABLE IF EXISTS `allss`;
CREATE TABLE `allss` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fulln` text NOT NULL,
  `occ` varchar(45) NOT NULL,
  `agency` varchar(45) NOT NULL,
  `amount` float NOT NULL,
  `share` float NOT NULL,
  `indi` float NOT NULL,
  `total` float NOT NULL,
  `no` varchar(45) NOT NULL,
  `date` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `allss`
--

/*!40000 ALTER TABLE `allss` DISABLE KEYS */;
/*!40000 ALTER TABLE `allss` ENABLE KEYS */;


--
-- Definition of table `history`
--

DROP TABLE IF EXISTS `history`;
CREATE TABLE `history` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `event` varchar(45) NOT NULL,
  `who` text NOT NULL,
  `date` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `history`
--

/*!40000 ALTER TABLE `history` DISABLE KEYS */;
/*!40000 ALTER TABLE `history` ENABLE KEYS */;


--
-- Definition of table `login`
--

DROP TABLE IF EXISTS `login`;
CREATE TABLE `login` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Administrator` varchar(45) NOT NULL,
  `pass` varchar(45) NOT NULL,
  `user` varchar(45) NOT NULL,
  `fname` varchar(45) NOT NULL,
  `lname` varchar(45) NOT NULL,
  `contact` varchar(45) NOT NULL,
  `secq` varchar(45) NOT NULL,
  `ans` varchar(45) NOT NULL,
  `intime` varchar(45) NOT NULL,
  `outime` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` (`id`,`Administrator`,`pass`,`user`,`fname`,`lname`,`contact`,`secq`,`ans`,`intime`,`outime`,`status`) VALUES 
 (1,'Admin','red','ple','Redemple','Marcelo','09504671008','Who is my crush?','daphnie','','','Active');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;


--
-- Definition of table `new`
--

DROP TABLE IF EXISTS `new`;
CREATE TABLE `new` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fulln` text NOT NULL,
  `occ` varchar(45) NOT NULL,
  `agency` varchar(45) NOT NULL,
  `Date` varchar(45) NOT NULL,
  `no` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `new`
--

/*!40000 ALTER TABLE `new` DISABLE KEYS */;
/*!40000 ALTER TABLE `new` ENABLE KEYS */;


--
-- Definition of table `print`
--

DROP TABLE IF EXISTS `print`;
CREATE TABLE `print` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fulln` varchar(45) NOT NULL,
  `agency` varchar(45) NOT NULL,
  `amount` float NOT NULL,
  `share` float NOT NULL,
  `indi` float NOT NULL,
  `total` float NOT NULL,
  `date` varchar(45) NOT NULL,
  `sumid` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `print`
--

/*!40000 ALTER TABLE `print` DISABLE KEYS */;
INSERT INTO `print` (`id`,`fulln`,`agency`,`amount`,`share`,`indi`,`total`,`date`,`sumid`) VALUES 
 (1,'Saturday, 23 February 2019','Marcelo,Redemple / Bautista,John / Evio,Kyle',0,4757,285.42,95.14,'95.14','33'),
 (2,'Saturday, 23 February 2019','Marcelo,Redemple / Bautista,John / Evio,Kyle',0,4757,285.42,95.14,'95.14','33'),
 (3,'Saturday, 23 February 2019','Marcelo,Redemple / Bautista,John / Evio,Kyle',0,4757,285.42,95.14,'95.14','33');
/*!40000 ALTER TABLE `print` ENABLE KEYS */;


--
-- Definition of table `summary`
--

DROP TABLE IF EXISTS `summary`;
CREATE TABLE `summary` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fulln` varchar(45) NOT NULL,
  `occ` varchar(45) NOT NULL,
  `agency` varchar(45) NOT NULL,
  `amount` varchar(45) NOT NULL,
  `qr` varchar(45) NOT NULL,
  `gender` varchar(45) NOT NULL,
  `date` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `summary`
--

/*!40000 ALTER TABLE `summary` DISABLE KEYS */;
/*!40000 ALTER TABLE `summary` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
