/*
use dbmovcon;
GO

ALTER TABLE Conteineres  
  ADD CONSTRAINT AK_Numero UNIQUE (Numero);   
GO  

ALTER TABLE Movimentacoes
  ADD CONSTRAINT FK_Numero FOREIGN KEY (Numero)
  REFERENCES Conteineres (Numero);
GO

delete from Movimentacoes;
delete from Conteineres;
*/

SELECT PK_Id as Id, Numero, Tipo, DataHoraInicio, DataHoraFim
FROM Movimentacoes WHERE Numero = 'aaaa0000001' AND DataHoraFim IS NULL;

select * from Conteineres;

select * from Movimentacoes;

SELECT M.Numero, M.Tipo as TipoMovimentacao, C.Cliente, C.Tipo as TipoConteiner,
C.Status, C.Categoria, M.DataHoraInicio, M.DataHoraFim
FROM Movimentacoes M
INNER JOIN Conteineres C ON C.Numero = M.Numero
ORDER BY C.Cliente;

SELECT M.Numero, M.Tipo as TipoMovimentacao, C.Cliente, C.Tipo as TipoConteiner,
C.Status, C.Categoria, M.DataHoraInicio, M.DataHoraFim
FROM Movimentacoes M
INNER JOIN Conteineres C ON C.Numero = M.Numero
ORDER BY C.Cliente, M.Tipo, M.Numero, M.DataHoraInicio;
