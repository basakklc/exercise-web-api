using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class Daire_SakiniController : ApiController
    {
        //static List<string> isimler = new List<string>()
        //{
        //    "lap","tel","pc"
        //};
        //[HttpGet]
        //public List<string> GetAll()
        //{
        //    return isimler;
        //}
        //[HttpGet]
        //public string GetById(int id)
        //{
        //    return isimler[id];
        //}
        //[HttpGet]
        //public void Save(string isim)
        //{
        //    isimler.Add(isim);
        //}
        //[HttpGet]
        //public void Update(int id,string isim)
        //{
        //    isimler[id] = isim;
        //}
        //[HttpGet]
        //public void Delete(int id)
        //{
        //    isimler.RemoveAt(id);
        //}
        ApplicationDbContext _db = new ApplicationDbContext();
        [HttpPost]
        public IHttpActionResult Add([FromBody]Daire daire)
        {
            _db.Daires.Add(daire);
            int rowCount = _db.SaveChanges();
            if(rowCount>0)
            {
                return Ok(daire);
            }
            return BadRequest("Kayıt başarısız.");

        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var daireler = _db.Daires.ToList();
            if(daireler.Count==0)
            {
                return NotFound();

            }
          
            return Ok(daireler);
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var daire = _db.Daires.FirstOrDefault(c => c.ID == id);
            if(daire==null)
            {
                return NotFound();
            }
            return Ok(daire);

        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]Daire daire)
        {
            if (daire.ID<=0)
            {
                return NotFound();
            }
            _db.Entry(daire).State = System.Data.Entity.EntityState.Modified;
            int rowCount=_db.SaveChanges();
            if (rowCount>0)
            {
                return Ok(daire);
            }
            return BadRequest("Güncelleme Başarısız.");

        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var daire = _db.Daires.FirstOrDefault(c => c.ID == id);
            if(daire==null)
            {
                return NotFound();
            }
            _db.Daires.Remove(daire);
            int rowCount = _db.SaveChanges();
            if (rowCount>0)
            {
                return Ok("Daire Silindi");
            }
            return BadRequest("silinemedi");
        }


    }
}
