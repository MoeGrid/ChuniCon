using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuniCon.Entity
{
    internal class KeyPair
    {
        public byte Area { get; set; } = 0;
        public Keys Key { get; set; } = 0;
        [Newtonsoft.Json.JsonIgnore()]
        public byte Status { get; set; } = 0;
    }
}
