using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using System.Reflection;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace On_Screen_KeyBoard
{
    static class Program
    {
        //private static readonly ILog logger = LogManager.GetLogger(typeof(Form1).Name);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);   
            
            Application.Run(new Form1());
            
        }
    }
}
