-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 25. Nov 2019 um 18:01
-- Server-Version: 10.1.35-MariaDB
-- PHP-Version: 7.2.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `shop`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `family`
--

CREATE TABLE `family` (
  `id` int(11) UNSIGNED NOT NULL,
  `reference` varchar(50) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `family`
--

INSERT INTO `family` (`id`, `reference`, `name`, `createdAt`, `updatedAt`) VALUES
(1, 'Etiam pretium iaculis justo.', 'Nulla tellus.', '2019-04-25 00:00:00', '2019-02-03 23:00:00'),
(2, 'Cras pellentesque volutpat dui.', 'Proin eu mi.', '2019-11-23 00:00:00', '2019-08-22 22:00:00'),
(3, 'Duis consequat dui nec nisi volutpat eleifend.', 'Maecenas pulvinar lobortis est.', '2019-04-05 00:00:00', '2019-02-12 23:00:00'),
(4, 'Nulla nisl.', 'Pellentesque ultrices mattis odio.', '2018-11-25 00:00:00', '2019-07-08 22:00:00'),
(5, 'Nulla ac enim.', 'Aliquam sit amet diam in magna bibendum imperdiet.', '2019-03-11 00:00:00', '2019-01-19 23:00:00'),
(6, 'Duis bibendum, felis sed interdum venenatis, turpi', 'Maecenas ut massa quis augue luctus tincidunt.', '2019-04-17 00:00:00', '2019-07-05 22:00:00'),
(7, 'Curabitur at ipsum ac tellus semper interdum.', 'Praesent id massa id nisl venenatis lacinia.', '2019-06-01 00:00:00', '2019-04-26 22:00:00'),
(8, 'Aliquam erat volutpat.', 'Nullam porttitor lacus at turpis.', '2018-11-30 00:00:00', '2019-06-24 22:00:00'),
(9, 'Vestibulum quam sapien, varius ut, blandit non, in', 'Nullam porttitor lacus at turpis.', '2019-02-12 00:00:00', '2019-02-19 23:00:00'),
(10, 'Nulla mollis molestie lorem.', 'Fusce posuere felis sed lacus.', '2019-04-17 00:00:00', '2019-02-10 23:00:00');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `location`
--

CREATE TABLE `location` (
  `id` int(11) UNSIGNED NOT NULL,
  `reference` varchar(50) DEFAULT NULL,
  `description` text,
  `createdAt` datetime NOT NULL,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `location`
--

INSERT INTO `location` (`id`, `reference`, `description`, `createdAt`, `updatedAt`) VALUES
(1, 'Duis ac nibh.', 'Curabitur in libero ut massa volutpat convallis.', '2019-06-10 00:00:00', '2018-12-04 23:00:00'),
(2, 'Maecenas ut massa quis augue luctus tincidunt.', 'Proin leo odio, porttitor id, consequat in, consequat ut, nulla.', '2018-12-25 00:00:00', '2018-12-22 23:00:00'),
(3, 'Praesent lectus.', 'Maecenas pulvinar lobortis est.', '2019-09-10 00:00:00', '2019-10-20 22:00:00'),
(4, 'Duis aliquam convallis nunc.', 'Maecenas pulvinar lobortis est.', '2019-01-17 00:00:00', '2019-03-23 23:00:00'),
(5, 'Cum sociis natoque penatibus et magnis dis parturi', 'Donec semper sapien a libero.', '2019-10-29 00:00:00', '2019-06-04 22:00:00'),
(6, 'Mauris ullamcorper purus sit amet nulla.', 'Morbi quis tortor id nulla ultrices aliquet.', '2018-12-24 00:00:00', '2019-07-12 22:00:00'),
(7, 'Fusce lacus purus, aliquet at, feugiat non, pretiu', 'Aenean lectus.', '2019-03-26 00:00:00', '2019-04-01 22:00:00'),
(8, 'Vivamus tortor.', 'Pellentesque at nulla.', '2019-08-08 00:00:00', '2019-10-01 22:00:00'),
(9, 'Vivamus tortor.', 'Cras in purus eu magna vulputate luctus.', '2019-09-02 00:00:00', '2019-03-31 22:00:00'),
(10, 'Donec diam neque, vestibulum eget, vulputate ut, u', 'Quisque ut erat.', '2019-07-27 00:00:00', '2019-03-01 23:00:00');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `product`
--

CREATE TABLE `product` (
  `id` int(11) UNSIGNED NOT NULL,
  `sku` varchar(255) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `price` float DEFAULT NULL,
  `quantity` float DEFAULT NULL,
  `minquantity` float DEFAULT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `familyid` int(11) NOT NULL,
  `locationid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `product`
--

INSERT INTO `product` (`id`, `sku`, `name`, `price`, `quantity`, `minquantity`, `createdAt`, `updatedAt`, `familyid`, `locationid`) VALUES
(1, '29-065-3305', 'Wine - Semi Dry Riesling Vineland', 84, 44, 12, '2018-12-09 00:00:00', '2019-01-08 23:00:00', 1, 1),
(2, '09-715-3739', 'Pepper - Chillies, Crushed', 20, 78, 31, '2019-10-22 00:00:00', '2019-08-10 22:00:00', 1, 2),
(3, '08-285-6247', 'Wine - Prosecco Valdobienne', 85, 69, 7, '2019-08-11 00:00:00', '2019-02-18 23:00:00', 1, 3),
(4, '21-038-4822', 'Apricots - Dried', 53, 21, 20, '2018-12-18 00:00:00', '2019-01-04 23:00:00', 4, 4),
(5, '29-957-8839', 'Pepper - Pablano', 43, 38, 28, '2019-08-19 00:00:00', '2018-12-17 23:00:00', 5, 5),
(6, '35-300-0834', 'Yeast - Fresh, Fleischman', 70, 7, 26, '2019-07-31 00:00:00', '2019-07-17 22:00:00', 6, 6),
(7, '10-419-0418', 'Juice - V8 Splash', 59, 70, 37, '2019-09-03 00:00:00', '2019-02-16 23:00:00', 7, 7),
(8, '97-729-8044', 'Chinese Foods - Thick Noodles', 25, 81, 4, '2019-05-04 00:00:00', '2019-06-22 22:00:00', 8, 8),
(9, '76-181-5868', 'Wine - Pinot Noir Stoneleigh', 33, 65, 43, '2019-07-12 00:00:00', '2019-07-13 22:00:00', 9, 9),
(10, '63-675-9120', 'Eggplant Italian', 49, 27, 18, '2019-09-02 00:00:00', '2019-04-25 22:00:00', 10, 10),
(11, NULL, 'test', 0, NULL, NULL, '0000-00-00 00:00:00', '2019-11-25 16:58:47', 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `transaction`
--

CREATE TABLE `transaction` (
  `id` int(11) UNSIGNED NOT NULL,
  `comment` text,
  `price` float DEFAULT NULL,
  `quantity` float DEFAULT NULL,
  `reason` enum('New Stock','Usable Return','Unusable Return') DEFAULT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `productid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `transaction`
--

INSERT INTO `transaction` (`id`, `comment`, `price`, `quantity`, `reason`, `createdAt`, `updatedAt`, `productid`) VALUES
(1, 'Vestibulum sed magna at nunc commodo placerat.', 88, 96, '', '2019-02-11 00:00:00', '2019-03-04 23:00:00', 1),
(2, 'Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.', 52, 15, '', '2018-12-05 00:00:00', '2019-06-29 22:00:00', 2),
(3, 'Nam tristique tortor eu pede.', 25, 75, '', '2019-02-16 00:00:00', '2019-04-25 22:00:00', 3),
(4, 'Quisque porta volutpat erat.', 14, 48, '', '2019-10-31 00:00:00', '2019-06-20 22:00:00', 4),
(5, 'Cras in purus eu magna vulputate luctus.', 43, 57, '', '2019-05-16 00:00:00', '2019-10-03 22:00:00', 5),
(6, 'Nulla facilisi.', 100, 48, '', '2019-10-16 00:00:00', '2019-08-27 22:00:00', 6),
(7, 'Cras non velit nec nisi vulputate nonummy.', 28, 80, '', '2019-06-17 00:00:00', '2019-04-30 22:00:00', 7),
(8, 'Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci.', 32, 38, '', '2019-08-13 00:00:00', '2019-05-29 22:00:00', 8),
(9, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit.', 10, 17, '', '2019-07-25 00:00:00', '2019-03-06 23:00:00', 9),
(10, 'Curabitur at ipsum ac tellus semper interdum.', 47, 2, '', '2019-10-19 00:00:00', '2019-02-12 23:00:00', 10);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `family`
--
ALTER TABLE `family`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `location`
--
ALTER TABLE `location`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `family`
--
ALTER TABLE `family`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `location`
--
ALTER TABLE `location`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `product`
--
ALTER TABLE `product`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT für Tabelle `transaction`
--
ALTER TABLE `transaction`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
