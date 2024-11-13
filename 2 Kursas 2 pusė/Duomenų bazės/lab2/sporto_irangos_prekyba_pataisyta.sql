-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 24, 2023 at 08:08 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.0.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sporto_irangos_prekyba_pataisyta`
--

-- --------------------------------------------------------

--
-- Table structure for table `darbuotojai`
--

CREATE TABLE `darbuotojai` (
  `vardas` varchar(255) NOT NULL,
  `pavarde` varchar(255) NOT NULL,
  `tabelio_nr` int(11) NOT NULL,
  `fk_sporto_irangos_parduotuve` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `darbuotojai`
--

INSERT INTO `darbuotojai` (`vardas`, `pavarde`, `tabelio_nr`, `fk_sporto_irangos_parduotuve`) VALUES
('Thorpe', 'Nance', 1, 1),
('Georgiana', 'Colbran', 2, 2),
('Job', 'Stuckow', 3, 3),
('Cale', 'Clementucci', 4, 4),
('Harmonie', 'Avieson', 5, 5),
('Kacie', 'Burnell', 6, 6),
('Lorne', 'Mariot', 7, 7),
('Luci', 'Palay', 8, 8),
('Dorisa', 'Ashbe', 9, 9),
('Tillie', 'Belfitt', 10, 10),
('Gian', 'Goldsmith', 11, 11),
('Llewellyn', 'MacFarlan', 12, 12),
('Harrie', 'Aglione', 13, 13),
('Hamel', 'Burchell', 14, 14),
('Leupold', 'Bakhrushkin', 15, 15),
('Torrey', 'Warner', 16, 16),
('Catlaina', 'Derrick', 17, 17),
('Marie-jeanne', 'Oakden', 18, 18),
('Rosemarie', 'Bunnell', 19, 19),
('Gennie', 'Fancy', 20, 20),
('Lyssa', 'Dymoke', 21, 21),
('Oneida', 'Shorthouse', 22, 22),
('Renelle', 'Sycamore', 23, 23),
('Ilyse', 'Kelwaybamber', 24, 24),
('Randie', 'Gunningham', 25, 25),
('Jordan', 'Thomasson', 26, 26),
('Stacy', 'Gligori', 27, 27),
('Osbert', 'Gercken', 28, 28),
('Malinde', 'Mounce', 29, 29),
('Portia', 'Borge', 30, 30);

-- --------------------------------------------------------

--
-- Table structure for table `klientai`
--

CREATE TABLE `klientai` (
  `asmens_kodas` int(11) NOT NULL,
  `vardas` varchar(255) NOT NULL,
  `pavarde` varchar(255) NOT NULL,
  `gimimo_data` date NOT NULL,
  `telefonas` varchar(255) NOT NULL,
  `e_pastas` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `klientai`
--

INSERT INTO `klientai` (`asmens_kodas`, `vardas`, `pavarde`, `gimimo_data`, `telefonas`, `e_pastas`) VALUES
(5009403, 'Chrysa', 'Whiteside', '1994-06-03', '9746944801', 'cwhitesidek@naver.com'),
(5076015, 'Kayley', 'Shea', '1996-03-03', '1337656064', 'kshean@wufoo.com'),
(5097584, 'Judith', 'Alfonzo', '1997-04-11', '8444846783', 'jalfonzo2@google.ca'),
(5109504, 'Emlen', 'Timby', '1993-06-27', '6607812993', 'etimby1@eventbrite.com'),
(5179253, 'Thia', 'Borkett', '1990-09-08', '2919427026', 'tborketto@wikimedia.org'),
(5224641, 'Claretta', 'Rolland', '1998-01-13', '4185569159', 'crolland5@constantcontact.com'),
(5230478, 'Rudolfo', 'Lydiate', '1990-09-01', '5024467686', 'rlydiatem@hibu.com'),
(5231750, 'Bowie', 'Bools', '1996-06-24', '8557796156', 'bboolsa@meetup.com'),
(5241250, 'Maurizio', 'Uzzell', '1996-07-23', '8236690066', 'muzzellq@yahoo.co.jp'),
(5251015, 'Izak', 'Venneur', '1992-02-06', '5467044364', 'ivenneurh@amazon.co.uk'),
(5308413, 'Brad', 'Gercke', '1997-06-05', '6691167399', 'bgerckeb@cam.ac.uk'),
(5344993, 'Norbie', 'Loweth', '1993-05-16', '7184986580', 'nlowetht@unesco.org'),
(5369648, 'Sileas', 'Davidge', '1996-09-13', '1048372397', 'sdavidged@senate.gov'),
(5387271, 'Andrea', 'Smitheram', '1996-09-06', '1284327435', 'asmitherami@mtv.com'),
(5420570, 'Doralin', 'Hearse', '1999-02-26', '4653043358', 'dhearsel@hubpages.com'),
(5465570, 'Dunc', 'Kaemena', '2000-01-13', '2682378266', 'dkaemenae@google.it'),
(5497228, 'Sue', 'Vousden', '1996-08-09', '8719161545', 'svousdenf@twitpic.com'),
(5526160, 'Jonell', 'Jeratt', '1994-07-23', '8397977097', 'jjerattj@vistaprint.com'),
(5528465, 'Lisbeth', 'Tottie', '1990-05-23', '5383717053', 'ltottieg@senate.gov'),
(5599783, 'Verge', 'Flegg', '1999-04-22', '5659159101', 'vflegg0@webmd.com'),
(5630142, 'Clementia', 'Elsby', '1999-06-10', '4231145380', 'celsbyr@comcast.net'),
(5733610, 'Danna', 'O\'Clery', '1996-02-15', '4265129693', 'doclery9@meetup.com'),
(5766862, 'Von', 'Rusling', '1999-04-05', '1162845657', 'vruslingc@ftc.gov'),
(5786544, 'Thalia', 'Fransewich', '1991-10-14', '5404532491', 'tfransewich6@icq.com'),
(5807919, 'Quentin', 'Millsom', '1996-12-12', '3114870049', 'qmillsom3@themeforest.net'),
(5812861, 'Kimmi', 'Boddis', '1993-10-19', '1692065048', 'kboddis4@icq.com'),
(5823499, 'Ruthi', 'Burnsall', '1996-07-29', '3866350699', 'rburnsall7@gizmodo.com'),
(5835277, 'Darrin', 'Willmett', '1992-02-18', '6115947846', 'dwillmettp@webeden.co.uk'),
(5898563, 'Cleve', 'Garlic', '1997-08-04', '6476957784', 'cgarlics@china.com.cn'),
(5978108, 'Margalit', 'Perrott', '1994-10-21', '5376731502', 'mperrott8@businessinsider.com');

-- --------------------------------------------------------

--
-- Table structure for table `medziagos`
--

CREATE TABLE `medziagos` (
  `medziagos_id` int(11) NOT NULL,
  `name` char(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `medziagos`
--

INSERT INTO `medziagos` (`medziagos_id`, `name`) VALUES
(1, 'plienas'),
(2, 'plasmase'),
(3, 'guma'),
(4, 'neoprenas'),
(5, 'poliamidas');

-- --------------------------------------------------------

--
-- Table structure for table `miestai`
--

CREATE TABLE `miestai` (
  `pavadinimas` varchar(255) NOT NULL,
  `miesto_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `miestai`
--

INSERT INTO `miestai` (`pavadinimas`, `miesto_id`) VALUES
('Chai Nat', 1),
('Bollène', 2),
('Shofirkon', 3),
('Figueiró dos Vinhos', 4),
('Ādaži', 5),
('Paris 12', 6),
('Abengourou', 7),
('Rabah', 8),
('Figueiredo', 9),
('Balkanabat', 10),
('Dhahi', 11),
('Fiditi', 12),
('Fujisawa', 13),
('Yōkaichiba', 14),
('Wuma', 15),
('Beni Khiar', 16),
('El Cantón', 17),
('Purworejo', 18),
('Bambuí', 19),
('Young America', 20),
('Stockholm', 21),
('Tādif', 22),
('Wilkowice', 23),
('Thetford-Mines', 24),
('Sixi', 25),
('Grimstad', 26),
('Miaotou', 27),
('Mossendjo', 28),
('Bandundu', 29),
('Dongshan', 30),
('Vilns', 32);

-- --------------------------------------------------------

--
-- Table structure for table `parametrai`
--

CREATE TABLE `parametrai` (
  `svoris` float NOT NULL,
  `ilgis` float NOT NULL,
  `patvarumas` varchar(255) NOT NULL,
  `plotis` float NOT NULL,
  `medziaga` int(11) NOT NULL,
  `spalva` int(11) NOT NULL,
  `parametro_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `parametrai`
--

INSERT INTO `parametrai` (`svoris`, `ilgis`, `patvarumas`, `plotis`, `medziaga`, `spalva`, `parametro_id`) VALUES
(170.2, 3.3, 'mazas', 1.3, 5, 3, 7),
(179.2, 2, 'mazas', 2.9, 5, 1, 8),
(3.4, 4.4, 'didelis', 3.9, 4, 5, 9),
(141, 2.3, 'vidutinis', 1.6, 3, 1, 10),
(50, 1.7, 'didelis', 3.6, 2, 3, 11),
(111.3, 3.9, 'mazas', 1.4, 4, 2, 12),
(8.4, 1.3, 'mazas', 3.5, 1, 4, 13),
(192.5, 2.5, 'mazas', 4.3, 5, 1, 14),
(117.4, 4.5, 'mazas', 1.4, 4, 1, 15),
(15.9, 2, 'vidutinis', 1.6, 2, 2, 16),
(28.4, 3.1, 'didelis', 3.2, 3, 1, 18),
(88.7, 1.5, 'vidutinis', 2.1, 4, 1, 19),
(59.9, 2, 'vidutinis', 3.4, 2, 1, 20),
(137.5, 1.2, 'mazas', 1.8, 3, 2, 21),
(187, 2, 'mazas', 1.9, 3, 3, 22),
(100.7, 3.5, 'mazas', 1.6, 1, 4, 23),
(146.9, 2.8, 'vidutinis', 1.5, 2, 1, 24),
(85.3, 1.5, 'didelis', 3.8, 2, 1, 25),
(123.8, 1.8, 'didelis', 4.5, 2, 3, 26),
(156.3, 3.5, 'didelis', 2.8, 3, 1, 27),
(95.6, 3.2, 'didelis', 3.7, 1, 3, 28),
(187.2, 2.4, 'mazas', 2.6, 2, 2, 30),
(1, 0, 'j', 0, 2, 2, 32);

-- --------------------------------------------------------

--
-- Table structure for table `perkamos_prekes`
--

CREATE TABLE `perkamos_prekes` (
  `kiekis` int(11) NOT NULL,
  `kaina` float NOT NULL,
  `fk_uzsakymas` int(11) NOT NULL,
  `fk_preke` int(11) NOT NULL,
  `fk_prekes_kaina_galioja_nuo` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `perkamos_prekes`
--

INSERT INTO `perkamos_prekes` (`kiekis`, `kaina`, `fk_uzsakymas`, `fk_preke`, `fk_prekes_kaina_galioja_nuo`) VALUES
(15, 548.4, 1, 1, '2022-11-20'),
(30, 626.4, 2, 2, '2023-02-21'),
(65, 117.3, 3, 3, '2022-12-18'),
(43, 504.8, 4, 4, '2022-06-20'),
(36, 757.3, 5, 5, '2023-01-03'),
(24, 189.8, 6, 6, '2022-07-26'),
(59, 979.3, 7, 7, '2022-06-02'),
(25, 240.4, 8, 8, '2022-08-15'),
(11, 32.1, 9, 9, '2022-12-20'),
(47, 189.4, 10, 10, '2022-04-17'),
(65, 17, 11, 11, '2022-03-27'),
(59, 945.8, 12, 12, '2022-10-22'),
(71, 543.9, 13, 13, '2022-11-24'),
(78, 337.6, 14, 14, '2022-03-28'),
(86, 161.8, 15, 15, '2022-08-29'),
(55, 905.4, 16, 16, '2023-02-01'),
(26, 405.2, 17, 17, '2022-12-08'),
(39, 205.5, 18, 18, '2022-06-01'),
(98, 653.8, 19, 19, '2023-02-11'),
(62, 989.1, 20, 20, '2022-11-18'),
(68, 293, 21, 21, '2022-09-24'),
(22, 84.2, 22, 22, '2022-04-15'),
(51, 343.6, 23, 23, '2022-08-17'),
(89, 233.8, 24, 24, '2022-05-28'),
(56, 681.6, 25, 25, '2022-12-07'),
(88, 653.8, 26, 26, '2023-02-24'),
(65, 889, 27, 27, '2022-10-14'),
(86, 329.7, 28, 28, '2022-09-05'),
(33, 990.2, 29, 29, '2022-03-04'),
(36, 105.3, 30, 30, '2022-08-21');

-- --------------------------------------------------------

--
-- Table structure for table `prekes`
--

CREATE TABLE `prekes` (
  `pavadinimas` varchar(255) NOT NULL,
  `aprasymas` varchar(255) NOT NULL,
  `prekes_id` int(11) NOT NULL,
  `fk_tiekejas` int(11) NOT NULL,
  `fk_parametras` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prekes`
--

INSERT INTO `prekes` (`pavadinimas`, `aprasymas`, `prekes_id`, `fk_tiekejas`, `fk_parametras`) VALUES
('Ntags', 'Aneurysmal bone cyst, unspecified forearm', 19, 19, 19),
('Rhycero', 'Shop (commercial) as the place of occurrence of the external cause', 20, 20, 20),
('Trilith', 'Atrophy of globe, bilateral', 21, 21, 21),
('Plajo', 'Pulmonary histoplasmosis capsulati, unspecified', 22, 22, 22),
('Kanoodle', 'Dislocation of interphalangeal joint of right lesser toe(s), subsequent encounter', 23, 23, 23),
('Realmix', 'Laceration with foreign body of unspecified thumb without damage to nail, sequela', 24, 24, 24),
('Skyba', 'Exposure to smoke in uncontrolled fire, not in building or structure', 25, 25, 25),
('Zoonoodle', 'Protrusio acetabuli', 26, 26, 26),
('Wordpedia', 'Acute contact otitis externa, right ear', 27, 27, 27);

-- --------------------------------------------------------

--
-- Table structure for table `prekiu_kainos`
--

CREATE TABLE `prekiu_kainos` (
  `galioja_nuo` date NOT NULL,
  `galioja_iki` date NOT NULL,
  `kaina` float NOT NULL,
  `fk_preke` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prekiu_kainos`
--

INSERT INTO `prekiu_kainos` (`galioja_nuo`, `galioja_iki`, `kaina`, `fk_preke`) VALUES
('2022-04-15', '2022-07-15', 111.3, 22),
('2022-05-28', '2022-08-28', 167, 24),
('2022-08-17', '2022-11-17', 622.2, 23),
('2022-09-24', '2022-12-24', 751.4, 21),
('2022-10-14', '2023-01-14', 901.1, 27),
('2022-11-18', '2023-02-18', 443.9, 20),
('2022-12-07', '2023-03-07', 492.7, 25),
('2023-02-11', '2023-05-11', 219.6, 19),
('2023-02-24', '2023-05-24', 967.6, 26);

-- --------------------------------------------------------

--
-- Table structure for table `saskaitos`
--

CREATE TABLE `saskaitos` (
  `saskaitos_nr` int(11) NOT NULL,
  `data` date NOT NULL,
  `suma` float NOT NULL,
  `saskaitos_id` int(11) NOT NULL,
  `fk_uzsakymas` int(11) NOT NULL,
  `fk_klientas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `saskaitos`
--

INSERT INTO `saskaitos` (`saskaitos_nr`, `data`, `suma`, `saskaitos_id`, `fk_uzsakymas`, `fk_klientas`) VALUES
(5009, '2023-02-08', 567.3, 1, 1, 5599783),
(5245, '2022-10-12', 325.5, 2, 2, 5109504),
(5486, '2022-06-26', 122.1, 3, 3, 5097584),
(5111, '2022-04-02', 541.8, 4, 4, 5807919),
(5350, '2022-06-17', 307.4, 5, 5, 5812861),
(5481, '2023-02-18', 544.5, 7, 7, 5786544),
(5098, '2022-08-12', 650.8, 8, 8, 5823499),
(5236, '2023-01-04', 631, 9, 9, 5978108),
(5052, '2023-02-14', 365.2, 10, 10, 5733610),
(5382, '2022-08-18', 592.6, 11, 11, 5231750),
(5813, '2022-05-18', 482.3, 12, 12, 5308413),
(5263, '2022-06-01', 846.8, 13, 13, 5766862),
(5420, '2022-11-20', 895.7, 14, 14, 5369648),
(5402, '2022-05-14', 415.7, 15, 15, 5465570),
(5586, '2022-04-26', 972.1, 16, 16, 5497228),
(5056, '2023-01-27', 973.7, 17, 17, 5528465),
(5791, '2022-03-24', 372, 18, 18, 5251015),
(5721, '2023-02-13', 117.7, 19, 19, 5387271),
(5063, '2022-09-20', 279.1, 20, 20, 5526160),
(5794, '2022-03-15', 505.8, 21, 21, 5009403),
(5258, '2022-03-31', 364.6, 22, 22, 5420570),
(5293, '2022-08-02', 166.4, 23, 23, 5230478),
(5583, '2022-09-06', 221.1, 24, 24, 5076015),
(5948, '2022-09-25', 117.9, 25, 25, 5179253),
(5932, '2022-11-07', 40.5, 26, 26, 5835277),
(5779, '2022-10-14', 803.9, 27, 27, 5241250),
(5941, '2022-12-10', 719.2, 28, 28, 5630142),
(5946, '2022-07-31', 710.4, 29, 29, 5898563),
(5038, '2023-02-02', 798, 30, 30, 5344993);

-- --------------------------------------------------------

--
-- Table structure for table `spalvos`
--

CREATE TABLE `spalvos` (
  `spalvos_id` int(11) NOT NULL,
  `name` char(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `spalvos`
--

INSERT INTO `spalvos` (`spalvos_id`, `name`) VALUES
(1, 'juoda'),
(2, 'balta'),
(3, 'raudona'),
(4, 'melyna'),
(5, 'ruda'),
(6, 'zalia');

-- --------------------------------------------------------

--
-- Table structure for table `sporto_irangos_parduotuves`
--

CREATE TABLE `sporto_irangos_parduotuves` (
  `pavadinimas` varchar(255) NOT NULL,
  `adresas` varchar(255) NOT NULL,
  `telefonas` varchar(255) NOT NULL,
  `e_pastas` varchar(255) NOT NULL,
  `parduotuves_id` int(11) NOT NULL,
  `fk_miestas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sporto_irangos_parduotuves`
--

INSERT INTO `sporto_irangos_parduotuves` (`pavadinimas`, `adresas`, `telefonas`, `e_pastas`, `parduotuves_id`, `fk_miestas`) VALUES
('Brightdog', 'Sangzhou', '5363672410', 'dsiebert0@qq.com', 1, 1),
('Skyble', 'Phoenix', '6022597457', 'ktancock1@shop-pro.jp', 2, 2),
('Fivechat', 'Salitral', '6357255225', 'ggillibrand2@nifty.com', 3, 3),
('Vidoo', 'Waitangi', '5844343441', 'wfilyushkin3@jugem.jp', 4, 4),
('Tazz', 'Xiaohe', '1449116872', 'phelliker4@hatena.ne.jp', 5, 5),
('Shuffledrive', 'El Cafetal', '1685935737', 'mmouan5@stanford.edu', 6, 6),
('Oyondu', 'Contagem', '5657414879', 'jolivie6@facebook.com', 7, 7),
('Dablist', 'Alameda', '7752258673', 'nbirtwhistle7@diigo.com', 8, 8),
('Wordware', 'Jaguaruana', '8508883627', 'gmacias8@deviantart.com', 9, 9),
('Zoonder', 'Zaječí', '1829159903', 'sgrishunin9@jalbum.net', 10, 10),
('Fivebridge', 'Máncora', '9232263848', 'hjarmyna@nytimes.com', 11, 11),
('Skippad', 'Arranhó', '5488780187', 'jkomorowskib@cnbc.com', 12, 12),
('Twitternation', 'Xinhui', '4335757617', 'dmcalpinc@techcrunch.com', 13, 13),
('Brainverse', 'Avarua', '6698773364', 'einsoled@gmpg.org', 14, 14),
('Shuffletag', 'Feteira Pequena', '1762226329', 'whurringe@ovh.net', 15, 15),
('Tambee', 'Changning', '6537645521', 'tbellanyf@eepurl.com', 16, 16),
('Zoomlounge', 'Seremban', '1105925730', 'nascheg@flavors.me', 17, 17),
('Midel', 'Cisarap', '6768148773', 'lstarkeyh@sitemeter.com', 18, 18),
('LiveZ', 'Tilburg', '9347815112', 'joloshini@hao123.com', 19, 19),
('Devify', 'Zbytków', '7478464901', 'oswaytej@google.com.br', 20, 20),
('Topicware', 'Tomobe', '2571093350', 'vjustunk@163.com', 21, 21),
('Photobug', 'Huansheng', '3674656815', 'rsperringl@pagesperso-orange.fr', 22, 22),
('Feedmix', 'San Javier', '5855675561', 'cwhistanm@ehow.com', 23, 23),
('Yabox', 'Kota Kinabalu', '2557087210', 'sskupinskin@sun.com', 24, 24),
('Flashpoint', 'Savanna-la-Mar', '1905054097', 'calleyno@aol.com', 25, 25),
('Edgewire', 'Argel', '9416979756', 'jhedinghamp@yahoo.co.jp', 26, 26),
('Photojam', 'Muladbucad', '6942592337', 'gchatenierq@com.com', 27, 27),
('Tambee', 'Xiache', '9518535053', 'tswordr@ning.com', 28, 28),
('Edgetag', 'Ozerne', '8183398622', 'frichess@dailymotion.com', 29, 29),
('Browseblab', 'Buena Esperanza', '9176100768', 'rkaysert@vkontakte.ru', 30, 30);

-- --------------------------------------------------------

--
-- Table structure for table `tiekejai`
--

CREATE TABLE `tiekejai` (
  `tiekejo_id` int(11) NOT NULL,
  `pavadinimas` varchar(255) NOT NULL,
  `telefonas` varchar(255) NOT NULL,
  `e_pastas` varchar(255) NOT NULL,
  `adresas` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tiekejai`
--

INSERT INTO `tiekejai` (`tiekejo_id`, `pavadinimas`, `telefonas`, `e_pastas`, `adresas`) VALUES
(6, 'Blogtag', '4504888329', 'njohnson5@adobe.com', '6660 Bashford Court'),
(8, 'Flashdog', '3559780701', 'dscarisbrick7@list-manage.com', '38 Redwing Alley'),
(9, 'Vimbo', '6283003460', 'smckendo8@hostgator.com', '85223 Monterey Point'),
(10, 'Omba', '2003925592', 'bziemsen9@smugmug.com', '62549 Arapahoe Center'),
(11, 'Viva', '2027006043', 'lnisena@mail.ru', '7 Anthes Place'),
(12, 'Zoonoodle', '4162509651', 'jtelegab@hp.com', '83535 Bartelt Parkway'),
(13, 'Pixoboo', '8165103655', 'jwaszczykowskic@ehow.com', '7257 Rutledge Place'),
(14, 'Tagopia', '1083559197', 'nbethuned@macromedia.com', '765 Center Street'),
(15, 'Skidoo', '5183873277', 'gmurche@npr.org', '94 Veith Terrace'),
(16, 'Divanoodle', '7022193516', 'nbottelstonef@bbb.org', '5597 Talisman Lane'),
(17, 'Voonix', '8388609826', 'nlobg@desdev.cn', '5 Meadow Ridge Pass'),
(18, 'Reallinks', '4514133354', 'nemburyh@chron.com', '1 Pearson Terrace'),
(19, 'Wikivu', '2877185170', 'kwortoni@ycombinator.com', '6411 Brown Plaza'),
(20, 'Skippad', '2945946197', 'hbabstj@myspace.com', '06782 Londonderry Terrace'),
(21, 'Centidel', '2998680223', 'stitchardk@dropbox.com', '6 Burning Wood Court'),
(22, 'Livefish', '4111564687', 'emacbanel@ftc.gov', '206 Waubesa Terrace'),
(23, 'Mynte', '1653097791', 'kscallanm@360.cn', '44693 Twin Pines Street'),
(24, 'Demivee', '6605748367', 'wburnsyden@tinypic.com', '5 Fulton Plaza'),
(25, 'Thoughtblab', '7029057809', 'fpawelskio@examiner.com', '945 Continental Trail'),
(26, 'Mybuzz', '4923011592', 'lmiebesp@upenn.edu', '13284 Delaware Way'),
(27, 'Youopia', '1982045835', 'dvyelq@dagondesign.com', '8 Colorado Drive'),
(28, 'Twitternation', '8755180451', 'scastanosr@wufoo.com', '785 Tennessee Junction'),
(29, 'Dynabox', '8163465858', 'nbouldens@icio.us', '900 Crescent Oaks Pass'),
(30, 'Kimi', '9759291655', 'klargant@myspace.com', '11562 Magdeline Avenue'),
(100, 'Kazkas', '86', 'frsdf', 'sdf');

-- --------------------------------------------------------

--
-- Table structure for table `uzsakymai`
--

CREATE TABLE `uzsakymai` (
  `uzsakymo_nr` int(11) NOT NULL,
  `uzsakymo_data` date NOT NULL,
  `fk_darbuotojas` int(11) NOT NULL,
  `fk_klientas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `uzsakymai`
--

INSERT INTO `uzsakymai` (`uzsakymo_nr`, `uzsakymo_data`, `fk_darbuotojas`, `fk_klientas`) VALUES
(1, '2022-08-20', 1, 5599783),
(2, '2022-08-20', 2, 5109504),
(3, '2022-04-18', 3, 5097584),
(4, '2023-02-24', 4, 5807919),
(5, '2022-12-13', 5, 5812861),
(6, '2022-04-15', 6, 5224641),
(7, '2023-01-30', 7, 5786544),
(8, '2023-02-16', 8, 5823499),
(9, '2022-09-04', 9, 5978108),
(10, '2022-05-18', 10, 5733610),
(11, '2022-03-22', 11, 5231750),
(12, '2022-11-05', 12, 5308413),
(13, '2022-05-07', 13, 5766862),
(14, '2022-09-06', 14, 5369648),
(15, '2022-10-13', 15, 5465570),
(16, '2022-05-26', 16, 5497228),
(17, '2022-11-04', 17, 5528465),
(18, '2022-06-18', 18, 5251015),
(19, '2022-03-17', 19, 5387271),
(20, '2022-06-12', 20, 5526160),
(21, '2022-11-18', 21, 5009403),
(22, '2023-02-16', 22, 5420570),
(23, '2022-09-06', 23, 5230478),
(24, '2022-06-08', 24, 5076015),
(25, '2022-07-31', 25, 5179253),
(26, '2022-08-19', 26, 5835277),
(27, '2022-08-16', 27, 5241250),
(28, '2022-07-15', 28, 5630142),
(29, '2022-04-19', 29, 5898563),
(30, '2022-03-07', 30, 5344993);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  ADD PRIMARY KEY (`tabelio_nr`),
  ADD KEY `dirba` (`fk_sporto_irangos_parduotuve`);

--
-- Indexes for table `klientai`
--
ALTER TABLE `klientai`
  ADD PRIMARY KEY (`asmens_kodas`);

--
-- Indexes for table `medziagos`
--
ALTER TABLE `medziagos`
  ADD PRIMARY KEY (`medziagos_id`);

--
-- Indexes for table `miestai`
--
ALTER TABLE `miestai`
  ADD PRIMARY KEY (`miesto_id`);

--
-- Indexes for table `parametrai`
--
ALTER TABLE `parametrai`
  ADD PRIMARY KEY (`parametro_id`);

--
-- Indexes for table `perkamos_prekes`
--
ALTER TABLE `perkamos_prekes`
  ADD PRIMARY KEY (`fk_uzsakymas`,`fk_prekes_kaina_galioja_nuo`) USING BTREE,
  ADD KEY `nurodoma_uz` (`fk_prekes_kaina_galioja_nuo`) USING BTREE;

--
-- Indexes for table `prekes`
--
ALTER TABLE `prekes`
  ADD PRIMARY KEY (`prekes_id`) USING BTREE,
  ADD KEY `priklauso` (`fk_parametras`) USING BTREE,
  ADD KEY `tiekia` (`fk_tiekejas`) USING BTREE;

--
-- Indexes for table `prekiu_kainos`
--
ALTER TABLE `prekiu_kainos`
  ADD PRIMARY KEY (`galioja_nuo`,`fk_preke`) USING BTREE,
  ADD KEY `parduodama_uz` (`fk_preke`) USING BTREE;

--
-- Indexes for table `saskaitos`
--
ALTER TABLE `saskaitos`
  ADD PRIMARY KEY (`saskaitos_id`),
  ADD KEY `israsyta` (`fk_uzsakymas`),
  ADD KEY `sumokejo` (`fk_klientas`);

--
-- Indexes for table `spalvos`
--
ALTER TABLE `spalvos`
  ADD PRIMARY KEY (`spalvos_id`);

--
-- Indexes for table `sporto_irangos_parduotuves`
--
ALTER TABLE `sporto_irangos_parduotuves`
  ADD PRIMARY KEY (`parduotuves_id`),
  ADD KEY `turi` (`fk_miestas`);

--
-- Indexes for table `tiekejai`
--
ALTER TABLE `tiekejai`
  ADD PRIMARY KEY (`tiekejo_id`);

--
-- Indexes for table `uzsakymai`
--
ALTER TABLE `uzsakymai`
  ADD PRIMARY KEY (`uzsakymo_nr`),
  ADD KEY `patvirtina` (`fk_darbuotojas`),
  ADD KEY `atlieka` (`fk_klientas`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `miestai`
--
ALTER TABLE `miestai`
  MODIFY `miesto_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `parametrai`
--
ALTER TABLE `parametrai`
  MODIFY `parametro_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT for table `prekes`
--
ALTER TABLE `prekes`
  MODIFY `prekes_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=112;

--
-- AUTO_INCREMENT for table `tiekejai`
--
ALTER TABLE `tiekejai`
  MODIFY `tiekejo_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=201;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  ADD CONSTRAINT `dirba` FOREIGN KEY (`fk_sporto_irangos_parduotuve`) REFERENCES `sporto_irangos_parduotuves` (`parduotuves_id`);

--
-- Constraints for table `parametrai`
--
ALTER TABLE `parametrai`
  ADD CONSTRAINT `parametrai_ibfk_1` FOREIGN KEY (`spalva`) REFERENCES `spalvos` (`spalvos_id`),
  ADD CONSTRAINT `parametrai_ibfk_2` FOREIGN KEY (`medziaga`) REFERENCES `medziagos` (`medziagos_id`);

--
-- Constraints for table `perkamos_prekes`
--
ALTER TABLE `perkamos_prekes`
  ADD CONSTRAINT `itraukta_i` FOREIGN KEY (`fk_uzsakymas`) REFERENCES `uzsakymai` (`uzsakymo_nr`);

--
-- Constraints for table `prekes`
--
ALTER TABLE `prekes`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_parametras`) REFERENCES `parametrai` (`parametro_id`),
  ADD CONSTRAINT `tiekia` FOREIGN KEY (`fk_tiekejas`) REFERENCES `tiekejai` (`tiekejo_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `prekiu_kainos`
--
ALTER TABLE `prekiu_kainos`
  ADD CONSTRAINT `parduodama_uz` FOREIGN KEY (`fk_preke`) REFERENCES `prekes` (`prekes_id`);

--
-- Constraints for table `saskaitos`
--
ALTER TABLE `saskaitos`
  ADD CONSTRAINT `israsyta` FOREIGN KEY (`fk_uzsakymas`) REFERENCES `uzsakymai` (`uzsakymo_nr`),
  ADD CONSTRAINT `sumokejo` FOREIGN KEY (`fk_klientas`) REFERENCES `klientai` (`asmens_kodas`);

--
-- Constraints for table `sporto_irangos_parduotuves`
--
ALTER TABLE `sporto_irangos_parduotuves`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_miestas`) REFERENCES `miestai` (`miesto_id`);

--
-- Constraints for table `uzsakymai`
--
ALTER TABLE `uzsakymai`
  ADD CONSTRAINT `atlieka` FOREIGN KEY (`fk_klientas`) REFERENCES `klientai` (`asmens_kodas`),
  ADD CONSTRAINT `patvirtina` FOREIGN KEY (`fk_darbuotojas`) REFERENCES `darbuotojai` (`tabelio_nr`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
