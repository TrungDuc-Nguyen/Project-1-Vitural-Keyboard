using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using log4net;
using log4net.Config;
using System.Reflection;

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
      
        //private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// khai báo biến logger dùng ghi lại log, cấu hình ở App.cofig 
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(Form1).Name);

        /*
     [DllImport("USER32.DLL")]
     private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

     [DllImport("USER32.DLL")]
      private static extern bool SetForegroundWindow(IntPtr hWnd);

     public void Find_Active()
     {
         Process app = Process.Start("Notepad++");
         app.WaitForInputIdle();
         IntPtr hWnd = FindWindow(null, "Notepad++");
         if (hWnd == IntPtr.Zero) 
         {
             MessageBox.Show("Window not found!");
         }
         else 
         {
             SetForegroundWindow(hWnd);
             SendKeys.Send("111");
         }
     }*/
        
        public Form1()
        {
            InitializeComponent();       
        }

        /// <summary>
        /// Hàm xử lý sự kiện khi nhấn button bắt kỳ
        /// </summary>
        /// <param name="sender">Lấy properties của button vừa nhấn</param>
        /// <param name="e"></param>
         void Any_Click(object sender, EventArgs e)
        {           
            Button btn = sender as Button;  // Gán 1 button bất kì vừa nhấn cho biến btn
            int TagOfbtn = Convert.ToInt32(btn.Tag);   // Chuyển properties của button sang kiểu int
            string CodeOfbtn = KeycodeToChar(TagOfbtn);    // Gán keycode của button cho biến x bằng hàm KeycodeToChar
            //SendKeys.Send(CodeOfbtn);
            //logger.Info(CodeOfbtn);

            int ValueOfCaps = Convert.ToInt32(Keys.CapsLock);
            int ValueOfShiftLeft = Convert.ToInt32(Keys.LShiftKey);
            int ValueOfShiftRight = Convert.ToInt32(Keys.RShiftKey);
            int ValueOfCtrlLeft = Convert.ToInt32(Keys.LControlKey);
            int ValueOfCtrlRight = Convert.ToInt32(Keys.RControlKey);
            if (TagOfbtn == ValueOfCaps)
            {   
                Caps_On();
                string x = Is_Upper(CodeOfbtn);
                SendKeys.Send(x);
            }
            else
            {                
                SendKeys.Send(CodeOfbtn);
            }           
        }

        /// <summary>
        /// Hàm chuyển chuỗi hoa thành thường và thường thành hoa.
        /// </summary>
        /// <param name="chuoi"></param>
        /// <returns></returns>
        public string Is_Upper(string chuoi) => chuoi.ToUpper();
        public string Is_Lower(string chuoi) => chuoi.ToLower();

        /// <summary>
        /// Hàm kiểm tra và trả về giá trị của keycode của button vừa nhấn
        /// </summary>
        /// <param name="KeyCode">Giá trị key đưa vào để chuyển sang keycode dùng cho lệnh Send</param>
        /// <returns></returns>
        public String KeycodeToChar(int KeyCode)
        {
            Keys key = (Keys)KeyCode;

            switch (key)
            {
                #region key
                case Keys.Q:
                    return "q";
                case Keys.W:
                    return "w";
                case Keys.E:
                    return "e";
                case Keys.R:
                    return "r";
                case Keys.T:
                    return "t";
                case Keys.Y:
                    return "y";
                case Keys.U:
                    return "u";
                case Keys.I:
                    return "i";
                case Keys.O:
                    return "o";
                case Keys.P:
                    return "p";
                case Keys.A:
                    return "a";
                case Keys.S:
                    return "s";
                case Keys.D:
                    return "d";
                case Keys.F:
                    return "f";
                case Keys.G:
                    return "g";
                case Keys.H:
                    return "h";
                case Keys.J:
                    return "j";
                case Keys.K:
                    return "k";
                case Keys.L:
                    return "l";
                case Keys.Z:
                    return "z";
                case Keys.X:
                    return "x";
                case Keys.C:
                    return "c";
                case Keys.V:
                    return "v";
                case Keys.B:
                    return "b";
                case Keys.N:
                    return "n";
                case Keys.M:
                    return "m";
                case Keys.Escape:
                    return "{ESC}";
                case Keys.Tab:
                    return "{TAB}";
                case Keys.RWin:
                    return "^{ESC}";
                case Keys.Space:
                    return " ";
                case Keys.Back:
                    return "{BS}";
                case Keys.Delete:
                    return "{DEL}";
                case Keys.Enter:
                    return "{ENTER}";
                case Keys.Up:
                    return "{UP}";
                case Keys.Down:
                    return "{DOWN}";
                case Keys.Left:
                    return "{LEFT}";
                case Keys.Right:
                    return "{RIGHT}";
                case Keys.Home:
                    return "{HOME}";
                case Keys.End:
                    return "{END}";
                case Keys.Insert:
                    return "{INSERT}";
                case Keys.PrintScreen:
                    return "{PRTSC}";
                case Keys.PageDown:
                    return "{PGDN}";
                case Keys.PageUp:
                    return "{PGUP}";
                case Keys.Scroll:
                    return "{SCROLLLOCK}";
                case Keys.Help:
                    return "{HELP}";
                case Keys.LShiftKey:
                    return "+";
                case Keys.RShiftKey:
                    return "+";
                case Keys.LControlKey:
                    return "-";
                case Keys.RControlKey:
                    return "-";
                case Keys.LMenu:
                    return "%";
                case Keys.RMenu:
                    return "%";
                case Keys.CapsLock:
                    return "{CAPSLOCK}";
                case Keys.Oem3:
                    return "`";
                case Keys.Oem1:
                    return ";";
                case Keys.Oemplus:
                    return "=";
                case Keys.Oemcomma:
                    return ",";
                case Keys.OemMinus:
                    return "-";
                case Keys.OemPeriod:
                    return ".";
                case Keys.Oem2:
                    return "/";
                case Keys.NumPad0:
                    return "[";
                case Keys.NumPad1:
                    return "]";
                case Keys.NumPad2:
                    return "\\";
                case Keys.NumPad3:
                    return "'";
                case Keys.D1:
                    return "1";
                case Keys.D2:
                    return "2";
                case Keys.D3:
                    return "3";
                case Keys.D4:
                    return "4";
                case Keys.D5:
                    return "5";
                case Keys.D6:
                    return "6";
                case Keys.D7:
                    return "7";
                case Keys.D8:
                    return "8";
                case Keys.D9:
                    return "9";
                case Keys.D0:
                    return "0";
                default:
                    return key.ToString();
#endregion
            }
        }

        /// <summary>
        /// hàm xử lý sự kiện khi nhấn phím capslock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Code cho phím CapsLock

        private void Caps_On()
        {
            /*Caps.BackColor = Color.Yellow;
            Caps.ForeColor = Color.Black;
            Caps.Text = "CAPS";*/
           // Caps_Button = true;
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
            /*Caps.BackColor = Color.Black;
            Caps.ForeColor = Color.White;
            Caps.Text = "Caps";*/
           // Caps_Button = false;
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

        /// <summary>
        /// hàm xử lý sự kiện khi nhấn phím shift
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Code cho phím Shift
        public void Shift_Event()
        {

        }

        private void Shift_On()
        {
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

        #endregion

        /// <summary>
        /// hàm xử lý sự kiện khi nhấn phím Fn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Code cho Fn

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

        private void Fn_On()
        {
            /* Fn.BackColor = Color.Yellow;
             Fn.ForeColor = Color.Black;
             Fn.Text = "FN";*/
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
            /*Fn.BackColor = Color.Black;
            Fn.ForeColor = Color.White;
            Fn.Text = "Fn";*/
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
        #endregion

        /// <summary>
        /// các hàm bool dùng để xử lý sự kiện với các phím Shift, Capslock, Fn
        /// </summary>
        //bool Shift_Button = false;
        //bool Caps_Button = false;
        bool Fn_Button = false;

        private void button2_Click(object sender, EventArgs e)
        {

        }

        // các hàm dùng Send để gửi phím đến app
        /* private void Tab_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{TAB}");
             logger.Info("TAB");
         }

         private void button1_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{ESC}");
             logger.Info("ESC");
         }

         private void button73_Click(object sender, EventArgs e)
         {

         }

         private void button79_Click(object sender, EventArgs e)
         {

         }

         private void button85_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{Right}");
             logger.Info("Right");
         }

         private void button3_Click(object sender, EventArgs e)
         {
             if(Fn.Checked)
             {
                 SendKeys.Send("{F1}");
                 Fn.Checked = false;
                 logger.Info("F1");
             }
             else if(Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("!");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("!");
             }
             else
             {
                 SendKeys.Send("1");
                 logger.Info("1");
             }
         }
         private void q_Click(object sender, EventArgs e)
         {


         }

         private void Console_Click(object sender, EventArgs e)
         {
            if(Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("{~}");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("~");
             }
            else
             {
                 SendKeys.Send("`");
                 logger.Info("`");
             }
         }




         private void Fade_Click(object sender, EventArgs e)
         {

         }

         private void Dock_Click(object sender, EventArgs e)
         {

         }

         private void MvDn_Click(object sender, EventArgs e)
         {

         }

         private void MvUp_Click(object sender, EventArgs e)
         {

         }

         private void Nav_Click(object sender, EventArgs e)
         {

         }

         private void Help_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{HELP}");
             logger.Info("HELP");
         }

         private void ScrLk_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{SCROLLLOCK}");
             logger.Info("SCROLLLOCK");
         }

         private void Pause_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{BREAK}");
             logger.Info("BREAK");
         }

         private void PgDn_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{PGDN}");
             logger.Info("PGDN");
         }

         private void PgUp_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{PGUP}");
             logger.Info("PGUP");
         }

         private void Options_Click(object sender, EventArgs e)
         {

         }

         private void PrtScn_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{PRTSC}");
             logger.Info("PRTSC");
         }

         private void Insert_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{INSERT}");
             logger.Info("INSERT");
         }

         private void End_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{END}");
             logger.Info("END");
         }

         private void Home_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{HOME}");
             logger.Info("HOME");
         }

         private void Del_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{DEL}");
             logger.Info("DEL");
         }

         private void Back_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{BS}");
             logger.Info("BACKSPACE");
         }

         private void App_Click(object sender, EventArgs e)
         {

         }

         private void Enter_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{ENTER}");
             logger.Info("ENTER");
         }

         private void Scars_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("|");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("|");
             }
             else
             {
                 SendKeys.Send("\\");
                 logger.Info("\\");
             }
         }

         private void Equal_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F12}");
                 Fn.Checked = false;
                 logger.Info("F12");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("{+}");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("+");
             }
             else
             {
                 SendKeys.Send("=");
                 logger.Info("=");
             }
         }

         private void CloseBracket_Click(object sender, EventArgs e)
         {
             if(Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("}");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("}");
             }
             else
             {
                 SendKeys.Send("]");
                 logger.Info("]");
             }
         }

         private void Dash_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F11}");
                 Fn.Checked = false;
                 logger.Info("F11");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("_");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("_");
             }
             else
             {
                 SendKeys.Send("-");
                 logger.Info("-");
             }
         }

         private void Down_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{DOWN}");
             logger.Info("DOWN");
         }

         private void Up_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{UP}");
             logger.Info("UP");
         }

         private void Quotes_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("\"");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("\"");
             }
             else
             {
                 SendKeys.Send("\''");
                 logger.Info("\"");
             }
         }

         private void OpenBracket_Click(object sender, EventArgs e)
         {
             if(Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("{");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("{");
             }
             else
             {
                 SendKeys.Send("[");
                 logger.Info("[");
             }
         }

         private void ten_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F10}");
                 Fn.Checked = false;
                 logger.Info("F10");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("{)}");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("{)}");
             }
             else
             {
                 SendKeys.Send("0");
                 logger.Info("0");
             }
         }

         private void Left_Click(object sender, EventArgs e)
         {
             SendKeys.Send("{Left}");
             logger.Info("LEFT");
         }

         private void Question_Click(object sender, EventArgs e)
         {

             if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("?");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("?");
             }
             else
             {
                 SendKeys.Send("/");
                 logger.Info("/");
             }
         }

         private void Clon_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send(":");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info(":");
             }
             else
             {
                 SendKeys.Send(";");
                 logger.Info(";");
             }
         }

         private void p_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("P");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("P");
             }
             else
             {
                 SendKeys.Send("p");
                 logger.Info("p");
             }
         }

         private void nine_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F9}");
                 Fn.Checked = false;
                 logger.Info("F9");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("{(}");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("{(}");
             }
             else
             {
                 SendKeys.Send("9");
                 logger.Info("9");
             }
         }

         private void Bigger_Click(object sender, EventArgs e)
         {

             if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send(">");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info(">");
             }
             else
             {
                 SendKeys.Send(".");
                 logger.Info(".");
             }
         }

         private void l_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("L");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("L");
             }
             else
             {
                 SendKeys.Send("l");
                 logger.Info("l");
             }
         }

         private void o_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("O");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("O");
             }
             else
             {
                 SendKeys.Send("o");
                 logger.Info("o");
             }
         }

         private void eight_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F8}");
                 Fn.Checked = false;
                 logger.Info("F8");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("*");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("*");
             }
             else
             {
                 SendKeys.Send("8");
                 logger.Info("8");
             }
         }

         private void Smaller_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("<");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("<");
             }
             else
             {
                 SendKeys.Send(",");
                 logger.Info(",");
             }
         }

         private void k_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("K");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("K");
             }
             else
             {
                 SendKeys.Send("k");
                 logger.Info("k");
             }
         }

         private void i_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("I");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("I");
             }
             else
             {
                 SendKeys.Send("i");
                 logger.Info("i");
             }
         }

         private void seven_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F7}");
                 Fn.Checked = false;
                 logger.Info("F7");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("&");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("&");
             }
             else
             {
                 SendKeys.Send("7");
                 logger.Info("7");
             }
         }

         private void m_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("M");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("M");
             }
             else
             {
                 SendKeys.Send("m");
                 logger.Info("m");
             }
         }

         private void j_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("J");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("J");
             }
             else
             {
                 SendKeys.Send("j");
                 logger.Info("j");
             }
         }

         private void u_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("U");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("U");
             }
             else
             {
                 SendKeys.Send("u");
                 logger.Info("u");
             }
         }

         private void six_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F6}");
                 Fn.Checked = false;
                 logger.Info("F6");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("{^}");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("{^}");
             }
             else
             {
                 SendKeys.Send("6");
                 logger.Info("6");
             }
         }

         private void n_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("N");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("N");
             }
             else
             {
                 SendKeys.Send("n");
                 logger.Info("n");
             }
         }

         private void h_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("H");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("H");
             }
             else
             {
                 SendKeys.Send("h");
                 logger.Info("h");
             }
         }

         private void y_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("Y");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("Y");
             }
             else
             {
                 SendKeys.Send("y");
                 logger.Info("y");
             }
         }

         private void five_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F5}");
                 Fn.Checked = false;
                 logger.Info("F5");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("{%}");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("{%}");
             }
             else
             {
                 SendKeys.Send("5");
                 logger.Info("5");
             }
         }

         private void b_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("B");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("B");
             }
             else
             {
                 SendKeys.Send("b");
                 logger.Info("b");
             }
         }

         private void g_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("G");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("G");
             }
             else
             {
                 SendKeys.Send("g");
                 logger.Info("g");
             }
         }

         private void t_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("T");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("T");
             }
             else
             {
                 SendKeys.Send("t");
                 logger.Info("t");
             }
         }

         private void four_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F4}");
                 Fn.Checked = false;
                 logger.Info("F4");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("$");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("$");
             }
             else
             {
                 SendKeys.Send("4");
                 logger.Info("4");
             }
         }

         private void Space_Click(object sender, EventArgs e)
         {
             SendKeys.Send(" ");
             logger.Info("SPACE");
         }

         private void v_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("V");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("V");
             }
             else if(Ctrl1.Checked || Ctrl2.Checked)
             {
                 SendKeys.Send("^v");
                 Ctrl1.Checked = false;
                 Ctrl2.Checked = false;
                 logger.Info("PASTE");
             }
             else
             {
                 SendKeys.Send("v");
                 logger.Info("v");
             }
         }

         private void f_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("F");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("F");
             }
             else if(Ctrl1.Checked || Ctrl2.Checked)
             {
                 SendKeys.Send("^(f)");
                 logger.Info("FIND");
             }
             else
             {
                 SendKeys.Send("f");
                 logger.Info("f");
             }
         }

         private void r_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("R");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("R");
             }
             else
             {
                 SendKeys.Send("r");
                 logger.Info("r");
             }
         }

         private void three_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F3}");
                 Fn.Checked = false;
                 logger.Info("F3");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("#");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("#");
             }
             else
             {
                 SendKeys.Send("3");
                 logger.Info("3");
             }
         }

         private void c_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("C");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("C");
             }
             else if(Ctrl1.Checked || Ctrl2.Checked)
             {
                 SendKeys.Send("^c");
                 Ctrl1.Checked = false;
                 Ctrl2.Checked = false;
                 logger.Info("COPPY");
             }
             else
             {
                 SendKeys.Send("c");
                 logger.Info("c");
             }
         }

         private void d_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("D");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("D");
             }
             else if(Ctrl1.Checked || Ctrl2.Checked)
             {
                 SendKeys.Send("^(d)");
                 Ctrl1.Checked = false;
                 Ctrl2.Checked = false;
                 logger.Info("DELETE");
             }
             else
             {
                 SendKeys.Send("d");
                 logger.Info("d");
             }
         }

         private void e_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("E");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("E");
             }
             else
             {
                 SendKeys.Send("e");
                 logger.Info("e");
             }
         }

         private void two_Click(object sender, EventArgs e)
         {
             if (Fn.Checked)
             {
                 SendKeys.Send("{F2}");
                 Fn.Checked = false;
                 logger.Info("F2");
             }
             else if (Shift1.Checked || Shift2.Checked)
             {
                 SendKeys.Send("@");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("@");
             }
             else
             {
                 SendKeys.Send("2");
                 logger.Info("2");
             }
         }

         private void Win_Click(object sender, EventArgs e)
         {
             SendKeys.Send("^({ESC})");
             logger.Info("WINDOWS");
         }

         private void x_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("X");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("X");
             }
             else if(Ctrl1.Checked || Ctrl2.Checked)
             {
                 SendKeys.Send("^x");
                 Ctrl1.Checked = false;
                 Ctrl2.Checked = false;
                 logger.Info("CUT");
             }
             else
             {
                 SendKeys.Send("x");
                 logger.Info("x");
             }
         }

         private void s_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("S");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("S");
             }
             else
             {
                 SendKeys.Send("s");
                 logger.Info("s");
             }
         }

         private void w_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("W");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("W");
             }
             else
             {
                 SendKeys.Send("w");
                 logger.Info("w");
             }
         }

         private void z_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("Z");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("z");
             }
             else if(Ctrl1.Checked || Ctrl2.Checked)
             {
                 SendKeys.Send("^z");
                 Ctrl1.Checked = false;
                 Ctrl2.Checked = false;
                 logger.Info("UNDO");
             }
             else
             {
                 SendKeys.Send("z");
                 logger.Info("z");
             }
         }

         private void a_Click(object sender, EventArgs e)
         {
             if (Shift1.Checked || Shift2.Checked || Caps.Checked)
             {
                 SendKeys.Send("A");
                 Shift1.Checked = false;
                 Shift2.Checked = false;
                 logger.Info("A");
             }
             else if(Ctrl1.Checked || Ctrl2.Checked)
             {
                 SendKeys.Send("^a");
                 Ctrl1.Checked = false;
                 Ctrl2.Checked = false;
                 logger.Info("BLACKENED");
             }
             else
             {
                 SendKeys.Send("a");
                 logger.Info("a");
             }
         }*/
    }
}
