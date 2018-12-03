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
            myKeys.Add(this);
        }
        public static string GetSendKey1(Button mybutton)
        {
            return myKeys.Find(keyset => keyset.name == mybutton.Text).sendkey1;
        }
        public static string GetSendKey2(Button mybutton)
        {
            return myKeys.Find(keyset => keyset.name == mybutton.Text).sendkey2;
        }
        public static string GetSendKey3(Button mybutton)
        {
            return myKeys.Find(keyset => keyset.name == mybutton.Text).sendkey3;
        }
    }
}
