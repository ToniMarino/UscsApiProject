using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UscsWebApiApplication.Models
{
    public class Mercado
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public List<string> urls
        {
            get
            {
                List<string> categorias = new List<string>();
                categorias.Add("http://www.deliveryextra.com.br/secoes/C2475/bebes");
                categorias.Add("http://www.deliveryextra.com.br/secoes/C127/perfumaria");
                categorias.Add("http://www.deliveryextra.com.br/secoes/C145/limpeza");
                categorias.Add("http://www.deliveryextra.com.br/secoes/C312/alimentos");
                categorias.Add("http://www.deliveryextra.com.br/secoes/C76/bebidas");
                categorias.Add("http://www.deliveryextra.com.br/secoes/C975/carnes");
                categorias.Add("http://www.deliveryextra.com.br/secoes/C12/feira");
                categorias.Add("http://www.deliveryextra.com.br/secoes/C189/pet");
                return categorias;
            }
        }

        public Mercado GetMercadoById(int id)
        {
            var mercados = this.GetMercados();
            return mercados.Where(m => m.id == id).FirstOrDefault();
        }

        public List<Mercado> GetMercados()
        {
            List<Mercado> mercados = new List<Mercado>()
            {
                new Mercado { id = 1, nome = "Mercadinho do Zé", logradouro = "Rua dos Bobos", numero = "0" , complemento = "" },
                new Mercado { id = 2, nome = "Micromercado Extro", logradouro = "Rua dos Maracatins", numero = "789" , complemento = "Prédio B" },
                new Mercado { id = 3, nome = "Extro Express", logradouro = "Rua Independência", numero = "1822" , complemento = "" },
                new Mercado { id = 4, nome = "Noite", logradouro = "Rua Carneiro da Cunha", numero = "946" , complemento = "" },
                new Mercado { id = 5, nome = "Carrefive", logradouro = "Alameda dos Alamedos", numero = "555" , complemento = "" }
            };
            return mercados;
        }
    }
}