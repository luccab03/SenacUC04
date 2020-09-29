-- phpMyAdmin SQL Dump
-- version 4.9.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Sep 29, 2020 at 05:16 PM
-- Server version: 5.7.26
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `super`
--
CREATE DATABASE IF NOT EXISTS `super` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `super`;

-- --------------------------------------------------------

--
-- Table structure for table `candidatos`
--

CREATE TABLE `candidatos` (
  `idcandidato` int(9) NOT NULL,
  `nome` varchar(200) DEFAULT NULL,
  `experiencia` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `candidatos`
--

INSERT INTO `candidatos` (`idcandidato`, `nome`, `experiencia`) VALUES
(1, 'João Paulo', 'Atendente de padaria'),
(2, 'Adamastor Júnior', 'Repositor'),
(3, 'Ana Cláudia', 'Atendente de caixa'),
(4, 'Daltron Silva', 'Mecânico de carros'),
(5, 'Tiel Evandro', 'Lavador de carros'),
(6, 'Amanda Carvalho', 'Atendente de caixa'),
(7, 'Clóvis Nogueira', 'Atendente de padaria'),
(8, 'Jorge Pereira', 'Coveiro');

-- --------------------------------------------------------

--
-- Table structure for table `consumidor`
--

CREATE TABLE `consumidor` (
  `idConsumidor` int(11) NOT NULL,
  `tipoConsumidor` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `consumidor`
--

INSERT INTO `consumidor` (`idConsumidor`, `tipoConsumidor`) VALUES
(6, 'consumidor final'),
(7, 'consumidor final'),
(8, 'consumidor final'),
(9, 'consumidor final'),
(10, 'consumidor final');

-- --------------------------------------------------------

--
-- Table structure for table `fornecedores`
--

CREATE TABLE `fornecedores` (
  `idfornecedor` int(9) NOT NULL,
  `nomeProduto` varchar(200) DEFAULT NULL,
  `valorProduto` double(9,2) DEFAULT NULL,
  `quantidadeProduto` int(9) DEFAULT NULL,
  `setor` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `fornecedores`
--

INSERT INTO `fornecedores` (`idfornecedor`, `nomeProduto`, `valorProduto`, `quantidadeProduto`, `setor`) VALUES
(1, 'Leite integral', 2.00, 100, 'Padaria'),
(2, 'Pão de manteiga', 3.50, 125, 'Padaria'),
(3, 'Manteiga', 5.99, 60, 'Padaria'),
(4, 'Doce de morango', 2.90, 50, 'Padaria'),
(5, 'Queijo fatiado', 18.90, 60, 'Padaria'),
(6, 'Desodorante', 8.99, 100, 'Perfumaria'),
(7, 'Xampu', 6.99, 200, 'Perfumaria'),
(8, 'Condicionador', 8.90, 50, 'Perfumaria'),
(9, 'Sabonete', 0.89, 500, 'Perfumaria'),
(10, 'Cotonete', 2.50, 100, 'Perfumaria'),
(11, 'Batata-branca', 1.90, 100, 'Hortifruti'),
(12, 'Tomate', 3.90, 58, 'Hortifruti'),
(13, 'Cebola roxa', 2.99, 50, 'Hortifruti'),
(14, 'Abóbora', 0.98, 90, 'Hortifruti'),
(15, 'Pimentão', 5.99, 60, 'Hortifruti'),
(16, 'Arroz', 2.50, 200, 'Alimentos'),
(17, 'Feijão', 3.69, 250, 'Alimentos'),
(18, 'Farinha', 2.19, 500, 'Alimentos'),
(19, 'Açúcar', 2.39, 100, 'Alimentos'),
(20, 'Óleo de soja', 2.99, 300, 'Alimentos');

-- --------------------------------------------------------

--
-- Table structure for table `funcionarios`
--

CREATE TABLE `funcionarios` (
  `idFuncionario` int(4) NOT NULL,
  `nomeFuncionario` varchar(200) DEFAULT NULL,
  `setorFuncionario` varchar(80) DEFAULT NULL,
  `cpf` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `funcionarios`
--

INSERT INTO `funcionarios` (`idFuncionario`, `nomeFuncionario`, `setorFuncionario`, `cpf`) VALUES
(1, 'João Paulo', 'Atendente de padaria', 1234567891),
(2, 'Adamastor Júnior', 'Repositor', 1234567891),
(3, 'Ana Cláudia', 'Atendente de caixa', 1234567891);

-- --------------------------------------------------------

--
-- Table structure for table `itens_vendidos`
--

CREATE TABLE `itens_vendidos` (
  `idVenda` int(11) NOT NULL,
  `idProduto` int(11) NOT NULL,
  `quantidadeVendida` int(11) DEFAULT NULL,
  `valorProduto` double DEFAULT NULL,
  `valorTotalProduto` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `itens_vendidos`
--

INSERT INTO `itens_vendidos` (`idVenda`, `idProduto`, `quantidadeVendida`, `valorProduto`, `valorTotalProduto`) VALUES
(2, 1, 50, 2.4, NULL),
(3, 2, 70, 4.2, NULL),
(4, 3, 60, 7.19, NULL),
(5, 4, 70, 3.48, NULL),
(6, 5, 60, 22.68, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `produtos`
--

CREATE TABLE `produtos` (
  `idProduto` int(4) NOT NULL,
  `nomeProduto` varchar(200) DEFAULT NULL,
  `valorProduto` double(9,2) DEFAULT NULL,
  `quantidadeProduto` int(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `produtos`
--

INSERT INTO `produtos` (`idProduto`, `nomeProduto`, `valorProduto`, `quantidadeProduto`) VALUES
(1, 'Leite integral', 2.40, 100),
(2, 'Pão de manteiga', 4.20, 125),
(3, 'Manteiga', 7.19, 60),
(4, 'Doce de morango', 3.48, 50),
(5, 'Queijo fatiado', 22.68, 60);

-- --------------------------------------------------------

--
-- Table structure for table `venda`
--

CREATE TABLE `venda` (
  `idVenda` int(11) NOT NULL,
  `idConsumidor` int(11) DEFAULT NULL,
  `valorTotalVenda` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `venda`
--

INSERT INTO `venda` (`idVenda`, `idConsumidor`, `valorTotalVenda`) VALUES
(2, 6, 50),
(3, 7, 25),
(4, 8, 150),
(5, 9, 5),
(6, 10, 100);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `candidatos`
--
ALTER TABLE `candidatos`
  ADD PRIMARY KEY (`idcandidato`);

--
-- Indexes for table `consumidor`
--
ALTER TABLE `consumidor`
  ADD PRIMARY KEY (`idConsumidor`);

--
-- Indexes for table `fornecedores`
--
ALTER TABLE `fornecedores`
  ADD PRIMARY KEY (`idfornecedor`);

--
-- Indexes for table `funcionarios`
--
ALTER TABLE `funcionarios`
  ADD PRIMARY KEY (`idFuncionario`);

--
-- Indexes for table `itens_vendidos`
--
ALTER TABLE `itens_vendidos`
  ADD PRIMARY KEY (`idVenda`,`idProduto`),
  ADD KEY `idProduto` (`idProduto`);

--
-- Indexes for table `produtos`
--
ALTER TABLE `produtos`
  ADD PRIMARY KEY (`idProduto`);

--
-- Indexes for table `venda`
--
ALTER TABLE `venda`
  ADD PRIMARY KEY (`idVenda`),
  ADD KEY `idConsumidor` (`idConsumidor`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `candidatos`
--
ALTER TABLE `candidatos`
  MODIFY `idcandidato` int(9) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `consumidor`
--
ALTER TABLE `consumidor`
  MODIFY `idConsumidor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `fornecedores`
--
ALTER TABLE `fornecedores`
  MODIFY `idfornecedor` int(9) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `funcionarios`
--
ALTER TABLE `funcionarios`
  MODIFY `idFuncionario` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `produtos`
--
ALTER TABLE `produtos`
  MODIFY `idProduto` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `venda`
--
ALTER TABLE `venda`
  MODIFY `idVenda` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `itens_vendidos`
--
ALTER TABLE `itens_vendidos`
  ADD CONSTRAINT `itens_vendidos_ibfk_1` FOREIGN KEY (`idVenda`) REFERENCES `venda` (`idVenda`),
  ADD CONSTRAINT `itens_vendidos_ibfk_2` FOREIGN KEY (`idProduto`) REFERENCES `produtos` (`idProduto`);

--
-- Constraints for table `venda`
--
ALTER TABLE `venda`
  ADD CONSTRAINT `venda_ibfk_1` FOREIGN KEY (`idConsumidor`) REFERENCES `consumidor` (`idConsumidor`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
