using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace On_Screen_KeyBoard
{
    public class KeyValueNewSet
    {
        public static List<KeyValueNewSet> myKeys = new List<KeyValueNewSet>();
        string name;
        string sendkey1;
        string sendkey2;
        string sendkey3;
        public KeyValueNewSet(string name, string sendkey1, string sendkey2, string sendkey3)
        {
            this.name = name;
            this.sendkey1 = sendkey1;
            this.sendkey2 = sendkey2;
            this.sendkey3 = sendkey3;
            myKeys.Add(this); // Tự đăng ký bản thân và danh sách
        }
        /// <summary>
        /// Hàm trả về chuỗi SendKey1 là khi ấn Button bình thường
        /// </summary>
        /// <param name="mybutton">Button cần lấy giá trị SendKey tương ứng</param>
        /// <returns></returns>
        public static string GetSendKey1(Button mybutton)
        {
            return myKeys.Find(keyset => keyset.name == mybutton.Name).sendkey1;
        }
        /// <summary>
        /// Hàm trả về chuỗi SendKey2 là khi ấn phím Shift
        /// </summary>
        /// <param name="mybutton"></param>
        /// <returns></returns>
        public static string GetSendKey2(Button mybutton)
        {
            return myKeys.Find(keyset => keyset.name == mybutton.Name).sendkey2;
        }
        /// <summary>
        /// Hàm trả về chuỗi Sendskey4 là khi ấn Fn, dùng cho các phím chức năng F1 -> F12
        /// </summary>
        /// <param name="mybutton"></param>
        /// <returns></returns>
        public static string GetSendKey3(Button mybutton)
        {
            return myKeys.Find(keyset => keyset.name == mybutton.Name).sendkey3;
        }
    }
}
