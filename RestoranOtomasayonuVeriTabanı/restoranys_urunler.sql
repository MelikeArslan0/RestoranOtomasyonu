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
-- Table structure for table `urunler`
--

DROP TABLE IF EXISTS `urunler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `urunler` (
  `UrunID` int NOT NULL AUTO_INCREMENT,
  `KategoriID` int DEFAULT NULL,
  `UrunAD` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UrunFiyat` int DEFAULT NULL,
  `ResimYap` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `puandurum` tinyint(1) NOT NULL,
  `Puan` int DEFAULT NULL,
  PRIMARY KEY (`UrunID`),
  KEY `IX_urunler_KategoriID` (`KategoriID`),
  CONSTRAINT `FK_urunler_kategori_KategoriID` FOREIGN KEY (`KategoriID`) REFERENCES `kategori` (`KategoriID`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `urunler`
--

LOCK TABLES `urunler` WRITE;
/*!40000 ALTER TABLE `urunler` DISABLE KEYS */;
INSERT INTO `urunler` VALUES (1,1,'Serpme Kahvaltı',300,'/images/serpme1.jpg',0,NULL),(2,4,'Limonata',40,'/images/limonata1.jpg',1,250),(3,4,'Latte',75,'/images/latte.jpg',0,NULL),(4,3,'Hamburger',85,'/images/hamburger.jpg',0,NULL),(5,3,'Pizza',70,'/images/o2.jpg',0,NULL),(6,3,'Tost',35,'/images/tost.jpeg',1,350),(7,5,'Pasta',100,'/images/pasta1.jpg',0,NULL),(8,6,'Sezar Salata',90,'/images/sezar.jpg',0,NULL),(9,2,'Mercimek Çorbası',35,'/images/mercimekcorbasi.jpg',0,NULL),(10,3,'Kumpir',80,'/images/kumpir.jpg',0,NULL),(12,1,'Kahvaltı Tabağı ',75,'/images/kahvaltiTabagı.jpg',0,NULL),(13,3,'Pizza Menü',100,'/images/pizzamenu.jpg',1,750),(14,3,'Hamburger Menü',100,'/images/hamburgermenu1.jpg',1,750);
/*!40000 ALTER TABLE `urunler` ENABLE KEYS */;
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
