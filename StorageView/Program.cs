﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += Application_ThreadException;
            Application.Run(new MainForm());
        }

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
			new ExceptionForm { Exception = e.Exception }.ShowDialog();
		}
	}
}
