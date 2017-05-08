using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UscsWebApiApplication.Models;

namespace UscsWebApiApplication.Controllers
{
    public class ProdutosController : ApiController
    {
        [Route("api/produtos/{idMercado}")]
        public IEnumerable GetProdutos(int idMercado)
        {
            //int idMercado = 1;
            Mercado mercado = new Mercado();
            mercado = mercado.GetMercadoById(idMercado);

            Produto prod = new Produto();
            List<Produto> produtos = new List<Produto>();
            produtos = prod.GetProdutos(mercado);
            return produtos;
        }
    }
}
