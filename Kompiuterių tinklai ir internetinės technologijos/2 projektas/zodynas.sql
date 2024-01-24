-- phpMyAdmin SQL Dump
-- version 4.6.6deb5ubuntu0.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 05, 2023 at 11:21 PM
-- Server version: 5.7.35-0ubuntu0.18.04.1
-- PHP Version: 7.2.24-0ubuntu0.18.04.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `zodynas`
--

-- --------------------------------------------------------

--
-- Table structure for table `naudotoju_neatsakyti_zodziai`
--

CREATE TABLE `naudotoju_neatsakyti_zodziai` (
  `user_id` varchar(32) CHARACTER SET utf8 NOT NULL,
  `zodis` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL,
  `kiekis` int(5) NOT NULL,
  `busena` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL,
  `id` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `naudotoju_neatsakyti_zodziai`
--

INSERT INTO `naudotoju_neatsakyti_zodziai` (`user_id`, `zodis`, `kiekis`, `busena`, `id`) VALUES
('254e720c9c0931ba0c41e012dea02e82', 'Flower', 1, 'atsakyta', 34),
('254e720c9c0931ba0c41e012dea02e82', 'Tree', 1, 'atsakyta', 35),
('254e720c9c0931ba0c41e012dea02e82', 'Grass', 1, 'atsakyta', 36),
('254e720c9c0931ba0c41e012dea02e82', 'Mountain', 2, 'atsakyta', 37),
('254e720c9c0931ba0c41e012dea02e82', 'Lily', 2, 'atsakyta', 38),
('254e720c9c0931ba0c41e012dea02e82', 'Windy', 1, 'neatsakyta', 39),
('254e720c9c0931ba0c41e012dea02e82', 'Earth', 3, 'atsakyta', 40),
('254e720c9c0931ba0c41e012dea02e82', 'Planet', 4, 'atsakyta', 41),
('254e720c9c0931ba0c41e012dea02e82', 'Moon', 5, 'atsakyta', 42);

-- --------------------------------------------------------

--
-- Table structure for table `naudotoju_suvesti_zodziai`
--

CREATE TABLE `naudotoju_suvesti_zodziai` (
  `user_id` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_lithuanian_ci NOT NULL,
  `kalba` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL,
  `tematika` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL,
  `lygis` int(5) NOT NULL,
  `zodis` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL,
  `vertimas` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `naudotoju_suvesti_zodziai`
--

INSERT INTO `naudotoju_suvesti_zodziai` (`user_id`, `kalba`, `tematika`, `lygis`, `zodis`, `vertimas`) VALUES
('254e720c9c0931ba0c41e012dea02e82', 'Anglų', 'Gyvūnai', 1, 'Dog', 'Šuo'),
('254e720c9c0931ba0c41e012dea02e82', 'Ispanų', 'Gyvūnai', 1, 'Lion', 'Liūtas'),
('254e720c9c0931ba0c41e012dea02e82', 'Anglų', 'Filmai', 5, 'Movie', 'Filmas');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `username` varchar(30) NOT NULL,
  `password` varchar(32) DEFAULT NULL,
  `userid` varchar(32) NOT NULL,
  `userlevel` tinyint(1) UNSIGNED DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`username`, `password`, `userid`, `userlevel`, `email`, `timestamp`) VALUES
('Administratorius', '16c354b68848cdbd8f54a226a0a55b21', 'a2fe399900de341c39c632244eaf8483', 9, 'demo@ktu.lt', '2023-12-05 21:17:17'),
('Vedejas', 'c2acd92812ef99acd3dcdbb746b9a434', 'd4903c0f0ed2437dd2d3e8b4314df36a', 5, 'vedejas@ktu.lt', '2023-12-05 20:57:59'),
('vytenis', 'c2acd92812ef99acd3dcdbb746b9a434', '254e720c9c0931ba0c41e012dea02e82', 4, 'vyteni@ktu.lt', '2023-12-05 21:02:41'),
('tomas', 'c2acd92812ef99acd3dcdbb746b9a434', 'c4a4d4fcfec64234917b06d83e6d12fe', 4, 'tomas@ktu.lt', '2023-12-05 21:17:05');

-- --------------------------------------------------------

--
-- Table structure for table `zodziai`
--

CREATE TABLE `zodziai` (
  `kalba` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL,
  `tematika` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL,
  `lygis` int(5) NOT NULL,
  `zodis` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL,
  `vertimas` varchar(30) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `zodziai`
--

INSERT INTO `zodziai` (`kalba`, `tematika`, `lygis`, `zodis`, `vertimas`) VALUES
('Anglų', 'Gamta', 2, 'Cloud', 'Debesis'),
('Anglų', 'Oras', 1, 'Cloudy', 'Debesuota'),
('Rusų', 'Kosmosas', 1, 'Earth', 'Žemė'),
('Anglų', 'Gamta', 1, 'Flower', 'Gėlė'),
('Anglų', 'Gamta', 1, 'Grass', 'Žolė'),
('Anglų', 'Gamta', 1, 'Leaf', 'Lapas'),
('Anglų', 'Oras', 2, 'Lightning', 'Žaibas'),
('Japonų', 'Gamta', 1, 'Lily', 'Lelija'),
('Rusų', 'Kosmosas', 1, 'Moon', 'Mėnulis'),
('Anglų', 'Gamta', 1, 'Mountain', 'Kalnas'),
('Anglų', 'Gamta', 1, 'Ocean', 'Vandenynas'),
('Rusų', 'Kosmosas', 1, 'Planet', 'Planeta'),
('Anglų', 'Oras', 2, 'Rain', 'Lietus'),
('Anglų', 'Gamta', 2, 'Sun', 'Saulė'),
('Anglų', 'Gamta', 1, 'Tree', 'Medis'),
('Anglų', 'Gamta', 2, 'Water', 'Vanduo'),
('Anglų', 'Oras', 1, 'Windy', 'Vejuota');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `naudotoju_neatsakyti_zodziai`
--
ALTER TABLE `naudotoju_neatsakyti_zodziai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `naudotoju_suvesti_zodziai`
--
ALTER TABLE `naudotoju_suvesti_zodziai`
  ADD PRIMARY KEY (`zodis`,`user_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userid`);

--
-- Indexes for table `zodziai`
--
ALTER TABLE `zodziai`
  ADD PRIMARY KEY (`zodis`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `naudotoju_neatsakyti_zodziai`
--
ALTER TABLE `naudotoju_neatsakyti_zodziai`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
