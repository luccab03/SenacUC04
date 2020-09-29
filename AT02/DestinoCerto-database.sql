-- phpMyAdmin SQL Dump
-- version 4.9.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Sep 29, 2020 at 04:58 PM
-- Server version: 5.7.26
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `DestinoCerto`
--

-- --------------------------------------------------------

--
-- Table structure for table `Contato`
--

CREATE TABLE `Contato` (
  `NomeCompleto` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Assunto` varchar(255) DEFAULT NULL,
  `Mensagem` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Contato`
--

INSERT INTO `Contato` (`NomeCompleto`, `Email`, `Assunto`, `Mensagem`) VALUES
('Lucca Bringhenti', 'bringhentilucca@gmail.com', 'Suporte', 'aSDASDASDASDASDcu\r\n'),
('Lucca Bringhenti', 'bringhentilucca@gmail.com', 'Suporte', 'aSDASDASDASDASDcu\r\n'),
('Nome Completo', 'email@teste.com', 'Outro Assunto', 'Teste da aplicação');

-- --------------------------------------------------------

--
-- Table structure for table `Pacotes`
--

CREATE TABLE `Pacotes` (
  `idPacote` int(11) NOT NULL,
  `nomePacote` varchar(255) DEFAULT NULL,
  `origemPacote` varchar(255) DEFAULT NULL,
  `destinoPacote` varchar(255) DEFAULT NULL,
  `atrativosPacote` varchar(255) DEFAULT NULL,
  `saidaPacote` date DEFAULT NULL,
  `retornoPacote` date DEFAULT NULL,
  `idCriador` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Pacotes`
--

INSERT INTO `Pacotes` (`idPacote`, `nomePacote`, `origemPacote`, `destinoPacote`, `atrativosPacote`, `saidaPacote`, `retornoPacote`, `idCriador`) VALUES
(5, 'Serra Gaúcha', 'Bento Gonçalves', 'Garibaldi', 'Tour completo da Serra Gaúcha', '2020-12-25', '2020-01-06', 1),
(6, 'Rota Romântica', 'Caxias do Sul', 'Morro Reuter', 'Rota Romântica Gaúcha', '2020-05-04', '2020-05-14', 1);

-- --------------------------------------------------------

--
-- Table structure for table `Usuarios`
--

CREATE TABLE `Usuarios` (
  `idUsuario` int(11) NOT NULL,
  `nomeUsuario` varchar(255) DEFAULT NULL,
  `dataNascimento` datetime DEFAULT NULL,
  `loginUsuario` varchar(255) DEFAULT NULL,
  `senhaUsuario` varchar(255) DEFAULT NULL,
  `tipoUsuario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Usuarios`
--

INSERT INTO `Usuarios` (`idUsuario`, `nomeUsuario`, `dataNascimento`, `loginUsuario`, `senhaUsuario`, `tipoUsuario`) VALUES
(1, 'Administrador', '2020-09-24 19:20:41', 'admin', 'admin', 0),
(2, 'Colaborador', '2020-09-24 19:20:41', 'colab', 'colab', 1),
(5, 'Lucca', '2003-05-04 00:00:00', 'luccab', 'lucca', 0),
(6, 'Lucca', '2004-04-05 00:00:00', 'luccabcolab', 'lucca', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Pacotes`
--
ALTER TABLE `Pacotes`
  ADD PRIMARY KEY (`idPacote`),
  ADD KEY `idCriador` (`idCriador`);

--
-- Indexes for table `Usuarios`
--
ALTER TABLE `Usuarios`
  ADD PRIMARY KEY (`idUsuario`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Pacotes`
--
ALTER TABLE `Pacotes`
  MODIFY `idPacote` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `Usuarios`
--
ALTER TABLE `Usuarios`
  MODIFY `idUsuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Pacotes`
--
ALTER TABLE `Pacotes`
  ADD CONSTRAINT `pacotes_ibfk_1` FOREIGN KEY (`idCriador`) REFERENCES `Usuarios` (`idUsuario`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
