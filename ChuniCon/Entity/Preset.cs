using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChuniCon.Entity
{
    internal class Preset
    {
        [Newtonsoft.Json.JsonIgnore()]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public string OriginName { get; set; }
        public KeyPair[] KeyPair { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public KeyGroup[] KeyGroup { get; set; }
        public RGBPair[] RGBPair { get; set; }
        public byte Sensitivity { get; set; }
        public byte SensitivityValue
        {
            get
            {
                var v = Math.Round(255f - 255f * Sensitivity / 100f);
                return (byte)(v <= 0 ? 1 : v);
            }
            private set
            {
            }
        }

        public void GenKeyGroup()
        {
            var tmp = new Dictionary<Keys, KeyGroup>();
            foreach (var pair in KeyPair)
            {
                if (pair == null)
                    continue;
                if (!tmp.ContainsKey(pair.Key))
                {
                    tmp[pair.Key] = new KeyGroup()
                    {
                        Key = pair.Key,
                        Status = false,
                        Area = new List<byte>()
                    };
                }
                tmp[pair.Key].Area.Add(pair.Area);
            }
            KeyGroup = tmp.Values.ToArray();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
