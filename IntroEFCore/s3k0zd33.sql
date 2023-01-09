CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Clientes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` VARCHAR(80) CHARACTER SET utf8mb4 NOT NULL,
    `Fone` CHAR(11) CHARACTER SET utf8mb4 NOT NULL,
    `CEP` CHAR(8) CHARACTER SET utf8mb4 NOT NULL,
    `Estado` CHAR(2) CHARACTER SET utf8mb4 NOT NULL,
    `Cidade` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Clientes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Produtos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CodigoDeBarras` VARCHAR(14) CHARACTER SET utf8mb4 NOT NULL,
    `Descricao` VARCHAR(60) CHARACTER SET utf8mb4 NOT NULL,
    `Valor` decimal(65,30) NOT NULL,
    `TipoProduto` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Ativo` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Pedidos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ClienteId` int NOT NULL,
    `IniciadoEm` datetime(6) NOT NULL,
    `FinalizadoEm` datetime(6) NOT NULL,
    `TipoFrete` int NOT NULL,
    `Status` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Observacao` VARCHAR(512) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Pedidos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Pedidos_Clientes_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `Clientes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `PedidosItens` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `PedidoId` int NOT NULL,
    `ProdutoId` int NOT NULL,
    `Quantidade` int NOT NULL DEFAULT 0,
    `Valor` decimal(65,30) NOT NULL DEFAULT 0.0,
    `Desconto` decimal(65,30) NOT NULL DEFAULT 0.0,
    CONSTRAINT `PK_PedidosItens` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PedidosItens_Pedidos_PedidoId` FOREIGN KEY (`PedidoId`) REFERENCES `Pedidos` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_PedidosItens_Produtos_ProdutoId` FOREIGN KEY (`ProdutoId`) REFERENCES `Produtos` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `idx_cliente_telefone` ON `Clientes` (`Fone`);

CREATE INDEX `IX_Pedidos_ClienteId` ON `Pedidos` (`ClienteId`);

CREATE INDEX `IX_PedidosItens_PedidoId` ON `PedidosItens` (`PedidoId`);

CREATE INDEX `IX_PedidosItens_ProdutoId` ON `PedidosItens` (`ProdutoId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230109211737_PrimeiraMigracao', '6.0.12');

COMMIT;

