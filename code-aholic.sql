-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 23, 2023 at 04:10 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `code-aholic`
--

-- --------------------------------------------------------

--
-- Table structure for table `pluginpairingtable`
--

CREATE TABLE `pluginpairingtable` (
  `pairingID` int(10) NOT NULL,
  `userID` int(10) NOT NULL,
  `pluginID` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `plugins`
--

CREATE TABLE `plugins` (
  `pluginID` int(10) NOT NULL,
  `name` varchar(25) NOT NULL,
  `pluginData` mediumblob NOT NULL,
  `helpdocData` mediumblob NOT NULL,
  `creator` int(10) NOT NULL,
  `description` varchar(500) NOT NULL,
  `available` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userID` int(10) NOT NULL,
  `userType` int(1) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `firstName` varchar(25) NOT NULL,
  `lastName` varchar(25) NOT NULL,
  `email` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userID`, `userType`, `username`, `password`, `firstName`, `lastName`, `email`) VALUES
(1, 1, 'billybob123', 'bobbyhasapassword', 'bobby', 'mcbobberson', 'billybobmcbobersonthebobboi@bobbert.bob');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pluginpairingtable`
--
ALTER TABLE `pluginpairingtable`
  ADD PRIMARY KEY (`pairingID`),
  ADD UNIQUE KEY `userID` (`userID`),
  ADD UNIQUE KEY `pluginID` (`pluginID`);

--
-- Indexes for table `plugins`
--
ALTER TABLE `plugins`
  ADD PRIMARY KEY (`pluginID`),
  ADD UNIQUE KEY `creator` (`creator`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pluginpairingtable`
--
ALTER TABLE `pluginpairingtable`
  MODIFY `pairingID` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `plugins`
--
ALTER TABLE `plugins`
  MODIFY `pluginID` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `userID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pluginpairingtable`
--
ALTER TABLE `pluginpairingtable`
  ADD CONSTRAINT `pluginpairingtable_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`),
  ADD CONSTRAINT `pluginpairingtable_ibfk_2` FOREIGN KEY (`pluginID`) REFERENCES `plugins` (`pluginID`);

--
-- Constraints for table `plugins`
--
ALTER TABLE `plugins`
  ADD CONSTRAINT `plugins_ibfk_1` FOREIGN KEY (`creator`) REFERENCES `user` (`userID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
