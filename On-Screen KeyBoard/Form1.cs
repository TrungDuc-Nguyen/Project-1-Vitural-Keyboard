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
        #region code tìm và active windows
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
        #endregion
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
            new KeyValueNewSet("Esc", "{ESC}", "{ESC}", "{ESC}");
            new KeyValueNewSet("`", "`", "~", "`");
            new KeyValueNewSet("1", "1", "!", "{F1}");
            new KeyValueNewSet("2", "2", "@", "{F2}");
            new KeyValueNewSet("3", "3", "#", "{F3}");
            new KeyValueNewSet("4", "4", "{$}", "{F4}");
            new KeyValueNewSet("5", "5", "{%}", "{F5}");
            new KeyValueNewSet("6", "6", "{^}", "{F6}");
            new KeyValueNewSet("7", "7", "&", "{F7}");
            new KeyValueNewSet("8", "8", "*", "{F8}");
            new KeyValueNewSet("9", "9", "{(}", "{F9}");
            new KeyValueNewSet("0", "0", "{)}", "{F10}");
            new KeyValueNewSet("-", "-", "_", "{F11}");
            new KeyValueNewSet("=", "=", "{+}", "{F12}");
            new KeyValueNewSet("Back", "{BS}", "{BS}", "{BS}");
            new KeyValueNewSet("Tab", "{TAB}", "{TAB}", "{TAB}");
            new KeyValueNewSet("q", "q", "Q", "Q");
            new KeyValueNewSet("w", "w", "W", "W");
            new KeyValueNewSet("e", "e", "E", "E");
            new KeyValueNewSet("r", "r", "R", "R");
            new KeyValueNewSet("t", "t", "T", "T");
            new KeyValueNewSet("y", "y", "Y", "Y");
            new KeyValueNewSet("u", "u", "U", "U");
            new KeyValueNewSet("i", "i", "I", "I");
            new KeyValueNewSet("o", "o", "O", "O");
            new KeyValueNewSet("p", "p", "P", "P");
            new KeyValueNewSet("[", "[", "{", "[");
            new KeyValueNewSet("]", "]", "}", "]");
            new KeyValueNewSet("\\", "\\", "|", "\\" );
            new KeyValueNewSet("Del", "{DEL}", "{DEL}", "{DEL}");
            new KeyValueNewSet("Caps", "{CAPSLOCK}", "{CAPSLOCK}", "{CAPSLOCK}");
            new KeyValueNewSet("a", "a", "A", "A");
            new KeyValueNewSet("s", "s", "S", "S");
            new KeyValueNewSet("d", "d", "D", "D");
            new KeyValueNewSet("f", "f", "F", "F");
            new KeyValueNewSet("g", "g", "G", "G");
            new KeyValueNewSet("h", "h", "H", "H");
            new KeyValueNewSet("j", "j", "J", "J");
            new KeyValueNewSet("k", "k", "K", "K");
            new KeyValueNewSet("l", "l", "L", "L");
            new KeyValueNewSet(";", ";", ":", ";");
            new KeyValueNewSet("\'", "\'", "\"", "\'");
            new KeyValueNewSet("Enter", "{ENTER}", "{ENTER}", "{ENTER}");
            new KeyValueNewSet("Shift", "+", "+", "+");
            new KeyValueNewSet("z", "z", "Z", "Z");
            new KeyValueNewSet("x", "x", "X", "X");
            new KeyValueNewSet("c", "c", "C", "C");
            new KeyValueNewSet("v", "v", "V", "V");
            new KeyValueNewSet("b", "b", "B", "B");
            new KeyValueNewSet("n", "n", "N", "N");
            new KeyValueNewSet("m", "m", "M", "M");
            new KeyValueNewSet(",", ",", "<", ",");
            new KeyValueNewSet(".", ".", ">", ".");
            new KeyValueNewSet("/", "/", "?", "/");
            new KeyValueNewSet("Ctrl", "^", "^", "^");
            new KeyValueNewSet("Win", "^({ESC})", "^({ESC})", "^({ESC})");
            new KeyValueNewSet("Alt", "%", "%", "%");
            new KeyValueNewSet("Space", " ", " ", " ");
            new KeyValueNewSet("←", "{LEFT}", "{LEFT}", "{LEFT}");
            new KeyValueNewSet("↓", "{DOWN}", "{DOWN}", "{DOWN}");
            new KeyValueNewSet("→", "{RIGHT}", "{RIGHT}", "{RIGHT}");
            new KeyValueNewSet("↑", "{UP}", "{UP}", "{UP}");

#endregion
        }
       
        /// <summary>
        /// Hàm xử lý sự kiện khi nhấn button bắt kỳ
        /// </summary>
        /// <param name="sender">Lấy text của button vừa nhấn</param>
        /// <param name="e"></param>
        void Any_Click(object sender, EventArgs e)
        {           
            Button btn = sender as Button;  // Gán 1 button bất kì vừa nhấn cho biến btn
            string btn_sendkey1 = KeyValueNewSet.GetSendKey1(btn); // Gán giá trị SendKey1 cho biến btn_sendkey1
            string btn_sendkey2 = KeyValueNewSet.GetSendKey2(btn); // Gán giá trị SendKey2 cho biến btn_sendkey2
            string btn_sendkey3 = KeyValueNewSet.GetSendKey3(btn); // Gán giá trị SendKey3 cho biến btn_sendkey3

            if (btn != null)
            {
                SendKeys.Send(btn_sendkey1);
            }

#region code gửi phím cũ
            /*int TagOfbtn = Convert.ToInt32(btn.Tag);   // Chuyển properties của button sang kiểu int
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
            }        */
#endregion
        }

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
        #endregion

        /// <summary>
        /// các hàm bool dùng để xử lý sự kiện với các phím Shift, Capslock, Fn
        /// </summary>
        bool Fn_Button = false;
    }
}
