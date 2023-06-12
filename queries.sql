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
*/

SELECT PK_Id as Id, Numero, Tipo, DataHoraInicio, DataHoraFim
FROM Movimentacoes WHERE Numero = 'aaaa0000001' AND DataHoraFim IS NULL;

select * from Conteineres;

select * from Movimentacoes;
