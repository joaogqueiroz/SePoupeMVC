﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoupaAiMVC.Data.Entities;
using PoupaAiMVC.Data.Interfaces;
using PoupaAiMVC.Models.Questionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaAiMVC.Controllers.Questionario
{
    [Authorize]
    public class QuestionarioController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IQuestoesRepository _questoesRepository;
        private readonly IAlternativaRepository _alternativaRepository;


        public QuestionarioController(IUsuarioRepository usuarioRepository, IQuestoesRepository questoesRepository, IAlternativaRepository alternativaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _questoesRepository = questoesRepository;
            _alternativaRepository = alternativaRepository;
        }

        public IActionResult Avaliacao(int id)
        {
            try
            {

                var email = User.Identity.Name;

                var usuario = _usuarioRepository.Get(email);

                
                if (id == 1)
                {
                    var Questoes = _questoesRepository.GetByMundo1();
                    var Alternativas = _alternativaRepository.Read();

                    AvaliacaoModel model = new AvaliacaoModel();
                    model.Alternativas = Alternativas;
                    model.Questoes = Questoes;

                    return View(model);
                }
                else if (id == 2)
                {

                    var Questoes = _questoesRepository.GetByMundo2();
                    TempData["Questoes"] = Questoes;
                }
                else
                {

                    var Questoes = _questoesRepository.GetByMundo3();
                    TempData["Questoes"] = Questoes;
                }

            }
            catch (Exception e)
            {

                TempData["Message"] = e.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult ValidaRespostas(AvaliacaoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    for (int i = 0; i < model.Questoes.Count(); i++)
                    {
                        for (int j = 0; j < model.Alternativas.Count(); i++)
                        {
                            if (model.Alternativas[j].AlternativaEscolhida != null)
                            {

                            }
                        }
                        

                    }
                    
                }

            }
            catch (Exception e)
            {

                TempData["Messege"] = "Error" + e.Message;
            }
            return View();
        }
    }
}