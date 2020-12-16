using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class Daire
    {
        public int ID { get; set; }     
        public string ad { get; set; }
        public string soyad { get; set; }
        public string mail_adresi { get; set; }       
        public string telefon { get; set; }  
        public string daire_no { get; set; }       
        public string kat_no { get; set; }
        public string apart_no { get; set; }

    }
}