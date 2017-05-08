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

    public class MercadosController : ApiController
    {
        public IEnumerable GetMercados()
        {
            Mercado merc = new Mercado();
            return merc.GetMercados().ToArray();
        }
        public Mercado GetMercadoById(int id)
        {
            Mercado merc = new Mercado();
            return merc.GetMercadoById(id);
        }
        [HttpPost]
        public Mercado AddNewMercado ([FromBody] Mercado mercado)
        {
            return mercado;
        }
    }
}
