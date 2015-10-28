using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class SpaController : Controller
    {
        readonly string _baseDir = ConfigurationManager.AppSettings["App.SpaRootDirectory"];
        // GET: Spa
        public ActionResult Index()
        {
            #region EXCEPTIONS

            if (Request.Url.LocalPath == "/app/app.css" || Request.Url.LocalPath == "/app/app.ie8.css")
            {
                var targetFile = Server.MapPath("../.tmp" + Request.Url.LocalPath);
                return File(targetFile, MimeMapping.GetMimeMapping(targetFile));
            }

            #endregion

            var prefix = Request.RawUrl.Contains(".tmp/") ? "" : _baseDir;
            var resolvedUrl = prefix + Request.Url.LocalPath;
            var localPath = Server.MapPath(resolvedUrl);

            if (String.IsNullOrEmpty(System.IO.Path.GetExtension(localPath)))
            {
                localPath = Server.MapPath(prefix + "/index.html");
            }

            if (!System.IO.File.Exists(localPath))
            {
                return HttpNotFound();
            }

            return File(localPath, MimeMapping.GetMimeMapping(localPath));
        }
    }
}