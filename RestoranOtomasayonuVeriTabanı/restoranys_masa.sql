-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: restoranys
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `masa`
--

DROP TABLE IF EXISTS `masa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `masa` (
  `MasaID` int NOT NULL AUTO_INCREMENT,
  `MusteriID` int NOT NULL,
  `RezervasyonTarihi` datetime(6) NOT NULL,
  `KisiSayisi` int NOT NULL,
  `MasaNumarası` int NOT NULL DEFAULT '0',
  `masasayisiID` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`MasaID`),
  KEY `IX_masa_MusteriID` (`MusteriID`),
  CONSTRAINT `FK_masa_musteri_MusteriID` FOREIGN KEY (`MusteriID`) REFERENCES `musteri` (`MusteriID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `masa`
--

LOCK TABLES `masa` WRITE;
/*!40000 ALTER TABLE `masa` DISABLE KEYS */;
INSERT INTO `masa` VALUES (1,1,'2012-12-12 00:00:00.000000',3,2,2),(2,2,'0001-01-01 00:00:00.000000',0,2,2),(3,9,'0001-01-01 00:00:00.000000',0,0,0),(4,10,'0001-01-01 00:00:00.000000',0,0,0),(5,3,'0001-01-01 00:00:00.000000',1,3,3),(6,4,'2012-12-12 00:00:00.000000',4,4,4),(9,16,'0001-01-01 00:00:00.000000',0,0,0);
/*!40000 ALTER TABLE `masa` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-29 16:29:06
