﻿using PoupaAiMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoupaAiMVC.Data.Interfaces
{
    public interface IAlternativaRepository
    {

        void Create(Alternativa alternativa);
        List<Alternativa> Read();
        void Update(Alternativa alternativa);
        void Delete(Alternativa alternativa);
        Alternativa GetByID(int alternativaID);
        List<Alternativa> GetAlternativaByIDQuestao(int idQuestao);
    }
}
