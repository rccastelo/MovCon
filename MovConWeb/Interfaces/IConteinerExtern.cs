﻿using MovConWeb.Models;
using System;
using System.Threading.Tasks;

namespace MovConWeb.Interfaces
{
    public interface IConteinerExtern
    {
        Task<ConteinerViewModel> Get(Int64 id);
        Task<ConteinerViewModel> List();
        Task<ConteinerViewModel> Insert(ConteinerViewModel transport);
        Task<ConteinerViewModel> Update(ConteinerViewModel transport);
        Task<ConteinerViewModel> Delete(Int64 id);
        Task<ConteinerViewModel> Filter(ConteinerViewModel transport);
    }
}