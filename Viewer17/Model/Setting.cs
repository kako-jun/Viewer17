using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace Viewer17
{
    public class Setting
    {
        public enum Act
        {
            Act1,   // ウィンドウ表示
            Act2,   // 全体化　パネルあり
            Act3,   // 全体化　パネルなし
        };

        public List<ConsolePanel> panels { get; set; }
        public string dstDirPath { get; set; }
        public Size buttonSize { get; set; }
        public bool lefty { get; set; }

        public Act act { get; set; }
        public int level { get; set; }

        public Setting()
        {
            panels = new List<ConsolePanel>();
            dstDirPath = "";
            buttonSize = new Size(150, 30);
            lefty = false;

            act = Act.Act1;
            level = 0;
        }

        private static string file_name = "viewer17_setting_" + Viewer17.Properties.Resources.Lang + ".xml";

        public bool save()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + file_name;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Setting));
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);
                serializer.Serialize(fs, this);
                fs.Close();

                // 
                string text = System.IO.File.ReadAllText(path, Encoding.GetEncoding("utf-8"));
                int find = text.IndexOf("</Setting>");
                text = text.Substring(0, find);
                text += "</Setting>";

                System.IO.File.WriteAllText(path, text, Encoding.GetEncoding("utf-8"));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool load()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + file_name;
            Setting tempSetting = new Setting();

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Setting));
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
                tempSetting = (Setting)serializer.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                return false;
            }

            this.panels = tempSetting.panels;
            this.dstDirPath = tempSetting.dstDirPath;
            this.buttonSize = tempSetting.buttonSize;
            this.lefty = tempSetting.lefty;

            this.act = tempSetting.act;
            this.level = tempSetting.level;

            return true;
        }
    }
}
