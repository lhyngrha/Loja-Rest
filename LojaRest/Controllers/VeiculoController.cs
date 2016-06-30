using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaRest.Controllers
{
    public class VeiculoController : ApiController
    {
        public IEnumerable<Models.Veiculo> Get()
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            var r = from f in dc.Veiculos select f;
            return r.ToList();
        }

        public void Post([FromBody] string value)
        {
            List<Models.Veiculo> x = JsonConvert.DeserializeObject<List<Models.Veiculo>>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            dc.Veiculos.InsertAllOnSubmit(x);
            dc.SubmitChanges();
        }

        public void Put(int id, [FromBody] string value)
        {
            Models.Veiculo x = JsonConvert.DeserializeObject<Models.Veiculo>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            Models.Veiculo vei = (from f in dc.Veiculos
                                     where f.Id == id
                                     select f).Single();
            vei.Modelo = x.Modelo;
            vei.IdFabricante = x.IdFabricante;
            dc.SubmitChanges();
        }

        public void Delete(int id)
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            Models.Veiculo vei = (from f in dc.Veiculos
                                     where f.Id == id
                                     select f).Single();
            dc.Veiculos.DeleteOnSubmit(vei);
            dc.SubmitChanges();
        }
    }
}
