using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Http;
using System.Globalization;
using System.Threading;

namespace ServicioWepAPI.Models
{
    public class CdcListController : ApiController
    {
        private readonly CDCSurveyDBEntities1 db = new CDCSurveyDBEntities1();

        
    
        
        private ActionResult View(List<cdcsurvey> lists)
        {
            throw new NotImplementedException();
        }
        // GET: CdcList
        public List<String> GetCdcList()
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            
            string sql = "select Distinct Cast(key1 as NVarchar(Max)) from cdcsurvey where key1 is not null order by Cast(key1 as NVarchar(Max)) ASC";
            List<String> list = db.Database.SqlQuery<String>(sql).ToList();
            int i = 0;
            List<String> lista = new List<String>();
            foreach (string s in list) {
                
                String result = textInfo.ToTitleCase(s.ToLower());
                lista.Add(result);
                i = i + 1;
            }

            return lista;
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
