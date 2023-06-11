﻿using MovConDomain.Models;
using System.Collections.Generic;

namespace MovConRepository.Interfaces
{
    public interface IConteinerRepository
    {
        long Insert(ConteinerModel model);
        int Update(ConteinerModel model);
        int UpdateByNumero(ConteinerModel model);
        int Delete(long id);
        int DeleteByNumero(string numero);
        ConteinerModel Get(long id);
        ConteinerModel GetByNumero(string numero);
        List<ConteinerModel> List();
    }
}