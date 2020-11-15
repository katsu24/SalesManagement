using System.ComponentModel.DataAnnotations;

namespace SalesManagement
{
    public class M_Division
    {
        public int M_DivisionID { get; set; }
        [StringLength(50)]
        public string DivisionName { get; set; }
        public bool DspFLG { get; set; }
        [StringLength(80)]
        public string Comments { get; set; }
    }
}
