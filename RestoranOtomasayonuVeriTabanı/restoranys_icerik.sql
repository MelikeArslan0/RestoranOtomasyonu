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
-- Table structure for table `icerik`
--

DROP TABLE IF EXISTS `icerik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `icerik` (
  `IcerikID` int NOT NULL AUTO_INCREMENT,
  `urunlerID` int NOT NULL,
  `IcerikAD` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`IcerikID`),
  KEY `IX_icerik_urunlerID` (`urunlerID`),
  CONSTRAINT `FK_icerik_urunler_urunlerID` FOREIGN KEY (`urunlerID`) REFERENCES `urunler` (`UrunID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `icerik`
--

LOCK TABLES `icerik` WRITE;
/*!40000 ALTER TABLE `icerik` DISABLE KEYS */;
INSERT INTO `icerik` VALUES (1,1,'zeytin'),(2,4,'Köfte'),(3,4,'Domates'),(4,4,'Soğan'),(5,4,'Turşu'),(6,6,'Kaşar'),(7,6,'Sucuk'),(8,6,'Karışık'),(9,7,'Meyveli'),(10,7,'Çikolatalı'),(11,10,'Kısır'),(12,10,'Mısır'),(13,10,'Zeytin'),(14,10,'Yeşil Zetytin'),(15,10,'Sosis'),(16,10,'Ketçap'),(17,10,'Mayonez'),(18,1,'Börek'),(19,1,'Menemen'),(20,13,'Mantarlı Pizza Menü'),(21,13,'Karışık Pizza Menü'),(22,13,'Peynirli Pizza Menü'),(23,14,'Tavuk Burger Menü'),(24,14,' Köfte Burger Menü');
/*!40000 ALTER TABLE `icerik` ENABLE KEYS */;
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
