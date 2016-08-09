using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Xml.Serialization;

namespace Viewer17
{
    public class ConsolePanel
    {
        public enum Pos : int
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
        };

        public int id { get; set; }
        public string title { get; set; }
        [XmlIgnoreAttribute()]
        public Color fgColor { get; set; }
        [XmlIgnoreAttribute()]
        public Color bgColor { get; set; }
        public Pos pos { get; set; }
        public List<ConsoleButton> buttons { get; set; }

        [XmlElementAttribute("fgColor")]
        public int serializeFgColor
        {
            get
            {
                return fgColor.ToArgb();
            }

            set
            {
                fgColor = Color.FromArgb(value);
            }
        }

        [XmlElementAttribute("bgColor")]
        public int serializeBgColor
        {
            get
            {
                return bgColor.ToArgb();
            }

            set
            {
                bgColor = Color.FromArgb(value);
            }
        }

        public ConsolePanel()
        {
            id = 0;
            title = "";
            fgColor = Color.Gray;
            bgColor = Color.Black;
            pos = Pos.TopRight;
            buttons = new List<ConsoleButton>();
        }

        public ConsolePanel(int tempId, string tempTitle, Color tempFgColor, Color tempBgColor, Pos tempPos, List<ConsoleButton> tempButtons)
        {
            id = tempId;
            title = tempTitle;
            fgColor = tempFgColor;
            bgColor = tempBgColor;
            pos = tempPos;
            buttons = tempButtons;
        }
    }

    public class ConsoleButton
    {
        public enum Ope
        {
            Move,
            Copy,
            Delete,
            Undo,
        };

        public enum Key
        {
            None,
            A, B, C, D, E, F, G,
            H, I, J, K, L, M, N,
            O, P, Q, R, S, T, U,
            V, W, X, Y, Z
        };

        public int id { get; set; }
        public string title { get; set; }
        public string iconPath { get; set; }
        public Ope ope { get; set; }
        public string dirName { get; set; }
        public Key key { get; set; }

        public ConsoleButton()
        {
            id = 0;
            title = "";
            iconPath = "";
            ope = Ope.Move;
            dirName = "";
            key = Key.None;
        }

        public ConsoleButton(int tempId, string tempTitle, string tempIconPath, Ope tempOpe, string tempDirName, Key tempKey)
        {
            id = tempId;
            title = tempTitle;
            iconPath = tempIconPath;
            ope = tempOpe;
            dirName = "";
            key = tempKey;
        }
    }
}
