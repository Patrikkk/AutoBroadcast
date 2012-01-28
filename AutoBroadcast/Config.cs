﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Config
{
    public class abcConfig
    {
        //Message 1
        public bool Message1_Enabled = false;
        public string Message1_Line1 = "";
        public string Message1_Line2 = "";
        public string Message1_Line3 = "";
        public string Message1_Line4 = "";
        public string Message1_Line5 = "";
        public string Message1_Line6 = "";
        public string Message1_Line7 = "";
        public byte Message1_ColorR = 255;
        public byte Message1_ColorG = 255;
        public byte Message1_ColorB = 255;
        public int Message1_Interval = 300;
        public string Message1_Group = "";
        //Message 2
        public bool Message2_Enabled = false;
        public string Message2_Line1 = "";
        public string Message2_Line2 = "";
        public string Message2_Line3 = "";
        public string Message2_Line4 = "";
        public string Message2_Line5 = "";
        public string Message2_Line6 = "";
        public string Message2_Line7 = "";
        public byte Message2_ColorR = 255;
        public byte Message2_ColorG = 255;
        public byte Message2_ColorB = 255;
        public int Message2_Interval = 300;
        public string Message2_Group = "";
        //Message 3
        public bool Message3_Enabled = false;
        public string Message3_Line1 = "";
        public string Message3_Line2 = "";
        public string Message3_Line3 = "";
        public string Message3_Line4 = "";
        public string Message3_Line5 = "";
        public string Message3_Line6 = "";
        public string Message3_Line7 = "";
        public byte Message3_ColorR = 255;
        public byte Message3_ColorG = 255;
        public byte Message3_ColorB = 255;
        public int Message3_Interval = 300;
        public string Message3_Group = "";

        public static abcConfig Read(string path)
        {
            if (!File.Exists(path))
                return new abcConfig();
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return Read(fs);
            }
        }

        public static abcConfig Read(Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                var cf = JsonConvert.DeserializeObject<abcConfig>(sr.ReadToEnd());
                if (ConfigRead != null)
                    ConfigRead(cf);
                return cf;
            }
        }
        public void Write(string path)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                Write(fs);
            }
        }

        public void Write(Stream stream)
        {
            var str = JsonConvert.SerializeObject(this, Formatting.Indented);
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(str);
            }
        }

        public static Action<abcConfig> ConfigRead;
    }
}
