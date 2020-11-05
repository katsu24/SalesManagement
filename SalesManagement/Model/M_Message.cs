using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SalesManagement
{
    class M_Message
    {
        // IdentityをOFFに設定
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string MsgID { get; set; }
        public string MsgComments { get; set; }
        public string MsgTitle { get; set; }
        public int MsgButton { get; set; }
        public int MsgICon { get; set; }
    }
}
