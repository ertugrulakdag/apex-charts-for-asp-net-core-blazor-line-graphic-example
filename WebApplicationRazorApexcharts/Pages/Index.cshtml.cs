using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRazorApexcharts.Pages.Models;

namespace WebApplicationRazorApexcharts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public string SeriesMonthOpenOrder { get; set; }
        [BindProperty]
        public string LabelsMonthOpenOrder { get; set; }

        [BindProperty]
        public string SeriesMonthCloseOrder { get; set; }
        [BindProperty]
        public string LabelsMonthCloseOrder { get; set; }


        public Random rnd = new Random();

        public void OnGet()
        {
            var startDate = DateTime.Now.AddYears(-1);
            var endDate = DateTime.Now;

            List<SiparisAylikGrafikModel> data = new List<SiparisAylikGrafikModel>();

            for (int i = 0; i < 9000; i++)
            {
                int id = rnd.Next(1, 1300);
                var siparisTarihi = Utils.RandomDay();
                bool siparisAcikMi = Utils.SayiTekMi(id);
                data.Add(new SiparisAylikGrafikModel { Id = id, SiparisTarihi = siparisTarihi, SiparisAciklamasi = "Sipariş Açiklamasi" + id.ToString(), SiparisAcikMi= siparisAcikMi });
            }

            var dataMonthOpenOrder = data.Where(x => x.SiparisTarihi >= startDate).Where(x => x.SiparisTarihi <= endDate).Where(x=>x.SiparisAcikMi==true);
            var groupMonthOpenOrder = dataMonthOpenOrder
            .Select(o => new { o.SiparisTarihi.Month }).GroupBy(x => x.Month).OrderBy(x => x.Key)
            .Select(o => new KeyValuePair<string, int>(Utils.GetMonthName(o.Key), o.Count())).ToList();
            var (labelsMonthOpenOrder, seriesMonthOpenOrder) = Utils.KeyValuePairToArray(groupMonthOpenOrder);
            this.SeriesMonthOpenOrder = seriesMonthOpenOrder;
            this.LabelsMonthOpenOrder = labelsMonthOpenOrder;




            var dataMonthCloseOrder = data.Where(x => x.SiparisTarihi >= startDate).Where(x => x.SiparisTarihi <= endDate).Where(x => x.SiparisAcikMi == false);
            var groupMonthCloseOrder = dataMonthCloseOrder
            .Select(o => new { o.SiparisTarihi.Month }).GroupBy(x => x.Month).OrderBy(x => x.Key)
            .Select(o => new KeyValuePair<string, int>(Utils.GetMonthName(o.Key), o.Count())).ToList();
            var (labelsMonthCloseOrder, seriesMonthCloseOrder) = Utils.KeyValuePairToArray(groupMonthCloseOrder);
            this.SeriesMonthCloseOrder = seriesMonthCloseOrder;
            this.LabelsMonthCloseOrder = labelsMonthCloseOrder;

        }

    }
}
