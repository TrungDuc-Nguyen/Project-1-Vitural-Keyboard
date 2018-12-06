using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace On_Screen_KeyBoard
{
public partial class Form1 : Form
    {
        protected override CreateParams CreateParams
         {
             get
             {
                 CreateParams param = base.CreateParams;
                     param.ExStyle = 0x08000000; // gọi hàm Enable windows -> cấm focus vào app hiện tại
                 return param;
             }
         }
        /// <summary>
        /// khai báo biến logger dùng ghi lại log, cấu hình ở App.cofig 
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(Form1).Name);
        /// <summary>
            /// Danh sách các phím ấn
            /// </summary>
        List<Button> myButton = new List<Button>();
        public Form1()
        {
            InitializeComponent();           
            // Add toàn bộ button trong form vào list myButton.
            List<Button> myButton = this.Controls.OfType<Button>().ToList();
            // Set Key Value cho các Button
#region Set Key cho Button
            new KeyValueNewSet("Esc", "{ESC}", "{ESC}","{ESC}");
            new KeyValueNewSet("Console", "`", "~", "`");
            new KeyValueNewSet("one", "1", "!", "{F1}");
            new KeyValueNewSet("two", "2", "@", "{F2}");
            new KeyValueNewSet("three", "3", "#", "{F3}");
            new KeyValueNewSet("four", "4", "{$}", "{F4}");
            new KeyValueNewSet("five", "5", "{%}", "{F5}");
            new KeyValueNewSet("six", "6", "{^}", "{F6}");
            new KeyValueNewSet("seven", "7", "&", "{F7}");
            new KeyValueNewSet("eight", "8", "*", "{F8}");
            new KeyValueNewSet("nine", "9", "{(}", "{F9}");
            new KeyValueNewSet("ten", "0", "{)}", "{F10}");
            new KeyValueNewSet("Dash", "-", "_", "{F11}");
            new KeyValueNewSet("Equal", "=", "{+}", "{F12}");
            new KeyValueNewSet("Back", "{BS}", "{BS}", "{BS}");
            new KeyValueNewSet("Tab", "{TAB}", "{TAB}", "{TAB}");
            new KeyValueNewSet("q", "q", "Q", "q");
            new KeyValueNewSet("w", "w", "W", "w");
            new KeyValueNewSet("e", "e", "E", "e");
            new KeyValueNewSet("r", "r", "R", "r");
            new KeyValueNewSet("t", "t", "T", "t");
            new KeyValueNewSet("y", "y", "Y", "y");
            new KeyValueNewSet("u", "u", "U", "u");
            new KeyValueNewSet("i", "i",  "I", "i");
            new KeyValueNewSet("o", "o", "O", "o");
            new KeyValueNewSet("p", "p", "P", "p");
            new KeyValueNewSet("OpenBracket", "[", "{{}", "[");
            new KeyValueNewSet("CloseBracket", "]", "{}}", "]");
            new KeyValueNewSet("Scars", "\\", "|", "\\");
            new KeyValueNewSet("Del", "{DEL}", "{DEL}", "{DEL}");
            new KeyValueNewSet("a", "a", "A", "a");
            new KeyValueNewSet("s", "s", "S", "s");
            new KeyValueNewSet("d", "d", "D", "d");
            new KeyValueNewSet("f", "f", "F", "f");
            new KeyValueNewSet("g", "g", "G", "g");
            new KeyValueNewSet("h", "h", "H", "h");
            new KeyValueNewSet("j", "j", "J", "j");
            new KeyValueNewSet("k", "k", "K", "k");
            new KeyValueNewSet("l", "l", "L", "l");
            new KeyValueNewSet("Clon", ";", ":", ";");
            new KeyValueNewSet("Quotes", "\''", "\"", "\''");
            new KeyValueNewSet("Enter", "{ENTER}", "{ENTER}", "{ENTER}");
            new KeyValueNewSet("z", "z", "Z", "z");
            new KeyValueNewSet("x", "x", "X", "x");
            new KeyValueNewSet("c", "c", "C", "c");
            new KeyValueNewSet("v", "v", "V", "v");
            new KeyValueNewSet("b", "b", "B", "b");
            new KeyValueNewSet("n", "n", "N", "n");
            new KeyValueNewSet("m", "m", "M", "m");
            new KeyValueNewSet("Smaller", ",", "<", ",");
            new KeyValueNewSet("Bigger", ".", ">", ".");
            new KeyValueNewSet("Question", "/", "?", "/");
            new KeyValueNewSet("Win", "^({ESC})",  "^({ESC})", "^({ESC})");
            new KeyValueNewSet("Space", " ", " ",  " ");
            new KeyValueNewSet("Left_Button", "{LEFT}", "{LEFT}", "{LEFT}");
            new KeyValueNewSet("Down", "{DOWN}", "{DOWN}", "{DOWN}");
            new KeyValueNewSet("Right_Button", "{RIGHT}", "{RIGHT}", "{RIGHT}");
            new KeyValueNewSet("Up", "{UP}",  "{UP}", "{UP}");
            new KeyValueNewSet("Home", "{HOME}", "{HOME}", "{HOME}");
            new KeyValueNewSet("End", "{END}", "{END}", "{END}");
            new KeyValueNewSet("Insert", "{INS}", "{INS}", "{INS}");
            new KeyValueNewSet("PrtScn", "{PRTSC}", "{PRTSC}", "{PRTSC}");
            new KeyValueNewSet("PgUp", "{PGUP}", "{PGUP}", "{PGUP}");
            new KeyValueNewSet("PgDn", "{PGDN}", "{PGDN}", "{PGDN}");
            new KeyValueNewSet("Break", "{BREAK}", "{BREAK}", "{BREAK}");
            new KeyValueNewSet("ScrLk", "{SCROLLLOCK}", "{SCROLLLOCK}", "{SCROLLLOCK}");
            new KeyValueNewSet("HELP", "{HELP}", "{HELP}", "{HELP}");
#endregion
        }
        /// <summary>
        /// Hàm xử lý sự kiện khi nhấn button bắt kỳ
        /// </summary>
        /// <param name="sender">Lấy text của button vừa nhấn</param>
        /// <param name="e"></param>
        void Any_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string btn_sendkey1 = KeyValueNewSet.GetSendKey1(btn); // Gán key như ký tự thường 
            string btn_sendkey2 = KeyValueNewSet.GetSendKey2(btn); // Gán key cho ký tự khi ấn Shift
            string btn_sendkey3 = KeyValueNewSet.GetSendKey3(btn); // Gán key cho dãy phím chức năng F1 -> F12, khi ấn Fn
            if(LShift.Checked || RShift.Checked) // Xử lý Send khi ấn Shift
            {
                SendKeys.Send(btn_sendkey2);
                LShift.Checked = false;
                RShift.Checked = false;
                logger.Info(btn_sendkey2);
            }
            else if(Caps.Checked) // Xử lý Send khi ấn Caps
            {
                SendKeys.Send(btn_sendkey1.ToUpper());
                logger.Info(btn_sendkey1.ToUpper());
            }
            else if(Fn.Checked) // Xử lý Send khi ấn Fn
            {
                SendKeys.Send(btn_sendkey3);
                Fn.Checked = false;
                logger.Info(btn_sendkey3);
            }
            else if(LCtrl.Checked || RCtrl.Checked) // Xử lý Send khi ấn Ctrl
            {
                if(btn_sendkey1 == "c" || btn_sendkey1 == "v" || btn_sendkey1 == "x" || btn_sendkey1 == "z"
                    || btn_sendkey1 == "a" || btn_sendkey1 == "f")
                {
                    string btn_chuoi = "^" + btn_sendkey1;
                    SendKeys.Send(btn_chuoi);
                    LCtrl.Checked = false;
                    RCtrl.Checked = false;
                    logger.Info(btn_sendkey1);
                }
            }
            else
            {
                SendKeys.Send(btn_sendkey1);
                logger.Info(btn_sendkey1);
            }
        }     
        /// <summary>
        /// các hàm bool dùng để xử lý sự kiện với các phím Shift, Capslock, Fn
        /// </summary>
        bool Fn_Button = false;
        bool Shift_Button = false;
        bool Caps_Button = false;
        bool Ctrl_Button = false;
        /// <summary>
        /// hàm xử lý sự kiện khi nhấn phím Fn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Code cho các phím chức năng Shift, Caps, Fn
        private void Fn_CheckedChanged(object sender, EventArgs e)
        {
            if (Fn_Button)
            {
                Fn_Off();
            }
            else
            {
                Fn_On();
            }
        }
        private void Caps_CheckedChanged(object sender, EventArgs e)
        {
            if (Caps_Button)
            {
                Caps_Off();
            }
            else
            {
                Caps_On();
            }
        }
        private void LShift_CheckedChanged(object sender, EventArgs e)
        {
            if (Shift_Button)
            {
                Shift_Off();
            }
            else
            {
                Shift_On();
            }
        }
        private void RShift_CheckedChanged(object sender, EventArgs e)
        {
            if (Shift_Button)
            {
                Shift_Off();
            }
            else
            {
                Shift_On();
            }
        }
        private void LCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (Ctrl_Button)
            {
                Ctrl_Button = true;
            }
            else
            {
                Ctrl_Button = false;
            }
        }

        private void RCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (Ctrl_Button)
            {
                Ctrl_Button = true;
            }
            else
            {
                Ctrl_Button = false;
            }
        }
        private void Fn_On()
        {
            Fn_Button = true;
            one.Text = "F1";
            two.Text = "F2";
            three.Text = "F3";
            four.Text = "F4";
            five.Text = "F5";
            six.Text = "F6";
            seven.Text = "F7";
            eight.Text = "F8";
            nine.Text = "F9";
            ten.Text = "F10";
            Dash.Text = "F11";
            Equal.Text = "F12";
        }
        private void Fn_Off()
        {
            Fn_Button = false;
            one.Text = "! \n 1";
            two.Text = "@ \n 2";
            three.Text = "# \n 3";
            four.Text = "$ \n 4";
            five.Text = "% \n 5";
            six.Text = "^ \n 6";
            seven.Text = "& \n 7";
            eight.Text = "* \n 8";
            nine.Text = "( \n 9";
            ten.Text = ") \n 0";
            Dash.Text = "- \n -";
            Equal.Text = "+ \n =";
        }
        private void Shift_On()
        {
            Shift_Button = true;
            q.Text = "Q";
            w.Text = "W";
            e.Text = "E";
            r.Text = "R";
            t.Text = "T";
            y.Text = "Y";
            u.Text = "U";
            i.Text = "I";
            o.Text = "O";
            p.Text = "P";
            a.Text = "A";
            s.Text = "S";
            d.Text = "D";
            f.Text = "F";
            g.Text = "G";
            h.Text = "H";
            j.Text = "J";
            k.Text = "K";
            l.Text = "L";
            z.Text = "Z";
            x.Text = "X";
            c.Text = "C";
            v.Text = "V";
            b.Text = "B";
            n.Text = "N";
            m.Text = "M";
            Console.Text = "~";
            one.Text = "!";
            two.Text = "@";
            three.Text = "#";
            four.Text = "$";
            five.Text = "%";
            six.Text = "^";
            seven.Text = "&";
            eight.Text = "*";
            nine.Text = "(";
            ten.Text = ")";
            Dash.Text = "_";
            Equal.Text = "+";
            OpenBracket.Text = "{";
            CloseBracket.Text = "}";
            Scars.Text = "|";
            Clon.Text = ":";
            Quotes.Text = "\"";
            Smaller.Text = "<";
            Bigger.Text = ">";
            Question.Text = "?";
        }
        private void Shift_Off()
        {
            Shift_Button = false;
            q.Text = "q";
            w.Text = "w";
            e.Text = "e";
            r.Text = "r";
            t.Text = "t";
            y.Text = "y";
            u.Text = "u";
            i.Text = "i";
            o.Text = "o";
            p.Text = "p";
            a.Text = "a";
            s.Text = "s";
            d.Text = "d";
            f.Text = "f";
            g.Text = "g";
            h.Text = "h";
            j.Text = "j";
            k.Text = "k";
            l.Text = "l";
            z.Text = "z";
            x.Text = "x";
            c.Text = "c";
            v.Text = "v";
            b.Text = "b";
            n.Text = "n";
            m.Text = "m";
            Console.Text = "~ `";
            one.Text = "! \n 1";
            two.Text = "@ \n 2";
            three.Text = "# \n 3";
            four.Text = "$ \n 4";
            five.Text = "% \n 5";
            six.Text = "^ \n 6";
            seven.Text = "& \n 7";
            eight.Text = "* \n 8";
            nine.Text = "( \n 9";
            ten.Text = ") \n 0";
            Dash.Text = "- \n -";
            Equal.Text = "+ \n =";
            OpenBracket.Text = "{ \n [";
            CloseBracket.Text = "} \n ]";
            Scars.Text = "| \n \\";
            Clon.Text = ": \n ;";
            Quotes.Text = "\" \n '";
            Smaller.Text = "< \n ,";
            Bigger.Text = "> \n .";
            Question.Text = "? \n /";
        }
        private void Caps_On()
        {
            Caps_Button = true;
            q.Text = "Q";
            w.Text = "W";
            e.Text = "E";
            r.Text = "R";
            t.Text = "T";
            y.Text = "Y";
            u.Text = "U";
            i.Text = "I";
            o.Text = "O";
            p.Text = "P";
            a.Text = "A";
            s.Text = "S";
            d.Text = "D";
            f.Text = "F";
            g.Text = "G";
            h.Text = "H";
            j.Text = "J";
            k.Text = "K";
            l.Text = "L";
            z.Text = "Z";
            x.Text = "X";
            c.Text = "C";
            v.Text = "V";
            b.Text = "B";
            n.Text = "N";
            m.Text = "M";
        }
        private void Caps_Off()
        {
            Caps_Button = false;
            q.Text = "q";
            w.Text = "w";
            e.Text = "e";
            r.Text = "r";
            t.Text = "t";
            y.Text = "y";
            u.Text = "u";
            i.Text = "i";
            o.Text = "o";
            p.Text = "p";
            a.Text = "a";
            s.Text = "s";
            d.Text = "d";
            f.Text = "f";
            g.Text = "g";
            h.Text = "h";
            j.Text = "j";
            k.Text = "k";
            l.Text = "l";
            z.Text = "z";
            x.Text = "x";
            c.Text = "c";
            v.Text = "v";
            b.Text = "b";
            n.Text = "n";
            m.Text = "m";
        }
        #endregion
    }
}
