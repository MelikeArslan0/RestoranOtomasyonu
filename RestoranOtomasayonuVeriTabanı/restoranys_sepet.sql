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
-- Table structure for table `sepet`
--

DROP TABLE IF EXISTS `sepet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sepet` (
  `SepetID` int NOT NULL AUTO_INCREMENT,
  `urunlerID` int NOT NULL,
  `IcerikID` int NOT NULL,
  `Adet` int NOT NULL DEFAULT '0',
  `Tutar` double NOT NULL DEFAULT '0',
  `MasaID` int DEFAULT NULL,
  `TerminalID` int DEFAULT NULL,
  PRIMARY KEY (`SepetID`),
  KEY `IX_sepet_IcerikID` (`IcerikID`),
  KEY `IX_sepet_urunlerID` (`urunlerID`),
  KEY `MasaID` (`MasaID`),
  KEY `TerminalID` (`TerminalID`),
  CONSTRAINT `FK_sepet_icerik_IcerikID` FOREIGN KEY (`IcerikID`) REFERENCES `icerik` (`IcerikID`) ON DELETE CASCADE,
  CONSTRAINT `FK_sepet_urunler_urunlerID` FOREIGN KEY (`urunlerID`) REFERENCES `urunler` (`UrunID`) ON DELETE CASCADE,
  CONSTRAINT `sepet_ibfk_1` FOREIGN KEY (`MasaID`) REFERENCES `masa` (`MasaID`),
  CONSTRAINT `sepet_ibfk_2` FOREIGN KEY (`TerminalID`) REFERENCES `terminal` (`TerminalID`)
) ENGINE=InnoDB AUTO_INCREMENT=196 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sepet`
--

LOCK TABLES `sepet` WRITE;
/*!40000 ALTER TABLE `sepet` DISABLE KEYS */;
INSERT INTO `sepet` VALUES (189,1,1,4,1200,1,4),(190,2,1,4,160,1,4),(191,2,1,1,0,1,4),(192,1,1,2,600,2,4),(193,14,1,1,80,1,4),(194,6,1,1,0,1,4);
/*!40000 ALTER TABLE `sepet` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-29 16:29:05
