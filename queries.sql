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

select * from Conteineres;

select * from Movimentacoes;