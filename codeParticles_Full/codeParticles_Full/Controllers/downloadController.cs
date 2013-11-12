using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;
using CodeParticles.DataModels;
using CodeParticles.DataModels.Models;
using codeParticles_Full.Parsers;

namespace codeParticles_Full.Controllers
{
    public class downloadController : Controller
    {
        CodeParticleContext db;
        public downloadController()
        {
            db = new CodeParticleContext();
        }


        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult Post(string reportData)
        //{

        //    System.IO.StreamWriter file = System.IO.File.CreateText(Server.MapPath("~/DownloadFile/CodeParticlesCode.txt"));

        //    file.Write(reportData);


        //    file.Close();

        //    return Json(new { url = "/DownloadFile/CodeParticlesCode.txt" });
        //}

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Save(string reportData)//, string fileName
        {
            // We are creating token here and storing that file in session. We can not send file in ajax response
            string token = Guid.NewGuid().ToString();
            Session[token] = reportData;
            return Json(token);
        }

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult GetFile(string token)//, string fileName
        {
            // based on that token we are receiving the file from session
            string reportData = Session[token].ToString();
            var byteArray = Encoding.ASCII.GetBytes(reportData);
            var stream = new MemoryStream(byteArray);
            // Removing file from session is importatnt or application will kill server memory!
            Session.Remove(token);
            return File(stream, "text/html", "your_file_name.html");
        }

        //[ValidateInput(false)]
        //[HttpPost]
        //public FileResult GetFile(string reportData)
        //{
        //    byte[] test = { 0 };
        //    return File(test, "text/html", "TempFile.html");
        //}

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Upload(string reportData)//, string fileName
        {
            reportData = reportData ?? string.Empty;
            string[] codeLines = reportData.Split(new string[] { "\n" }, StringSplitOptions.None);
            //now I can parse here
            List<List<string>> myTags = HTMLParser.Parse(reportData);

            if (ModelState.IsValid)
            {
                CodeElement codeElement = new CodeElement()
                {
                    Created = DateTime.Now,
                    Text = reportData
                };
                db.CodeElements.Add(codeElement);
                db.SaveChanges();
            }
            return Json(myTags);
        }
    }
}