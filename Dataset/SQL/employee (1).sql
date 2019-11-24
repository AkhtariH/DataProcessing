-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 24. Nov 2019 um 23:04
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
-- Datenbank: `employee`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `departments`
--

CREATE TABLE `departments` (
  `dept_no` char(4) NOT NULL,
  `dept_name` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `departments`
--

INSERT INTO `departments` (`dept_no`, `dept_name`) VALUES
('1', 'Accounting'),
('2', 'Marketing'),
('3', 'Research and Development'),
('4', 'Sales'),
('5', 'Training');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `dept_emp`
--

CREATE TABLE `dept_emp` (
  `emp_no` int(11) NOT NULL,
  `dept_no` char(4) NOT NULL,
  `from_date` date NOT NULL,
  `to_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `dept_emp`
--

INSERT INTO `dept_emp` (`emp_no`, `dept_no`, `from_date`, `to_date`) VALUES
(1, '1', '2018-02-18', '2019-02-18'),
(2, '2', '2017-03-21', '2018-04-18'),
(3, '3', '2017-05-03', '2017-07-16'),
(4, '4', '2017-01-13', '2017-04-26'),
(5, '5', '2018-01-08', '2017-11-27');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `dept_manager`
--

CREATE TABLE `dept_manager` (
  `dept_no` char(4) NOT NULL,
  `emp_no` int(11) NOT NULL,
  `from_date` date NOT NULL,
  `to_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `dept_manager`
--

INSERT INTO `dept_manager` (`dept_no`, `emp_no`, `from_date`, `to_date`) VALUES
('1', 1, '2018-01-04', '2018-09-30'),
('2', 2, '2017-11-04', '2017-10-23'),
('3', 3, '2018-03-15', '2017-09-17'),
('4', 4, '2017-07-08', '2017-06-23'),
('5', 5, '2017-02-13', '2018-03-28');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `employees`
--

CREATE TABLE `employees` (
  `emp_no` int(11) NOT NULL,
  `birth_date` date NOT NULL,
  `first_name` varchar(14) NOT NULL,
  `last_name` varchar(16) NOT NULL,
  `gender` enum('M','F') NOT NULL,
  `hire_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `employees`
--

INSERT INTO `employees` (`emp_no`, `birth_date`, `first_name`, `last_name`, `gender`, `hire_date`) VALUES
(1, '1996-10-22', 'Syd', 'Barney', '', '2018-02-18'),
(2, '1984-11-29', 'Lorrin', 'Crosston', '', '2018-09-23'),
(3, '1993-06-11', 'Eldridge', 'Strugnell', '', '2017-12-29'),
(4, '1984-05-23', 'Yasmin', 'Ruddock', '', '2017-08-22'),
(5, '1984-02-13', 'Alisa', 'Sabater', '', '2017-09-25'),
(6, '1999-05-30', 'Freedman', 'Sorel', '', '2018-06-18'),
(7, '1990-02-26', 'Catharine', 'O\' Donohoe', '', '2018-08-18'),
(8, '1983-02-18', 'Clyve', 'Colvin', '', '2018-05-10'),
(9, '1983-10-25', 'Eran', 'Crutchley', '', '2017-07-15'),
(10, '1996-06-19', 'Jaquenette', 'Mandell', '', '2017-11-16');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `salaries`
--

CREATE TABLE `salaries` (
  `emp_no` int(11) NOT NULL,
  `salary` int(11) NOT NULL,
  `from_date` date NOT NULL,
  `to_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `salaries`
--

INSERT INTO `salaries` (`emp_no`, `salary`, `from_date`, `to_date`) VALUES
(1, 3650, '2018-02-18', '2019-02-18'),
(2, 4619, '2018-11-18', '2017-06-30'),
(3, 6669, '2018-12-05', '2017-03-07'),
(4, 3452, '2017-02-25', '2018-03-29'),
(5, 3577, '2017-12-03', '2018-04-15'),
(6, 7605, '2018-04-21', '2018-01-30'),
(7, 4891, '2017-12-05', '2018-10-13'),
(8, 5963, '2018-12-11', '2018-10-25'),
(9, 6387, '2018-03-03', '2017-10-19'),
(10, 4092, '2018-07-19', '2018-07-28');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `titles`
--

CREATE TABLE `titles` (
  `emp_no` int(11) NOT NULL,
  `title` varchar(50) NOT NULL,
  `from_date` date NOT NULL,
  `to_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Daten für Tabelle `titles`
--

INSERT INTO `titles` (`emp_no`, `title`, `from_date`, `to_date`) VALUES
(1, 'Database Administrator II', '2017-12-13', '2017-02-02'),
(2, 'Design Engineer', '2017-11-26', '2018-03-30'),
(3, 'Sales Associate', '2017-11-18', '2018-01-27'),
(4, 'Database Administrator III', '2018-09-05', '2018-08-02'),
(5, 'Assistant Media Planner', '2018-03-21', '2017-01-07'),
(6, 'Quality Control Specialist', '2017-07-15', '2017-08-04'),
(7, 'Sales Associate', '2018-08-18', '2017-08-20'),
(8, 'VP Quality Control', '2017-07-06', '2018-09-17'),
(9, 'Product Engineer', '2018-07-01', '2017-01-09'),
(10, 'Sales Associate', '2017-03-24', '2018-08-30');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`dept_no`),
  ADD UNIQUE KEY `dept_name` (`dept_name`);

--
-- Indizes für die Tabelle `dept_emp`
--
ALTER TABLE `dept_emp`
  ADD PRIMARY KEY (`emp_no`,`dept_no`),
  ADD KEY `emp_no` (`emp_no`),
  ADD KEY `dept_no` (`dept_no`);

--
-- Indizes für die Tabelle `dept_manager`
--
ALTER TABLE `dept_manager`
  ADD PRIMARY KEY (`emp_no`,`dept_no`),
  ADD KEY `emp_no` (`emp_no`),
  ADD KEY `dept_no` (`dept_no`);

--
-- Indizes für die Tabelle `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`emp_no`);

--
-- Indizes für die Tabelle `salaries`
--
ALTER TABLE `salaries`
  ADD PRIMARY KEY (`emp_no`,`from_date`),
  ADD KEY `emp_no` (`emp_no`);

--
-- Indizes für die Tabelle `titles`
--
ALTER TABLE `titles`
  ADD PRIMARY KEY (`emp_no`,`title`,`from_date`),
  ADD KEY `emp_no` (`emp_no`);

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `dept_emp`
--
ALTER TABLE `dept_emp`
  ADD CONSTRAINT `dept_emp_ibfk_1` FOREIGN KEY (`emp_no`) REFERENCES `employees` (`emp_no`) ON DELETE CASCADE,
  ADD CONSTRAINT `dept_emp_ibfk_2` FOREIGN KEY (`dept_no`) REFERENCES `departments` (`dept_no`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `dept_manager`
--
ALTER TABLE `dept_manager`
  ADD CONSTRAINT `dept_manager_ibfk_1` FOREIGN KEY (`emp_no`) REFERENCES `employees` (`emp_no`) ON DELETE CASCADE,
  ADD CONSTRAINT `dept_manager_ibfk_2` FOREIGN KEY (`dept_no`) REFERENCES `departments` (`dept_no`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `salaries`
--
ALTER TABLE `salaries`
  ADD CONSTRAINT `salaries_ibfk_1` FOREIGN KEY (`emp_no`) REFERENCES `employees` (`emp_no`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `titles`
--
ALTER TABLE `titles`
  ADD CONSTRAINT `titles_ibfk_1` FOREIGN KEY (`emp_no`) REFERENCES `employees` (`emp_no`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
