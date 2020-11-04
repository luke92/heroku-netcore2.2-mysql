-- --------------------------------------------------------
-- Host:                         sql10.freesqldatabase.com
-- Versión del servidor:         5.5.62-0ubuntu0.14.04.1 - (Ubuntu)
-- SO del servidor:              debian-linux-gnu
-- HeidiSQL Versión:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para sql10374449
CREATE DATABASE IF NOT EXISTS `sql10374449` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `sql10374449`;

-- Volcando estructura para tabla sql10374449.Billete
CREATE TABLE IF NOT EXISTS `Billete` (
  `BilleteID` varchar(255) NOT NULL,
  `Descripcion` longtext,
  PRIMARY KEY (`BilleteID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla sql10374449.Billete: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `Billete` DISABLE KEYS */;
REPLACE INTO `Billete` (`BilleteID`, `Descripcion`) VALUES
	('12', 'Euro'),
	('22', 'Dolar U.S.A'),
	('23', 'Real (*)');
/*!40000 ALTER TABLE `Billete` ENABLE KEYS */;

-- Volcando estructura para tabla sql10374449.Cotizacion
CREATE TABLE IF NOT EXISTS `Cotizacion` (
  `ID` varchar(255) NOT NULL,
  `BilleteId` longtext NOT NULL,
  `PrecioCompra` longtext NOT NULL,
  `PrecioVenta` longtext NOT NULL,
  `FechaObtenido` datetime DEFAULT NULL,
  `FechaGuardado` datetime DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla sql10374449.Cotizacion: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `Cotizacion` DISABLE KEYS */;
REPLACE INTO `Cotizacion` (`ID`, `BilleteId`, `PrecioCompra`, `PrecioVenta`, `FechaObtenido`, `FechaGuardado`, `Active`) VALUES
	('0bf18cb6-c2f8-4f13-956c-7884f393b302', '23', '1275.0000', '1475.0000', '2020-11-04 10:32:00', '2020-11-04 14:51:49', b'1'),
	('3117e3eb-540c-4b61-8336-6660244db50c', '12', '89.5000', '95.5000', '2020-11-04 10:32:00', '2020-11-04 14:51:48', b'1'),
	('342c383e-e7a9-4cf9-a979-1f6b62645742', '23', '1275.0000', '1475.0000', '2020-11-04 10:32:00', '2020-11-04 11:09:53', b'0'),
	('7246cfd4-b3bd-4385-a5db-83bfa6ddd554', '12', '89.5000', '95.5000', '2020-11-03 15:09:00', '2020-11-04 02:04:44', b'0'),
	('7459b643-4bc0-4583-a40e-921c1e422d31', '12', '89.5000', '95.5000', '2020-11-04 10:32:00', '2020-11-04 11:09:53', b'0'),
	('7f42f0fb-a62b-4427-af45-c254505d1e2d', '22', '78.2500', '84.2500', '2020-11-04 10:32:00', '2020-11-04 14:51:47', b'1'),
	('be784857-464d-4130-bd5d-e4390f8c0b1b', '22', '78.2500', '84.2500', '2020-11-04 10:32:00', '2020-11-04 11:09:53', b'0'),
	('ccce4a00-2277-45df-bb70-2d2666a70ca2', '23', '1275.0000', '1475.0000', '2020-11-03 15:09:00', '2020-11-04 02:04:44', b'0'),
	('f5412293-b608-406a-b17a-447243411d97', '22', '78.0000', '84.0000', '2020-11-03 15:09:00', '2020-11-04 02:04:44', b'0');
/*!40000 ALTER TABLE `Cotizacion` ENABLE KEYS */;

-- Volcando estructura para tabla sql10374449.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla sql10374449.__efmigrationshistory: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
REPLACE INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20201101205521_DbInit', '2.2.6-servicing-10079'),
	('20201102034715_DbInit2', '2.2.6-servicing-10079');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
