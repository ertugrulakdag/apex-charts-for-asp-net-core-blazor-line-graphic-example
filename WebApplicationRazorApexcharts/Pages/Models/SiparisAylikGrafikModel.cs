using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRazorApexcharts.Pages.Models
{
    public class SiparisAylikGrafikModel
    {
        public DateTime SiparisTarihi { get; set; }
        public string SiparisAciklamasi { get; set; }
        public int Id { get; set; }
        public bool SiparisAcikMi { get; set; }
    }
}
