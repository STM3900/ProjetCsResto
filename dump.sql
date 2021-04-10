-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  sam. 10 avr. 2021 à 10:29
-- Version du serveur :  5.7.24
-- Version de PHP :  7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `csproject`
--

-- --------------------------------------------------------

--
-- Structure de la table `restaurant`
--

DROP TABLE IF EXISTS `restaurant`;
CREATE TABLE IF NOT EXISTS `restaurant` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `commentary` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `street` varchar(255) NOT NULL,
  `zip` int(11) NOT NULL,
  `city` varchar(255) NOT NULL,
  `lastTimeVisited` varchar(255) NOT NULL,
  `note` int(11) NOT NULL,
  `noteCommentary` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `restaurant`
--

INSERT INTO `restaurant` (`id`, `name`, `phone`, `commentary`, `email`, `street`, `zip`, `city`, `lastTimeVisited`, `note`, `noteCommentary`) VALUES
(1, 'Le quignon', '0685458575', 'Nous vous proposons du pain dans tous ses états', 'mie@pain.fr', '32 rue du pain', 25858, 'pain', '2010/02/03', 4, 'Très bon'),
(2, 'La maison des gnocchi', '0659858547', 'La ou sont créé les gnocchi', 'gnocchi@miam.it', '22 rue des pates', 24869, 'Gnoland', '2020/12/02', 5, 'Délicieux '),
(3, 'La soupe aux choux', '0245859665', 'miam la soupe', 'soupe@soupe.fr', '32 rue de la soupe', 20000, 'soupacity', '2020/02/03', 1, 'Ne sert pas de burgers'),
(4, 'Pasta et basta', '0674857745', 'Le meilleur des pates, ici', 'pasta@basta.fr', '9 rue des pates', 25874, 'PastaTown', '2020/04/02', 3, 'Pas mal'),
(5, 'Pouah\'son', '0245854744', 'Du poisson qui sent fort !', 'fish@chips.fr', '4 rue de la mauvaise odeur', 45698, 'Pouahville', '2020/06/08', 2, 'Ne sens pas très bon'),
(6, 'SteakHouse', '0245857445', 'De la viande comme vous n\'en avez encore jamais mangé', 'boeuf@miam.fr', '7 rue du boeuf', 12547, 'MeuhLand', '2019/04/08', 4, 'Très bonne viande'),
(7, 'Pomme d\'api', '02458574', 'Des pommes et une bonne api', 'pomme@api.fr', '6 avenue du débit', 12547, 'Appletown', '2021/08/04', 3, 'Les pommes lag un peu');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
