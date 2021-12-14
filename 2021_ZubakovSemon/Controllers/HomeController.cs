using _2021_ZubakovSemon.Models;
using FastReport.Web;
using MathLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace _2021_ZubakovSemon.Controllers
{
    public class HomeController : Controller
    {
        readonly IGeneratePdf _generatePdf;
        readonly IHostEnvironment _hostingEnvironment;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Input()
        {
            StenkaMathLib _stenka = new StenkaMathLib();

            #region --- Задать исходные данные по умолчанию


            _stenka.S1 = 0.232;
            _stenka.S2 = 0.1;
            _stenka.S3 = 0.21;
            _stenka.S4 = 0.46;
            _stenka.TEnvironment = 5d;
            _stenka.Tgas = 900d;
            _stenka.A1 = 1.2d;
            _stenka.A2 = 1d;
            _stenka.A3 = 0.9d;
            _stenka.A4 = 0.7d;
            _stenka.B1 = 0.9;
            _stenka.B2 = 0.75d;
            _stenka.B3 = 0.6d;
            _stenka.B4 = 0.4d;
            _stenka.T1Stenk = 850;
            _stenka.T2border = 700;
            _stenka.T3border = 500;
            _stenka.T4border = 350;
            _stenka.TOutBorder = 41d;




            #endregion --- Задать исходные данные по умолчанию

            ViewBag.DataInput = _stenka;

            return View();
        }



        private void ShowData(DataOutputModel _rezult)
        {

            ViewBag.Layers = _rezult.Layers;
            ViewBag.A_otdachi = _rezult.A_otdachi;

            ViewBag.ATeplo1 = _rezult.ATeplo1;

            ViewBag.ATeplo2 = _rezult.ATeplo2;

            ViewBag.ATeplo3 = _rezult.ATeplo3;

            ViewBag.ATeplo4 = _rezult.ATeplo4;

            ViewBag.Q_gas = _rezult.Q_gas;

            ViewBag.Q1Stenk = _rezult.Q1Stenk;

            ViewBag.Q2Stenk = _rezult.Q2Stenk;

            ViewBag.Q3Stenk = _rezult.Q3Stenk;

            ViewBag.Q4Stenk = _rezult.Q4Stenk;

            ViewBag.Qenvironment = _rezult.Qenvironment;

            ViewBag.DataSet = _rezult.StenkaData;

        }
        [HttpPost]
        public IActionResult DataInput(DataInputModel DataInput)
        {
            DataOutputModel Raschet = new DataOutputModel(DataInput);

            ShowData(Raschet);

            Raschet.Equeals();

            HttpContext.Session.Set<DataOutputModel>("Output", Raschet);


            ShowData(Raschet);

            return View("Output", Raschet);
        }

        public IActionResult Graphic()
        {
            if (HttpContext.Session.Keys.Contains("Output"))
            {
                DataOutputModel Raschet = HttpContext.Session.Get<DataOutputModel>("Output");

                GraphicModel model = new GraphicModel(Raschet.StenkaData);
                return View(model);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Report()
        {
            if (HttpContext.Session.Keys.Contains("Output"))
            {
                DataOutputModel Raschet = HttpContext.Session.Get<DataOutputModel>("Output");

                var webReport = new WebReport();

                webReport.Report.Load(Path.Combine(_hostingEnvironment.ContentRootPath, $"wwwroot\\report\\{Raschet.Layers}Layers.frx"));

                var output = ReportModel.GetTable<DataOutputModel>(new DataOutputModel[] { Raschet }, "Model");
                var input = ReportModel.GetTable<StenkaMathLib>(new StenkaMathLib[] { Raschet.StenkaData }, "DataInput");

                webReport.Report.RegisterData(input, "DataInput");
                webReport.Report.RegisterData(output, "Model");
                return View(webReport);
            }
            return View();
        }
    }
}
