using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UscsWebApiApplication.Models
{
    public class Produto
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }

        public void setCategoryFromUrl(string url)
        {
            if (url.IndexOf("bebes") >= 0) { this.Category = "bebes"; }
            if (url.IndexOf("perfumaria") >= 0) { this.Category = "perfumaria"; }
            if (url.IndexOf("limpeza") >= 0) { this.Category = "limpeza"; }
            if (url.IndexOf("alimentos") >= 0) { this.Category = "alimentos"; }
            if (url.IndexOf("bebidas") >= 0) { this.Category = "bebidas"; }
            if (url.IndexOf("carnes") >= 0) { this.Category = "carnes"; }
            if (url.IndexOf("feira") >= 0) { this.Category = "feira"; }
            if (url.IndexOf("pet") >= 0) { this.Category = "pet"; }
        }

        public List<Produto> GetProdutos(Mercado mercado)
        {
            HtmlWeb web = new HtmlWeb();
            List<Produto> produtos = new List<Produto>();
            foreach (var url in mercado.urls)
            {
                var doc = web.Load(url);//await Task.Factory.StartNew(() => web.Load(url));
                var masterNodes = doc.DocumentNode.SelectNodes("//*[@id=\"showcase\"]/*");
                foreach (var item in masterNodes)
                {
                    string prodNode = "";
                    string priceNode = "";
                    try
                    {
                        prodNode = item.Descendants("h3").Where(d =>
                               d.Attributes.Contains("class")
                               &&
                               d.Attributes["class"].Value.Contains("showcase-item__name")
                            ).First().InnerText.Trim();
                    }
                    catch
                    {
                        prodNode = "Nome do produto nao encontrado.";
                    }
                    try
                    {
                        priceNode = item.Descendants("footer").Where(d =>
                               d.Attributes.Contains("class")
                               &&
                               d.Attributes["class"].Value.Contains("showcase-item__footer")
                            ).First().InnerText.Trim();
                    }
                    catch
                    {
                        priceNode = "Preco do produto nao encontrado";
                    }

                    var produto = new Produto
                    {
                        Price = priceNode,
                        ProductName = prodNode
                    };
                    produto.setCategoryFromUrl(url);
                    produtos.Add(produto);
                }
            }
            return produtos;
        }
    }
}