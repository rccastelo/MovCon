﻿using MovConDomain.Models;
using System.Collections.Generic;

namespace MovConRepository.Interfaces
{
    public interface IMovimentacaoData
    {
        long Insert(MovimentacaoModel model);
        int Update(MovimentacaoModel model);
        int UpdateFimMovimentoByNumero(string numero);
        MovimentacaoModel Get(long id);
        MovimentacaoModel GetEmMovimentoByNumero(string numero);
        List<MovimentacaoModel> List();
        List<MovimentacaoModel> ListEmMovimento();
        List<MovimentacaoModel> ListByNumero(string numero);
    }
}
