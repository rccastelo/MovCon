using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MovConWeb.Helpers
{
    public static class DomainsHelper
    {
        private static List<SelectListItem> MontarDdl(bool itemEmBranco, bool itemTodos, bool itemSelecione)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            if (itemEmBranco) items.Add(new SelectListItem() { Value = "", Text = "" });
            if (itemTodos) items.Add(new SelectListItem() { Value = "", Text = "[--Todos--]" });
            if (itemSelecione) items.Add(new SelectListItem() { Value = "", Text = "[--Selecione--]" });

            return items;
        }

        public static SelectList MontarDdlTipoMovimentacao(string valorSelecionado = null, 
                bool itemEmBranco = false, bool itemTodos = false, bool itemSelecione = false)
        {
            List<SelectListItem> items = MontarDdl(itemEmBranco, itemTodos, itemSelecione);

            TipoMovimentacaoItens.ForEach(i => {
                items.Add(new SelectListItem() { Value = i.Item1, Text = i.Item2 });
            });
            
            SelectList sl = new SelectList(items, "Value", "Text", valorSelecionado?.ToLower());

            return sl;
        }

        public static SelectList MontarDdlTipoConteiner(string valorSelecionado = null,
                bool itemEmBranco = false, bool itemTodos = false, bool itemSelecione = false)
        {
            List<SelectListItem> items = MontarDdl(itemEmBranco, itemTodos, itemSelecione);

            TipoConteinerItens.ForEach(i => {
                items.Add(new SelectListItem() { Value = i.Item1, Text = i.Item2 });
            });

            SelectList sl = new SelectList(items, "Value", "Text", valorSelecionado?.ToLower());

            return sl;
        }

        public static SelectList MontarDdlStatusConteiner(string valorSelecionado = null,
                bool itemEmBranco = false, bool itemTodos = false, bool itemSelecione = false)
        {
            List<SelectListItem> items = MontarDdl(itemEmBranco, itemTodos, itemSelecione);

            StatusConteinerItens.ForEach(i => {
                items.Add(new SelectListItem() { Value = i.Item1, Text = i.Item2 });
            });

            SelectList sl = new SelectList(items, "Value", "Text", valorSelecionado?.ToLower());

            return sl;
        }

        public static SelectList MontarDdlCategoriaConteiner(string valorSelecionado = null,
                bool itemEmBranco = false, bool itemTodos = false, bool itemSelecione = false)
        {
            List<SelectListItem> items = MontarDdl(itemEmBranco, itemTodos, itemSelecione);

            CategoriaConteinerItens.ForEach(i => {
                items.Add(new SelectListItem() { Value = i.Item1, Text = i.Item2 });
            });

            SelectList sl = new SelectList(items, "Value", "Text", valorSelecionado?.ToLower());

            return sl;
        }

        public static string ObterTipoMovimentacao(string valor) 
        {
            return TipoMovimentacaoItens.Find(i => i.Item1.ToLower() == valor?.ToLower())?.Item2;
        }

        public static string ObterTipoConteiner(string valor)
        {
            return TipoConteinerItens.Find(i => i.Item1.ToLower() == valor?.ToLower())?.Item2;
        }

        public static string ObterStatusConteiner(string valor)
        {
            return StatusConteinerItens.Find(i => i.Item1.ToLower() == valor?.ToLower())?.Item2;
        }

        public static string ObterCategoriaConteiner(string valor)
        {
            return CategoriaConteinerItens.Find(i => i.Item1.ToLower() == valor?.ToLower())?.Item2;
        }

        // Simulando retorno dos dados do domínio Tipo de Movimentação
        private static List<Tuple<string, string>> TipoMovimentacaoItens
        {
            get {
                return new List<Tuple<string, string>> {
                     new Tuple<string, string>("embarque", "Embarque"),
                     new Tuple<string, string>("descarga", "Descarga"),
                     new Tuple<string, string>("gatein", "Gate In"),
                     new Tuple<string, string>("gateout", "Gate Out"),
                     new Tuple<string, string>("reposicionamento", "Reposicionamento"),
                     new Tuple<string, string>("pesagem", "Pesagem"),
                     new Tuple<string, string>("scanner", "Scanner")
                };
            }
        }

        // Simulando retorno dos dados do domínio Tipo de Contêiner
        private static List<Tuple<string, string>> TipoConteinerItens {
            get {
                return new List<Tuple<string, string>> {
                     new Tuple<string, string>("20", "20"),
                     new Tuple<string, string>("40", "40")
                };
            }
        }

        // Simulando retorno dos dados do domínio Status do Contêiner
        private static List<Tuple<string, string>> StatusConteinerItens {
            get {
                return new List<Tuple<string, string>> {
                     new Tuple<string, string>("cheio", "Cheio"),
                     new Tuple<string, string>("vazio", "Vazio")
                };
            }
        }

        // Simulando retorno dos dados do domínio Categoria do Contêiner
        private static List<Tuple<string, string>> CategoriaConteinerItens {
            get {
                return new List<Tuple<string, string>> {
                     new Tuple<string, string>("importacao", "Importação"),
                     new Tuple<string, string>("exportacao", "Exportação")
                };
            }
        }
    }
}
