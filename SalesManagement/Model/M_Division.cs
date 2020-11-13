using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement
{
    class M_Division
    {
        public int M_DivisionID { get; set; }
        [StringLength(50)]
        public string DivisionName { get; set; }
        public bool DspFLG { get; set; }
        [StringLength(80)]
        public string Comments { get; set; }

    }
}
