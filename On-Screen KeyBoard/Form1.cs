﻿using System;
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
            
            // ghi log khi chạy form
            //logger.Info("abc");
        }


        /// <summary>
        /// các hàm bool dùng để xử lý sự kiện với các phím Shift, Capslock, Fn
        /// </summary>
        bool Shift_Button = false;
        bool Caps_Button = false;
        bool Fn_Button = false;

        #region Form
       
        private void Form1_Deactivate(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        #endregion

        /// <summary>
        /// hàm xử lý sự kiện khi nhấn phím capslock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Code cho phím CapsLock

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

        private void Caps_On()
        {
            /*Caps.BackColor = Color.Yellow;
            Caps.ForeColor = Color.Black;
            Caps.Text = "CAPS";*/
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
            /*Caps.BackColor = Color.Black;
            Caps.ForeColor = Color.White;
            Caps.Text = "Caps";*/
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

        /// <summary>
        /// hàm xử lý sự kiện khi nhấn phím shift
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Code cho phím Shift

        private void Shift1_CheckedChanged(object sender, EventArgs e)
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

        /// <summary>
        ///        SỰ kiện nut shift phải được bấm
        /// </summary>
        /// <param name="sender">đối tượng phát sinh sự kiện</param>
        /// <param name="e">tham số sự kiện</param>
        private void Shift2_CheckedChanged(object sender, EventArgs e)
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

        private void Shift_On()
        {
            /*Shift1.BackColor = Color.Yellow;
            Shift1.ForeColor = Color.Black;
            Shift1.Text = "SHIFT";
            Shift2.BackColor = Color.Yellow;
            Shift2.ForeColor = Color.Black;
            Shift2.Text = "SHIFT";*/
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
           /* Shift1.BackColor = Color.Black;
            Shift1.ForeColor = Color.White;
            Shift1.Text = "Shift";
            Shift2.BackColor = Color.Black;
            Shift2.ForeColor = Color.White;
            Shift2.Text = "Shift";*/
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


        // các hàm dùng Send để gửi phím đến app
        private void Tab_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Fn.Checked)
            {
                SendKeys.Send("{F1}");
                Fn.Checked = false;
            }
            else if(Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("!");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("1");
            }
        }
        private void q_Click(object sender, EventArgs e)
        {
            if(Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("Q");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }          
            else 
            {
                SendKeys.Send("q");              
            }

        }

        private void Console_Click(object sender, EventArgs e)
        {
           if(Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("{~}");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
           else
            {
                SendKeys.Send("`");
            }
        }

 
        private void Alt1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Alt2_CheckedChanged(object sender, EventArgs e)
        {

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
        }

        private void ScrLk_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{SCROLLLOCK}");
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BREAK}");
        }

        private void PgDn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PGDN}");
        }

        private void PgUp_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PGUP}");
        }

        private void Options_Click(object sender, EventArgs e)
        {

        }

        private void PrtScn_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PRTSC}");
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{INSERT}");
        }

        private void End_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{END}");
        }

        private void Home_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void Del_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DEL}");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BS}");
        }

        private void App_Click(object sender, EventArgs e)
        {

        }

        private void Enter_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void Scars_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("|");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("\\");
            }
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F12}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("{+}");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("=");
            }
        }

        private void CloseBracket_Click(object sender, EventArgs e)
        {
            if(Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("}");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("]");
            }
        }

        private void Dash_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F11}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("_");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("-");
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DOWN}");
        }

        private void Up_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{UP}");
        }

        private void Quotes_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("\"");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("\''");
            }
        }

        private void OpenBracket_Click(object sender, EventArgs e)
        {
            if(Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("{");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("[");
            }
        }

        private void ten_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F10}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("{)}");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("0");
            }
        }

        private void Left_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{Left}");
        }

        private void Question_Click(object sender, EventArgs e)
        {

            if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("?");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("/");
            }
        }

        private void Clon_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send(":");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send(";");
            }
        }

        private void p_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("P");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("p");
            }
        }

        private void nine_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F9}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("{(}");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("9");
            }
        }

        private void Bigger_Click(object sender, EventArgs e)
        {

            if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send(">");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send(".");
            }
        }

        private void l_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("L");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("l");
            }
        }

        private void o_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("O");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("o");
            }
        }

        private void eight_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F8}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("*");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("8");
            }
        }

        private void Smaller_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("<");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send(",");
            }
        }

        private void k_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("K");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("k");
            }
        }

        private void i_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("I");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("i");
            }
        }

        private void seven_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F7}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("&");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("7");
            }
        }

        private void m_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("M");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("m");
            }
        }

        private void j_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("J");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("j");
            }
        }

        private void u_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("U");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("u");
            }
        }

        private void six_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F6}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("{^}");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("6");
            }
        }

        private void n_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("N");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("n");
            }
        }

        private void h_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("H");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("h");
            }
        }

        private void y_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("Y");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("y");
            }
        }

        private void five_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F5}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("{%}");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("5");
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("B");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("b");
            }
        }

        private void g_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("G");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("g");
            }
        }

        private void t_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("T");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("t");
            }
        }

        private void four_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F4}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("$");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("4");
            }
        }

        private void Space_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }

        private void v_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("V");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else if(Ctrl1.Checked || Ctrl2.Checked)
            {
                SendKeys.Send("^v");
                Ctrl1.Checked = false;
                Ctrl2.Checked = false;
            }
            else
            {
                SendKeys.Send("v");
            }
        }

        private void f_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("F");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else if(Ctrl1.Checked || Ctrl2.Checked)
            {
                SendKeys.Send("^(f)");
            }
            else
            {
                SendKeys.Send("f");
            }
        }

        private void r_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("R");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("r");
            }
        }

        private void three_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F3}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("#");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("3");
            }
        }

        private void c_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("C");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else if(Ctrl1.Checked || Ctrl2.Checked)
            {
                SendKeys.Send("^c");
                Ctrl1.Checked = false;
                Ctrl2.Checked = false;
            }
            else
            {
                SendKeys.Send("c");
            }
        }

        private void d_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("D");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else if(Ctrl1.Checked || Ctrl2.Checked)
            {
                SendKeys.Send("^(d)");
                Ctrl1.Checked = false;
                Ctrl2.Checked = false;
            }
            else
            {
                SendKeys.Send("d");
            }
        }

        private void e_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("E");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("e");
            }
        }

        private void two_Click(object sender, EventArgs e)
        {
            if (Fn.Checked)
            {
                SendKeys.Send("{F2}");
                Fn.Checked = false;
            }
            else if (Shift1.Checked || Shift2.Checked)
            {
                SendKeys.Send("@");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("2");
            }
        }

        private void Win_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^({ESC})");
        }

        private void x_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("X");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else if(Ctrl1.Checked || Ctrl2.Checked)
            {
                SendKeys.Send("^x");
                Ctrl1.Checked = false;
                Ctrl2.Checked = false;
            }
            else
            {
                SendKeys.Send("x");
            }
        }

        private void s_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("S");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("s");
            }
        }

        private void w_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("W");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else
            {
                SendKeys.Send("w");
            }
        }

        private void z_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("Z");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else if(Ctrl1.Checked || Ctrl2.Checked)
            {
                SendKeys.Send("^z");
                Ctrl1.Checked = false;
                Ctrl2.Checked = false;
            }
            else
            {
                SendKeys.Send("z");
            }
        }

        private void a_Click(object sender, EventArgs e)
        {
            if (Shift1.Checked || Shift2.Checked || Caps.Checked)
            {
                SendKeys.Send("A");
                Shift1.Checked = false;
                Shift2.Checked = false;
            }
            else if(Ctrl1.Checked || Ctrl2.Checked)
            {
                SendKeys.Send("^a");
                Ctrl1.Checked = false;
                Ctrl2.Checked = false;
            }
            else
            {
                SendKeys.Send("a");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}