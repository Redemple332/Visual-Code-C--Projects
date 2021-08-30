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
-- Definition of table `tbl_log`
--

DROP TABLE IF EXISTS `tbl_log`;
CREATE TABLE `tbl_log` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Login_Am` varchar(15) NOT NULL,
  `Logout_Am` varchar(15) NOT NULL,
  `Login_Pm` varchar(15) NOT NULL,
  `Logout_Pm` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_log`
--

/*!40000 ALTER TABLE `tbl_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_log` ENABLE KEYS */;


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
  `Datelog` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbleventattendance`
--

/*!40000 ALTER TABLE `tbleventattendance` DISABLE KEYS */;
INSERT INTO `tbleventattendance` (`id`,`sid`,`loginAM`,`logoutAM`,`loginPM`,`logoutPM`,`event_id`,`Datelog`) VALUES 
 (1,6,NULL,NULL,NULL,'6:53:47 PM',1,''),
 (2,8,NULL,'1:57:39 PM','4:17:31 PM','7:22:27 PM',1,''),
 (3,5,NULL,NULL,'4:27:47 PM','7:23:01 PM',1,''),
 (4,4,NULL,NULL,NULL,'7:23:15 PM',1,''),
 (5,7,NULL,NULL,'5:58:27 PM','7:25:13 PM',1,''),
 (6,14,NULL,NULL,'5:01:48 PM',NULL,1,''),
 (7,12,NULL,NULL,'5:54:19 PM',NULL,1,''),
 (8,15,NULL,NULL,'5:07:27 PM','6:11:12 PM',1,''),
 (9,11,NULL,NULL,'5:59:51 PM',NULL,1,''),
 (10,16,NULL,NULL,NULL,'6:16:40 PM',1,''),
 (11,17,NULL,NULL,NULL,'6:16:25 PM',1,''),
 (12,18,NULL,NULL,'2:20:54 PM','6:34:26 PM',1,'Friday, August 24, 2018'),
 (13,19,NULL,NULL,'2:20:24 PM','6:46:39 PM',1,'Friday, August 24, 2018'),
 (14,19,NULL,'1:49:36 PM','2:20:24 PM',NULL,1,'Saturday, 25 August 2018'),
 (15,18,NULL,'1:51:22 PM','2:20:54 PM',NULL,1,'Saturday, 25 August 2018'),
 (16,20,NULL,'1:52:20 PM','2:22:45 PM',NULL,1,'Saturday, 25 August 2018'),
 (17,191,'1:48:08 AM',NULL,NULL,NULL,2,'Monday, December 3, 2018');
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
  `active` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbleventslist`
--

/*!40000 ALTER TABLE `tbleventslist` DISABLE KEYS */;
INSERT INTO `tbleventslist` (`id`,`name`,`theme`,`place`,`datefrom`,`dtaeto`,`event_id`,`active`) VALUES 
 (1,'Intramural','habang may oras may pag asa','sports complex','Saturday, August 18, 2018','',1,'1'),
 (2,'a','aa','aaa','Sunday, November 18, 2018','Monday, November 19, 2018',0,'1');
/*!40000 ALTER TABLE `tbleventslist` ENABLE KEYS */;


--
-- Definition of table `tblstudentlist`
--

DROP TABLE IF EXISTS `tblstudentlist`;
CREATE TABLE `tblstudentlist` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ln` varchar(45) DEFAULT NULL,
  `fn` varchar(45) DEFAULT NULL,
  `strand` varchar(45) DEFAULT NULL,
  `qrcode` varchar(45) DEFAULT NULL,
  `evnt_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=501 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblstudentlist`
--

/*!40000 ALTER TABLE `tblstudentlist` DISABLE KEYS */;
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (1,'ABAD',' ARNOLD JOSHUA B.','GAS','abadarnold',1),
 (2,'ABAD',' JEREMY REY NAZIRITE','ICT','abadjeremy',1),
 (3,'ABAO',' MARY GRACE M.','ICT','abaomarygrace',1),
 (4,'ABAPO','MONICA LUCIO','GAS','abapomonica lucio',1),
 (5,'ABDULLA',' ESMAEL','ICT','abdullaesmael',1),
 (6,'ABIN',' REYNARD CARL ','ICT','abinreynard',1),
 (7,'ABIS',' BREX JAE DIMALALUAN','GAS','abisbrexjae',1),
 (8,'ABIS',' KAREN','ICT','abiskaren',1),
 (9,'ABONALES',' BABYLYN M.','HE','abonalesbabylyn',1),
 (10,'ABONILLO',' BRYAN KC','GAS','abonillobryan',1),
 (11,'ABUAN',' JOYCE LAGRADA','GAS','abuanjoyce',1),
 (12,'ACASIO',' DAN MARK T.','ICT','acasiodanmark',1),
 (13,'ADION',' WILEIN GRACE SAURO','HE','adionwileingrace',1),
 (14,'ADRIAS',' GRELYN JOY','ICT','adriasgrelynjoy',1),
 (15,'AGUILAR',' LOUELLA','ICT','aguilarlouella',1),
 (16,'AGUIRRE',' KRIZIA MAY N.','GAS','aguirrekrizia',1),
 (17,'AKASA',' NIKA SAKIRAL','ICT','akasanika',1),
 (18,'ALAGAO',' JOHN MICHAEL O.','GAS','alagaojohnmichael',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (19,'ALASKA',' VINCE ALBERT ','GAS','alaskavince',1),
 (20,'ALFARO',' HANNAH G.','GAS','alfarohannah',1),
 (21,'ALFARO',' MARK DAVID B. ','ICT','alfaromarkdavid',1),
 (22,'ALFARO',' MONICA E.','GAS','alfaromonica',1),
 (23,'ALILI',' NOEMS MARYLENE L.','GAS','alilinoems',1),
 (24,'ALISBO',' VIRBEN BABIERA','HE','alisbovirben',1),
 (25,'ALVARADO',' JOSHUA','GAS','alvaradojoshua',1),
 (26,'ALVAREZ',' DIETHER H. ','HE','alvarezdiether',1),
 (27,'ALVAREZ',' JOYCE','GAS','alvarezjoyce',1),
 (28,'AMAGO',' LOUIE JAY','ICT','amagolouie',1),
 (29,'AMANCA',' KENT LAUREN A. ','ICT','amancakent',1),
 (30,'AMATOS',' ABRAHAM','HE','amatosabraham',1),
 (31,'ANACLITO',' ANGIELIKA','GAS','anaclitoangielika',1),
 (32,'ANCHETA',' JOANNA MARIE V. ','HE','anchetajoanna marie',1),
 (33,'ANDOR',' MOHAMMAD YAASEEN','ICT','andormohammad yaaseen',1),
 (34,'ANIAR',' NESTOR KENNETH ','ICT','aniarnestor kenneth',1),
 (35,'ANIEL',' LEINA BEL VISITACION','GAS','anielleina bel visitacion',1),
 (36,'ANISCO',' JOHN PAUL','ICT','aniscojohn paul',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (37,'ANIS',' JULIUS JR.','GAS','anisjuliusjr',1),
 (38,'APOSTOL',' CHARINA D. ','HE','apostolcharina',1),
 (39,'APOSTOL',' FEDERICO II C.','ICT','apostolfedericoii',1),
 (40,'AQUINO',' KIM DIANE ALILANO','GAS','aquinokim diane alilano',1),
 (41,'ARGA',' CLARAIS JANE S.','HE','argaclarais jane',1),
 (42,'ARGA',' IVAN LOU ARAGON','ICT','argaivan lou aragon',1),
 (43,'ARGA',' PRINCESS ATHEENA KAYLA J.','GAS','argaprincess atheena kayla',1),
 (44,'ARIMOHANAN',' ANDREA JANE V.','ICT','arimohananandrea jane',1),
 (45,'ARTAJO',' LALYN','ICT','artajolalyn',1),
 (46,'ATON',' LIZA MAY A.','ICT','atonliza may',1),
 (47,'ATUN',' JUNNEL','ICT','atunjunnel',1),
 (48,'AUSTRIA',' MARY GRACE ABIS','GAS','austriamarygrace',1),
 (49,'AZARES',' GODWIN JOHN B. ','ICT','azaresgodwin john',1),
 (50,'BABANTE',' NOEMI ','ICT','babantenoemi',1),
 (51,'BACALLA',' EVELYN M. ','GAS','bacallaevelyn',1),
 (52,'BACALTOS',' CAMILLA','ICT','bacaltoscamilla',1),
 (53,'BACANI',' BRYAND JONES L. ','ICT','bacanibryand jones',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (54,'BADILLA',' PAULO S. ','ICT','badillapaulo',1),
 (55,'BADON',' JULES BENEDICT','GAS','badonjules benedict',1),
 (56,'BAGAAN',' HANA MAE','ICT','bagaanhana mae',1),
 (57,'BAGYO',' ALMALYN ASMAN','GAS','bagyoalmalyn asman',1),
 (58,'BANARES',' FRETHSEL TALAGTAG','HE','banaresfrethsel talagtag',1),
 (59,'BANARES',' REGDERF','GAS','banaresregderf',1),
 (60,'BANGCAL',' ABBY CHRIEZL MAE','GAS','bangcalabby chriezl mae',1),
 (61,'BANSUELA',' KATRINA ALFEREZ','GAS','bansuelakatrina alferez',1),
 (62,'BARAL',' LIZAMAE','GAS','barallizamae',1),
 (63,'BARCELONA',' JAY V. ','HE','barcelonajay',1),
 (64,'BARLAS',' ERNIELY','HE','barlaserniely',1),
 (65,'BARONE',' JOHN PATRICK','ICT','baronejohn patrick',1),
 (66,'BARTOLATA',' CIRCA KATE T. ','GAS','bartolatacirca kate',1),
 (67,'BARUELO',' SANTOS','HE','baruelosantos',1),
 (68,'BASILISCO',' MARIE LHOU BELARMINO','GAS','basiliscomarie lhou belarmino',1),
 (69,'BASLAN',' REANN GARDOSE','GAS','baslanreann gardose',1),
 (70,'BATERNA',' JORDAN','ICT','baternajordan',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (71,'BATIANCILA',' BLESSIE','GAS','batiancilablessie',1),
 (72,'BAUTISTA',' ELEUTERIO II L.','GAS','bautistaeleuterioii',1),
 (73,'BAUTISTA',' JOHN PAUL','ICT','bautistajohn paul',1),
 (74,'BAUTISTA',' PRINCE JOHN','GAS','bautistaprince john',1),
 (75,'BAYLES',' NOVELLE','GAS','baylesnovelle',1),
 (76,'BAYLON',' MARIEL L.','GAS','baylonmariel',1),
 (77,'BEHARANG',' ABEL C.','ICT','beharangabel',1),
 (78,'BEHARANG',' LIEZEL','GAS','beharangliezel',1),
 (79,'BELVIZ',' CLAYTON','GAS','belvizclayton',1),
 (80,'BENIG',' MIKKA C.','GAS','benigmikka',1),
 (81,'BERAME',' KIMBERLY ANDAL','GAS','beramekimberly andal',1),
 (82,'BERMEJO',' LEO JR.','GAS','bermejoleojr',1),
 (83,'BERNARDO',' JADE A.','ICT','bernardojade',1),
 (84,'BIAZON',' BRENDA N.','GAS','biazonbrenda',1),
 (85,'BIAZON',' GLENDA','GAS','biazonglenda',1),
 (86,'BILLONES',' RODERICK ','GAS','billonesroderick',1),
 (87,'BINES',' MARK JAYSON','HE','binesmark jayson',1),
 (88,'BINONDO',' MA. CYRA N.','ICT','binondomacyra ',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (89,'BINONDO',' MA. CYZA N.','GAS','binondomacyza',1),
 (90,'BLANCO',' LEONARD ','GAS','blancoleonard',1),
 (91,'BOLIMA',' NIKKO','GAS','bolimanikko',1),
 (92,'BONILLA',' EVAN REY','GAS','bonillaevan rey',1),
 (93,'BONTO',' EDDIZER P.','ICT','bontoeddizer',1),
 (94,'BORES',' SHYZYL JANE','ICT','boresshyzyl jane',1),
 (95,'BORRES',' JOLINA ','GAS','borresjolina',1),
 (96,'BRACERO',' MONICO G. ','ICT','braceromonico',1),
 (97,'BUENO',' ELIZABETH','GAS','buenoelizabeth',1),
 (98,'BULALON',' MERRIAM C.','ICT','bulalonmerriam',1),
 (99,'BUO',' PATRICK LLOYD E.','ICT','buopatrick lloyd',1),
 (100,'CAABAY',' MICHELLE','ICT','caabaymichelle',1),
 (101,'CABANGCALA',' BEVERLY','GAS','cabangcalabeverly',1),
 (102,'CABANZA',' CHERISH JOY','HE','cabanzacherish joy',1),
 (103,'CABANZA',' SHERWIN RIBOT JR.','GAS','cabanzasherwin ribot jr',1),
 (104,'CABILLEDA',' JADE D.','ICT','cabilledajade',1),
 (105,'CABRESTANTE',' JOANNA MARIE S. ','ICT','cabrestantejoanna marie',1),
 (106,'CAGUBCOB',' RICIKEN','GAS','cagubcobriciken',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (107,'CAGUMBAY',' GHELSEY ERIDA T.','GAS','cagumbayghelsey erida',1),
 (108,'CALLEJO',' IDLE FAITH','GAS','callejoidle faith',1),
 (109,'CALMA',' INGRID JUSTINE S.','ICT','calmaingrid justine',1),
 (110,'CAMERO',' MICHELLE VANNE A.','HE','cameromichelle vanne',1),
 (111,'CAMPUGAN',' RIZZA MAE','GAS','campuganrizza mae',1),
 (112,'CANALES',' JEMUEL ','ICT','canalesjemuel',1),
 (113,'CANALES',' MARISOL ','GAS','canalesmarisol',1),
 (114,'CANUT',' RICKY JR. R.','ICT','canutricky jr',1),
 (115,'CARBONELL',' DANIEL IVAN E.','ICT','carbonelldaniel ivan',1),
 (116,'CARBONILLA',' JOSCHUA','GAS','carbonillajoschua',1),
 (117,'CARIASO',' TEAH L.','HE','cariasoteah',1),
 (118,'CARINGAS',' JAMMELLA NINA D.','ICT','caringasjammella nina',1),
 (119,'CARLOS',' KIAN DRAKE J.','ICT','carloskian drake',1),
 (120,'CASALHAY',' MERILY R.','ICT','casalhaymerily',1),
 (121,'CASAYAS',' JIEZCA P.','ICT','casayasjiezca',1),
 (122,'CASTILLO',' ANGELINA','ICT','castilloangelina',1),
 (123,'CATUBIG',' ALJHON KENNETH BARIGA','ICT','catubigaljhon kenneth bariga',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (124,'CAYAO',' LOVELY BIHAG','HE','cayaolovely bihag',1),
 (125,'CELEBRADO',' JEVIE','GAS','celebradojevie',1),
 (126,'CENIZA',' IVAN Q.','ICT','cenizaivan',1),
 (127,'CERVANTES',' JOSHUA B.','GAS','cervantesjoshua',1),
 (128,'CHAVEZ',' HEAVEN','HE','chavezheaven',1),
 (129,'CHUA',' GENLIE SHEEN G. ','GAS','chuagenlie sheen',1),
 (130,'CONDE',' FRANCIS IAN P.','GAS','condefrancis ian',1),
 (131,'CONDESA',' ANA MARIE E.','HE','condesaana marie',1),
 (132,'CORDON',' RUFA','GAS','cordonrufa',1),
 (133,'CORTEL',' GEROME P.','ICT','cortelgerome',1),
 (134,'COSICOL',' MARCELITO JR. A.','ICT','cosicolmarcelito jr',1),
 (135,'CRUZ',' IVY HOPE J.','GAS','cruzivy hope',1),
 (136,'CRUZ',' ROWELLAWI','ICT','cruzrowellawi',1),
 (137,'DABUIT',' JAHZEEL','GAS','dabuitjahzeel',1),
 (138,'DACUAN',' JAKE B.','ICT','dacuanjake',1),
 (139,'DAGANIO',' RYZZALYN FAITH','ICT','daganioryzzalyn faith',1),
 (140,'DAGANTA',' RAMIR R. ','GAS','dagantaramir',1),
 (141,'DAGOT',' GIO ','HE','dagotgio',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (142,'DAGUIO',' JERIMI','GAS','daguiojerimi',1),
 (143,'DALOJO',' CHARINA C.','GAS','dalojocharina',1),
 (144,'DANDAL',' JULIE B.','ICT','dandaljulie',1),
 (145,'DANDAL',' KRIZZA MAE','HE','dandalkrizza mae',1),
 (146,'DAVID',' REGIE A.','ICT','davidregie',1),
 (147,'DEASIS',' NINA JEAN','GAS','deasisnina jean',1),
 (148,'DECIR',' MIA ERIKA M.','HE','decirmia erika',1),
 (149,'DEDIOS',' THALIA TWEIN','GAS','dediosthalia twein',1),
 (150,'DEGUZMAN',' SHIELLAMIE','GAS','deguzmanshiellamie',1),
 (151,'DEJESUS',' ELLA VENUS','HE','dejesusella venus',1),
 (152,'DELACRUZ',' GLENN MARC ','GAS','delacruzglenn marc',1),
 (153,'DELACRUZ',' HARVEY L. ','GAS','delacruzharvey',1),
 (154,'DELACRUZ',' HONEY REGINE','GAS','delacruzhoney regine',1),
 (155,'DELACRUZ',' JOAN NICOLE','GAS','delacruzjoan nicole',1),
 (156,'DELACUESTA',' NIKKA PACALDO','ICT','delacuestanikka pacaldo',1),
 (157,'DELAPENA',' JAYBIE T.','GAS','delapenajaybie',1),
 (158,'DELEON',' PATRICIA','GAS','deleonpatricia',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (159,'DELUNA',' DEXTER JAY','GAS','delunadexter jay',1),
 (160,'DELUNA',' TRIXIE FRANCINE N.','GAS','delunatrixie francine',1),
 (161,'DEMALINAO',' DENNISE KENN','ICT','demalinaodennise kenn',1),
 (162,'DEQUINA',' DARIEL JAKE','HE','dequinadariel jake',1),
 (163,'DESABAYLA',' MICHELLE','GAS','desabaylamichelle',1),
 (164,'DESOY',' JOHN REY','HE','desoyjohn rey',1),
 (165,'DICAR',' MARK ERUEL F.','GAS','dicarmark eruel',1),
 (166,'DISTAL',' THOMAS JACOB','ICT','distalthomas jacob',1),
 (167,'DIZON',' JAYRED RUBEN','ICT','dizonjayred ruben',1),
 (168,'DOBLADO',' IRVINE BILL','ICT','dobladoirvine bill',1),
 (169,'DOCEJO',' LOVELY JOY L.','HE','docejolovely joy',1),
 (170,'DOCTO',' EIKANAH MARIE P.','ICT','doctoeikanah marie',1),
 (171,'DOLDUCO',' ELYSSA ARO','ICT','dolducoelyssa aro',1),
 (172,'DUARTE',' CARLA G.','GAS','duartecarla',1),
 (173,'DUMARAN',' PRINCESS JOY P.','ICT','dumaranprincess joy',1),
 (174,'DYGICO',' NOVIE ANGELA M.','GAS','dygiconovie angela',1),
 (175,'EBAJO',' ANGEL ANN S. ','GAS','ebajoangel ann',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (176,'ECHON',' JEVER G.','ICT','echonjever',1),
 (177,'ECHON',' LEONARD B.','ICT','echonleonard',1),
 (178,'ECLE',' CHRISTINA MAE','HE','eclechristina mae',1),
 (179,'EDANO',' RICHELL F. ','ICT','edanorichell',1),
 (180,'EDRADAN',' MAYLYN','GAS','edradanmaylyn',1),
 (181,'ELEAZAR',' MIA ANGELICA','ICT','eleazarmia angelica',1),
 (182,'ELEJAN',' HAZEL JOY CUTILLAS','GAS','elejanhazel joy cutillas',1),
 (183,'ELOPRE',' JERWIN','HE','eloprejerwin',1),
 (184,'ENDENCIA',' MARY JOY','HE','endenciamary joy',1),
 (185,'ENDRICO',' ROBELYN','GAS','endricorobelyn',1),
 (186,'ENRIQUE',' VON CARLO','ICT','enriquevon carlo',1),
 (187,'ESCATRON',' REALYN S.','GAS','escatronrealyn',1),
 (188,'ESCUREL',' JOHN CARLO O.','ICT','escureljohn carlo',1),
 (189,'ESGUERRA',' DAISY JOY A. ','ICT','esguerradaisy joy',1),
 (190,'ESPARRAGUERRA',' KEZETIA GEOGRAFIA ','HE','esparraguerrakezetia',1),
 (191,'ESPEDIDO',' CASSANDRA LOUISE A.','HE','espedidocassandra louise',1),
 (192,'ESPERANZA',' ZYRUS ALLEN','ICT','esperanzazyrus allen',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (193,'ESPINOSA',' EZRA SHANE','GAS','espinosaezra shane',1),
 (194,'EUROPA',' DORAH GAY L. ','ICT','europadorah gay',1),
 (195,'EVIO',' STEVEN KYLE','ICT','eviosteven kyle',1),
 (196,'FABRIGAS',' MICKY G.','GAS','fabrigasmicky',1),
 (197,'FAIGAO',' JOSIAH ROYCE','GAS','faigaojosiah royce',1),
 (198,'FAJARDO',' MARY DALLENE','GAS','fajardomary dallene',1),
 (199,'FANTILANAN',' JOHN CARLO GACOT','ICT','fantilananjohn carlo gacot',1),
 (200,'FAVILA',' JOHN KENNETH','GAS','favilajohn kenneth',1),
 (201,'FELISARIO',' JONARD','ICT','felisariojonard',1),
 (202,'FELIZARTE',' JAYMARK','GAS','felizartejaymark',1),
 (203,'FERIA',' JOHN PAUL C.','ICT','feriajohn paul',1),
 (204,'FERNANDO',' EUSEBIO S.','ICT','fernandoeusebio',1),
 (205,'FERNANDO',' MICHELLE C.','HE','fernandomichelle',1),
 (206,'FLORES',' ISADORA','ICT','floresisadora',1),
 (207,'FLOREZ',' LOU DANNIELLE P.','HE','florezlou dannielle',1),
 (208,'FORTEZA',' LORENZO III','ICT','fortezalorenzoiii',1),
 (209,'FRANCISCO',' ANGELICA S.','GAS','franciscoangelica',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (210,'FRANCISCO',' JEFFREY M.','ICT','franciscojeffrey',1),
 (211,'FUENTES',' JERLYN V.','ICT','fuentesjerlyn',1),
 (212,'FUENTES',' MELANIE T.','GAS','fuentesmelanie',1),
 (213,'FULVADORA',' WILMER','HE','fulvadorawilmer',1),
 (214,'GABORNO',' GERALD ','ICT','gabornogerald',1),
 (215,'GABUA',' LYN ROSE M.','GAS','gabualyn rose',1),
 (216,'GACITA',' ANNIE A. ','ICT','gacitaannie',1),
 (217,'GACITA',' GEOBEL C.','HE','gacitageobel',1),
 (218,'GACOTT',' SHAINA HAUBREY D. ','ICT','gacottshaina haubrey',1),
 (219,'GADIANO',' JOHN ROLLICK BARKLEY M. ','ICT','gadianojohn rollick barkley',1),
 (220,'GADIANO','JRB','ICT','gadianojrb',1),
 (221,'GAGA-A',' NIKOLAI RYAN','GAS','gaga-anikolai ryan',1),
 (222,'GALANG',' RODELYN','GAS','galangrodelyn',1),
 (223,'GALLO',' JINGKY','GAS','gallojingky',1),
 (224,'GALO',' NOEME','GAS','galonoeme',1),
 (225,'GALVEZ',' FAITH JUSTINE L.','ICT','galvezfaith justine',1),
 (226,'GAMBOA',' JOHN PAUL','HE','gamboajohn paul',1),
 (227,'GAMON',' JHOPEET ANNE','ICT','gamonjhopeet anne',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (228,'GAPUZ',' GLORICA S.','ICT','gapuzglorica',1),
 (229,'GARCIA',' ERECH','GAS','garciaerech',1),
 (230,'GARCIA',' ROGELIO JR. P.','ICT','garciarogeliojr',1),
 (231,'GASPAR',' KENNETH','GAS','gasparkenneth',1),
 (232,'GATCHO','ANGELO','HE','gatchoangelo',1),
 (233,'GAVINA',' KARL EDRIAN V.','ICT','gavinakarl edrian',1),
 (234,'GEONANGA',' HEART JENN D.','ICT','geonangaheart jenn',1),
 (235,'GO',' JEFF ANDREW G.','GAS','gojeff andrew',1),
 (236,'GOMONOD',' CAMILLE','GAS','gomonodcamille',1),
 (237,'GONDA',' LEO ANTHONY','GAS','gondaleo anthony',1),
 (238,'GONOZ',' ANWAR MACMOND ','GAS','gonozanwar macmond',1),
 (239,'GORDEVILLA',' JOHN EMMANUEL M.','ICT','gordevillajohn emmanuel',1),
 (240,'GRATE',' MIKE VINCENT','GAS','gratemike vincent',1),
 (241,'GUARINO',' WYNETH','GAS','guarinowyneth',1),
 (242,'GUIDING',' CHRISTINE JANE','HE','guidingchristine jane',1),
 (243,'GUILLAMAS',' GIFT','HE','guillamasgift',1),
 (244,'GUINTO',' MARK WINDRILL B.','ICT','guintomark windrill',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (245,'GUTIERREZ',' JERICK T.','ICT','gutierrezjerick',1),
 (246,'HABAL',' JAMAICAH MICCAH A.','ICT','habaljamaicah miccah',1),
 (247,'HALILI',' LEONORE P. ','ICT','halilileonore',1),
 (248,'HAMID',' IVAN A. ','ICT','hamidivan',1),
 (249,'HAMJA',' NUR-AISA H.','GAS','hamjanur-aisa',1),
 (250,'HAMJA','SURGAH','HE','hamjasurgah',1),
 (251,'HAUDAR',' APRIL JOY R.','GAS','haudarapriljoy',1),
 (252,'HEREDERO',' RHEANN','GAS','herederorheann',1),
 (253,'HUGO',' ROSIBEL B.','GAS','hugorosibel',1),
 (254,'IBNO',' JEANYCA JANA E.','ICT','ibnojeanyca jana',1),
 (255,'IGNACIO',' RALPH EDWARD ','ICT','ignacioralph edward',1),
 (256,'ILIGAN',' BOBLHYN RISAH','GAS','iliganboblhyn risah',1),
 (257,'INGAN',' JAIRAH RICA F.','ICT','inganjairahrica',1),
 (258,'INGAN',' VIALKA LHYN C.','ICT','inganvialka lhyn',1),
 (259,'JAAPAL',' HALIMA U.','GAS','jaapalhalima',1),
 (260,'JALOCON',' LAICA D.','GAS','jaloconlaica',1),
 (261,'JANGAD',' ANGELICA B.','GAS','jangadangelica',1),
 (262,'JARDIN',' PORTIA MAY L.','GAS','jardinportiamay',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (263,'JARDIN',' ROWENA','ICT','jardinrowena',1),
 (264,'JIMENEZ',' DANICE KIM ','HE','jimenezdanice kim',1),
 (265,'JIMENO',' QUENNIE','GAS','jimenoquennie',1),
 (266,'JIONGCO',' JEBCEN ','ICT','jiongcojebcen',1),
 (267,'JULAO',' NEGIE','ICT','julaonegie',1),
 (268,'JUSAYAN',' RANILLO JR.','ICT','jusayanranillojr',1),
 (269,'KRETZ',' OLIVER EUGEN','GAS','kretzoliver eugen',1),
 (270,'KUHUTAN',' KARIZZA','GAS','kuhutankarizza',1),
 (271,'LABRADOR',' OWEN D.','ICT','labradorowen',1),
 (272,'LABRADOR',' VON THEODRIC','ICT','labradorvon theodric',1),
 (273,'LACAO',' JOHN PAUL C.','GAS','lacaojohn paul',1),
 (274,'LACHICA',' EDZEL B.','HE','lachicaedzel',1),
 (275,'LADICA',' MARIA ANGELICA GRACE','ICT','ladicamaria angelica grace',1),
 (276,'LADJAHASAN',' ELA LESLIE ','GAS','ladjahasanela leslie',1),
 (277,'LADJAHASAN',' JHAJIERAH MAY DIDIK','GAS','ladjahasanjhajierah may didik',1),
 (278,'LADJAHASAN',' KYLA L.','GAS','ladjahasankyla',1),
 (279,'LAGUISMA','CHRISTINE','HE','laguismachristine',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (280,'LAMIGO','MARK JUTE','GAS','lamigomarkjute',1),
 (281,'LAN',' NIKKA JUSTINE','HE','lannikka justine',1),
 (282,'LAPIDANTE',' HANIE MAE','GAS','lapidantehanie mae',1),
 (283,'LAPO',' ARCHIE G.','ICT','lapoarchie',1),
 (284,'LATRACA',' JESSIE JR.','GAS','latracajessie',1),
 (285,'LEDESMA',' JASMINE','HE','ledesmajasmine',1),
 (286,'LIM',' ALJ B.','GAS','limalj',1),
 (287,'LLAMERA',' ARVY JUDD E.','GAS','llameraarvyjudd',1),
 (288,'LONGCAYANA',' JENNE LOU','GAS','longcayanajennelou',1),
 (289,'LONTOC',' ALLEN KRIS','GAS','lontocallenkris',1),
 (290,'LORENZO',' JHONER','ICT','lorenzojhoner',1),
 (291,'LORENZO',' MICHAELA','HE','lorenzomichaela',1),
 (292,'LOSA',' FERNALYN','ICT','losafernalyn',1),
 (293,'LUCBAN',' JESSA L.','GAS','lucbanjessa',1),
 (294,'LUMAWAG',' GENOVEVA ','GAS','lumawaggenoveva',1),
 (295,'LUNAS',' ANTOINETTE CLAIRE ','GAS','lunasantoinette claire',1),
 (296,'MAAS',' EFRAIM','ICT','maasefraim',1),
 (297,'MABERIT',' GERALD N.','GAS','maberitgerald',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (298,'MACEDA',' JESSA MAE','HE','macedajessa mae',1),
 (299,'MADSALI',' ARABIAN A.','GAS','madsaliarabian',1),
 (300,'MAGALLANES',' MARK KEVIN','ICT','magallanesmark kevin',1),
 (301,'MAGBANUA',' JOHN LLOYD','ICT','magbanuajohn lloyd',1),
 (302,'MAGO',' ELSA MAY ','GAS','magoelsa may',1),
 (303,'MAGTO',' IRIZZMAE T.','GAS','magtoirizzmae',1),
 (304,'MAGTULOY',' JAIRA JOY E.','HE','magtuloyjaira joy',1),
 (305,'MALACAD',' ARJEAN B.','ICT','malacadarjean',1),
 (306,'MALENAB','KURT JOWELL','GAS','malenabkurt',1),
 (307,'MAMOD',' JULHARIM','ICT','mamodjulharim',1),
 (308,'MANAEG','KEVIN','GAS','manaegkevin',1),
 (309,'MANALO',' JENNY','GAS','manalojenny',1),
 (310,'MANALO',' TRACY MAE CAMILLE B.','GAS','manalotracy mae camille',1),
 (311,'MANANITA',' RYAN','ICT','mananitaryan',1),
 (312,'MANATAD',' RIZALYN BAUTISTA','ICT','manatadrizalyn bautista',1),
 (313,'MANGA',' JOSHUA','ICT','mangajoshua',1),
 (314,'MANIEGO',' CARL JOSEPH ','ICT','maniegocarl joseph',1),
 (315,'MANIPOL',' JEANIVA M.','HE','manipoljeaniva',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (316,'MANLAVI',' EVAIRAH JOYCE V. ','GAS','manlavievairah joyce',1),
 (317,'MANZON',' SHEENA MAY A.','ICT','manzonsheena may',1),
 (318,'MARABONG',' ROSENIA','HE','marabongrosenia',1),
 (319,'MARANAS',' ARNOLD M.','HE','maranasarnold',1),
 (320,'MARCELO',' REDEMPLE L.','ICT','marceloredemple',1),
 (321,'MARINE',' ROSELYN','GAS','marineroselyn',1),
 (322,'MARQUEZ',' DYLENE ZEY SALI','GAS','marquezdylene zey sali',1),
 (323,'MARZONIA',' ALMIRA ','ICT','marzoniaalmira',1),
 (324,'MASALTA',' GERALINE','ICT','masaltageraline',1),
 (325,'MATANDAG',' JULIE G.','GAS','matandagjulie',1),
 (326,'MATIAS',' SHIELLA MARIE G.','GAS','matiasshiella marie',1),
 (327,'MAYO',' RUBHELL CHRISTIAN KARL U.','ICT','mayorubhell christian karl',1),
 (328,'MEJARES',' HANNA MAE','GAS','mejareshanna mae',1),
 (329,'MENDOZA',' MAUELENE A.','HE','mendozamauelene',1),
 (330,'METRAN',' KRISTINA CASSANDRA','ICT','metrankristina cassandra',1),
 (331,'MITRA',' JOHN','HE','mitrajohn',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (332,'MOISES',' REYCHELLE','ICT','moisesreychelle',1),
 (333,'MONES',' AZIEL S. ','GAS','monesaziel',1),
 (334,'MONTERO',' BRYAN C.','ICT','monterobryan',1),
 (335,'MONTOJO',' JAYSON','ICT','montojojayson',1),
 (336,'MONZON',' NADEM','GAS','monzonnadem',1),
 (337,'MURING',' DANIELLA M.','GAS','muringdaniella',1),
 (338,'NABOR',' AIRAH MARIE ELLAINE D.','GAS','naborairah marie ellaine',1),
 (339,'NABOR',' ALLEN MARK EDREAN D.','GAS','naborallen mark edrean',1),
 (340,'NALING',' JOHN MARK P. ','ICT','nalingjohn mark',1),
 (341,'NARRAZID',' DATU ALJAVAR SHARIFF I.','ICT','narraziddatu aljavar shariff',1),
 (342,'NAVARRO',' CARYLLE ALYZZA MAE','HE','navarrocarylle alyzza mae',1),
 (343,'NERVAL',' LOVEY HANNAH M.','ICT','nervallovey hannah',1),
 (344,'NGAYAO',' KENAH','HE','ngayaokenah',1),
 (345,'NIALA',' CHARLS V. ','GAS','nialacharls',1),
 (346,'NOSTRATIS',' ARTEM','ICT','nostratisartem',1),
 (347,'NOSTRATIS',' RODOLFO CORTES JR.','GAS','nostratisrodolfo cortes jr',1),
 (348,'NUNEZ',' BOBBIE LYKA R.','GAS','nunezbobbie lyka',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (349,'OCAMPO',' GERALD C.','GAS','ocampogerald',1),
 (350,'OCANA',' MARY JOY','ICT','ocanamary joy',1),
 (351,'OLAO',' MARY JOY P.','ICT','olaomary joy',1),
 (352,'OLATAN',' CYRILLE YVONNE','GAS','olatancyrille yvonne',1),
 (353,'OLAYER',' JOHN DARIEL','GAS','olayerjohn dariel',1),
 (354,'OLMEDO',' MELROSE','HE','olmedomelrose',1),
 (355,'ONDA',' DAREEN LABASTIDA','GAS','ondadareen labastida',1),
 (356,'OQUENDO',' LOVELY','HE','oquendolovely',1),
 (357,'ORIOL',' JEWELA ANN','ICT','orioljewela ann',1),
 (358,'ORMIDO',' ABBYGAIL','HE','ormidoabbygail',1),
 (359,'OTTOM',' JEFFERSON','HE','ottomjefferson',1),
 (360,'PABLICO',' PROSPHER KING AARON','GAS','pablicoprospher king aaron',1),
 (361,'PACIONES',' CAMILLE H.','GAS','pacionescamille',1),
 (362,'PADON',' ABEGAIL USTARES','GAS','padonabegail ustares',1),
 (363,'PADRONES',' PRINCESS JOY','GAS','padronesprincess joy',1),
 (364,'PAELMA',' PRINISI AIDA C.','ICT','paelmaprinisi aida',1),
 (365,'PAGATPATAN',' MA. CRYZEL S.','GAS','pagatpatanmacryzel',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (366,'PALANCA',' REA MAE','HE','palancarea mae',1),
 (367,'PALMA',' JAMES ISAAC ','ICT','palmajames isaac',1),
 (368,'PALMONI',' IAN CEAZAR','GAS','palmoniian ceazar',1),
 (369,'PANINGBATAN',' JOAHNA','ICT','paningbatanjoahna',1),
 (370,'PANIZA',' JIGGS VINCENT B. ','HE','panizajiggs vincent',1),
 (371,'PANOLINO',' NOVELIA','GAS','panolinonovelia',1),
 (372,'PANTANILLA',' EMMANUEL','GAS','pantanillaemmanuel',1),
 (373,'PA-ONER',' JAIZEL R.','GAS','pa-onerjaizel',1),
 (374,'PARANGUE',' ERICA','HE','parangueerica',1),
 (375,'PARAS',' JONNALYN M.  ','GAS','parasjonnalyn',1),
 (376,'PATARLAS',' JULIE MARK BRIAN','ICT','patarlasjulie mark brian',1),
 (377,'PATRICIO',' RENZ BRONDELL A.','GAS','patriciorenz brondell',1),
 (378,'PAZ',' CHRISTIAN PETER','GAS','pazchristian peter',1),
 (379,'PEDIGAN',' GEELYN N.','ICT','pedigangeelyn',1),
 (380,'PE',' JUSTIN ALEXANDRA C.','HE','pejustin alexandra',1),
 (381,'PENA',' ANDREW C. ','GAS','penaandrew',1),
 (382,'PENANO',' ALAISA','ICT','penanoalaisa',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (383,'PERALTA',' KATE ELIZABETH L.','GAS','peraltakate elizabeth',1),
 (384,'PERALTA',' MARY DICK G.','GAS','peraltamary dick',1),
 (385,'PERLAS',' KRISTEL CHAYILL','HE','perlaskristel chayill',1),
 (386,'PILAPIL',' AZIEL ANN','HE','pilapilaziel ann',1),
 (387,'PINILI',' RENZ DOMINIC','GAS','pinilirenz dominic',1),
 (388,'PONCEDELEON',' ANNFE MILLENE V.','GAS','poncedeleonannfe millene',1),
 (389,'PUERTOLLANO',' JEFFREY DIANZON','ICT','puertollanojeffrey dianzon',1),
 (390,'QUIJANO',' KAYCEE O.','ICT','quijanokaycee',1),
 (391,'RABAL',' ARGIE','HE','rabalargie',1),
 (392,'RABAYA',' MA. ANGELIKA P.','ICT','rabayamaangelika',1),
 (393,'RADJUDIN',' ALSIMA','GAS','radjudinalsima',1),
 (394,'RAMILO',' KRISTEL JEAN','GAS','ramilokristeljean',1),
 (395,'RAMOS',' MICHELLE','GAS','ramosmichelle',1),
 (396,'RASONABLE',' MARK LUIS','ICT','rasonablemarkluis',1),
 (397,'RAZOTE',' ROSE ANNE','HE','razoterose anne',1),
 (398,'REBUCAS',' KATHLENE','HE','rebucaskathlene',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (399,'RECTO',' QUEENIE','GAS','rectoqueenie',1),
 (400,'RELOJ',' MARIFE S.','HE','relojmarife',1),
 (401,'RELOX',' JELLA MEI','GAS','reloxjella mei',1),
 (402,'RENOSA',' EDJIELYN','GAS','renosaedjielyn',1),
 (403,'REVIL',' CIARA VANESSA','GAS','revilciara vanessa',1),
 (404,'REVILLAS',' JOHN ERICK P.','ICT','revillasjohn erick',1),
 (405,'REYES',' ANDY R.','ICT','reyesandy',1),
 (406,'REYES',' GRACEILLE MAE N.','GAS','reyesgraceille mae',1),
 (407,'REYES',' NANETTE','HE','reyesnanette',1),
 (408,'REYNOSO',' ALJON','ICT','reynosoaljon',1),
 (409,'RICARTE',' MARCHIE A.','GAS','ricartemarchie',1),
 (410,'RIVAC',' KRISTINE JOY C. ','ICT','rivackristine joy',1),
 (411,'RIVETE',' IAN CHRISTIAN A.','GAS','riveteian christian',1),
 (412,'ROMUALDO',' KAREN','HE','romualdokaren',1),
 (413,'RONQUILLO',' MARIA TALA','HE','ronquillomaria tala',1),
 (414,'ROSAL',' CHARITY GRACE N. ','HE','rosalcharity grac',1),
 (415,'ROSENTO',' JAZZ SPENCER','ICT','rosentojazz spencer',1),
 (416,'ROXAS',' CHARRY T.','ICT','roxascharry',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (417,'RUBINO',' BERNAVE','ICT','rubinobernave',1),
 (418,'RUBIO',' ELMER JR.','ICT','rubioelmerjr',1),
 (419,'RUIZ',' GEORGE III','ICT','ruizgeorgeiii',1),
 (420,'SABERON',' JULIR JAY B. ','GAS','saberonjulirjay',1),
 (421,'SACAMAY',' RUSTY','GAS','sacamayrusty',1),
 (422,'SAGUCIO',' KRISTINE JOY','ICT','saguciokristinejoy',1),
 (423,'SALUDSOD',' KENNETH','ICT','saludsodkenneth',1),
 (424,'SAMBUAT',' SALAYDA E.','HE','sambuatsalayda',1),
 (425,'SAMILLAN',' LEVIEN ','ICT','samillanlevien',1),
 (426,'SANJORJO',' JESSA R.','GAS','sanjorjojessa',1),
 (427,'SANTILLA',' MARK JANDY','ICT','santillamarkjandy',1),
 (428,'SANTOS',' CERENA T.','GAS','santoscerena',1),
 (429,'SANTOS',' JERICO A.','ICT','santosjerico',1),
 (430,'SANTOYO',' ALEXANDRA','HE','santoyoalexandra',1),
 (431,'SARATAN',' JOY','GAS','saratanjoy',1),
 (432,'SARMIENTO',' ADRIAL EVAN P.','ICT','sarmientoadrial evan',1),
 (433,'SEDOTES',' JOHN IVAN','ICT','sedotesjohn ivan',1),
 (434,'SEGOVIA',' GERMAINE GWYNETH','GAS','segoviagermaine gwyneth',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (435,'SERIOZA',' CLARISSE HERAMIS','GAS','seriozaclarisse heramis',1),
 (436,'SETIER',' MARK KEVIN','ICT','setiermark kevin',1),
 (437,'SIBUGAN',' NEXMON','HE','sibugannexmon',1),
 (438,'SICHUCO',' LEANO CRIS M.','ICT','sichucoleanocris',1),
 (439,'SILLADORA',' JINGGOY A. ','ICT','silladorajinggoy',1),
 (440,'SILVERIO',' RENALYN A.','GAS','silveriorenalyn',1),
 (441,'SOLANTE',' JOSEPH','GAS','solantejoseph',1),
 (442,'SUICO',' ANGELYN C.','GAS','suicoangelyn',1),
 (443,'SUMALILING',' JEAN ROSE','GAS','sumalilingjeanrose',1),
 (444,'SUMAYANG',' MARCHELLE JANE C.','ICT','sumayangmarchellejane',1),
 (445,'SUMPA',' ABDULA M.','ICT','sumpaabdula',1),
 (446,'SUNGCAN',' QUEENIE S.','GAS','sungcanqueenie',1),
 (447,'SUSULAN',' HANS KENNETH A.','GAS','susulanhanskenneth',1),
 (448,'SUYAT',' ANNA MAY','ICT','suyatannamay',1),
 (449,'TABANGAY',' MELROSE P.','ICT','tabangaymelrose',1),
 (450,'TABANG',' CHRISTIAN','ICT','tabangchristian',1),
 (451,'TABINGA',' ANNIE MAY M. ','ICT','tabingaanniemay',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (452,'TACAL',' JERALD','GAS','tacaljerald',1),
 (453,'TAGLINAO',' JOHN CARLO','HE','taglinaojohncarlo',1),
 (454,'TAHA',' MOHAMMAD AL-ALI','GAS','tahamohammad',1),
 (455,'TAHIMING',' EDELIZA','GAS','tahimingedeliza',1),
 (456,'TALAGTAG',' DAVE JOSEPH ','GAS','talagtagdavejoseph',1),
 (457,'TALAGUIT',' MICHELLE ANN','GAS','talaguitmichelleann',1),
 (458,'TALIMBAY',' DAVE','HE','talimbaydave',1),
 (459,'TANALEON',' LEE ANN ROSE R.','ICT','tanaleonleeannrose',1),
 (460,'TECSON',' ANGELYN','GAS','tecsonangelyn',1),
 (461,'TEODORO',' KURVY JADE','ICT','teodorokurvyjade',1),
 (462,'TOLEDO',' CRIZA MAE M.','GAS','toledocrizamae',1),
 (463,'TRABALLO',' EMERLYN M.','ICT','traballoemerlyn',1),
 (464,'TUANDO',' JONES HEART CYCLONE WAVE D.','HE','tuandojonesheart',1),
 (465,'TUCA',' ROMEL','GAS','tucaromel',1),
 (466,'TUCAY',' JUNIE','ICT','tucayjunie',1),
 (467,'TUCAY',' ROELLA','HE','tucayroella',1),
 (468,'ULANDAY','EVIA ROSE','ICT','ulandayeviarose',1),
 (469,'ULGASAN',' EZHEL','GAS','ulgasanezhel',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (470,'ULSON',' LENY D.','GAS','ulsonleny',1),
 (471,'USON',' STEPHANIE V. ','ICT','usonstephanie',1),
 (472,'VACUNAWA',' KESTRIL MAE','GAS','vacunawakestrilmae',1),
 (473,'VALDESPINA',' HAZEL','ICT','valdespinahazel',1),
 (474,'VALDEZ',' JOHN WILGIE A. ','ICT','valdezjohnwilgie',1),
 (475,'VALDEZ',' JOVELYN','ICT','valdezjovelyn',1),
 (476,'VALENCIA',' ZENIEL MARK CLINT O. ','GAS','valenciazenielmarkclint',1),
 (477,'VARGAS',' ELVIS L.','ICT','vargaselvis',1),
 (478,'VELEZ',' CHERRY MEE','GAS','velezcherrymee',1),
 (479,'VERDIDA',' JOHN MICHAEL','ICT','verdidajohnmichael',1),
 (480,'VICENCIO',' ROXSAN','HE','vicencioroxsan',1),
 (481,'VILBAR',' AXCEL M.','HE','vilbaraxcel',1),
 (482,'VILLABER',' DEXTERIAN L.','HE','villaberdexterian',1),
 (483,'VILLABER',' VICTOR JR. L.','HE','villabervictorjr',1),
 (484,'VILLAFLORES',' DEE JAY V.','GAS','villafloresdeejay',1),
 (485,'VILLALVA',' CARLA ELAINE C. ','GAS','villalvacarlaelaine',1),
 (486,'VILLALVA',' IRISH MAY','GAS','villalvairishmay',1);
INSERT INTO `tblstudentlist` (`id`,`ln`,`fn`,`strand`,`qrcode`,`evnt_id`) VALUES 
 (487,'VILLANUEVA',' JAN EDWARD','GAS','villanuevajan',1),
 (488,'VILLON',' CLAIRE JOY ','GAS','villonclaire',1),
 (489,'VIRAY',' BRYAN LOUIE M.','HE','viraybryanlouie',1),
 (490,'VISCA',' RYAN B.','HE','viscaryan',1),
 (491,'VITERBO',' CORNELIUS JANSEN C. ','GAS','viterbocornelius',1),
 (492,'YANGCO',' JUPHET','HE','yangcojuphet',1),
 (493,'YARA',' JULIUS G.','HE','yarajulius',1),
 (494,'YARA',' MARK JOSHUA','ICT','yaramarkjoshua',1),
 (495,'YAYEN',' JANICE F. ','GAS','yayenjanice',1),
 (496,'YBANEZ',' GLIDEL','HE','ybanezglidel',1),
 (497,'ZABALO',' KEVIN','ICT','zabalokevin',1),
 (498,'ZARAGOZA',' ELLEN MAE S.','GAS','zaragozaellenmae',1),
 (499,'ZUMARAGA',' MA. ANN C.','ICT','www.facebook.com/garylloyd.senoc',1),
 (500,NULL,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `tblstudentlist` ENABLE KEYS */;


--
-- Definition of table `tblstudentlist_old`
--

DROP TABLE IF EXISTS `tblstudentlist_old`;
CREATE TABLE `tblstudentlist_old` (
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
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblstudentlist_old`
--

/*!40000 ALTER TABLE `tblstudentlist_old` DISABLE KEYS */;
INSERT INTO `tblstudentlist_old` (`id`,`fn`,`ln`,`level`,`strand`,`gender`,`contact`,`age`,`bdate`,`address`,`qrcode`,`evnt_id`) VALUES 
 (4,'Marcelito','Cosicol','Grade 12','TVL-ICT  B','Female','09686','17','11/22/2000','Bgy. Tagburos','cosicolmarcelito',1),
 (5,'Junnel','Atun','Grade 12','TVL-ICT  B','Male','344','533','3535','Bgy. Tagburos','atunjunnel',1),
 (6,'Ivan','Hamid','Grade 12','TVL-ICT  B','Male','0954','19','12','Bgy. Irawan','hamidivan',1),
 (7,'mark','alfaro','Grade 12','TVL-ICT  B','Male','09897811234','18','12/30/2000','bgy.tagburos','alfaromark',1),
 (8,'Julie','Dandal','Grade 12','TVL-ICT  B','Female','544','534534','543534','3453454','435345345345',1),
 (9,'jon','Cosicol','fg','f','f','f','f','f','f','f',1),
 (10,'etwe','ewrw','ewr','werew','wer','werw','ewr','werwr','ewrew','',1),
 (11,'werw','ewr','wer','wer','wer','wer','we','werw','wer','',1),
 (12,'gdf','dfgd','dfgd','dfg','dfgd','dfg','dfg','','','1',1),
 (13,'zxczc','zxcz','zxcz','zxcz','zxcz','zxcz','zxcz','Wednesday, August 22, 2018','zxczz','324242423',1),
 (14,'jo','an','asda','sada','asdsa','asd','asdasda','Friday, August 24, 2018','asd','asd',0);
INSERT INTO `tblstudentlist_old` (`id`,`fn`,`ln`,`level`,`strand`,`gender`,`contact`,`age`,`bdate`,`address`,`qrcode`,`evnt_id`) VALUES 
 (15,'jordz','bats','sadaa','asdads','asd','sad','asd','Friday, August 24, 2018','sada','sada',1),
 (16,'james','yup','asd','asd','sad','asd','asd','Friday, August 24, 2018','as','asd',1),
 (17,'ba','bat','asda','asd','as','asd','asd','Friday, August 24, 2018','sad','sad',1),
 (18,'ra','py','','','','','','Friday, August 24, 2018','','',1),
 (19,'sdf','rap','','','','','','Friday, August 24, 2018','','',1),
 (20,'jane','dejero','Grade 11','GAS A','Male','dfsf','sdfs','Saturday, 25 August 2018','sfsdf','sdfds',1),
 (21,'alfaronathan','alfaronathan','Grade 11','as','as','sas','asd','Saturday, 25 August 2018','asd','asd',1),
 (22,'ho','had','Grade 11','as','as','sas','asd','Saturday, 25 August 2018','asd','asd',1);
/*!40000 ALTER TABLE `tblstudentlist_old` ENABLE KEYS */;


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
