using System.Collections.Generic;
using System.Windows.Forms;

namespace ChuniCon.Entity
{
    internal class KeyGroup
    {
        public Keys Key { get; set; }
        public List<byte> Area { get; set; }
        public bool Status { get; set; }
    }
}
