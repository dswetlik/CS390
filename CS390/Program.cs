﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS390
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StreamReader userDatabase = OpenFile("UserDatabase.txt");

            RegistrationDatabase.Read(userDatabase, RegistrationDatabase.DatabaseType.user);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static StreamReader OpenFile(string fileName)
        {
            try
            {
                StreamReader file = new StreamReader(fileName);

                return file;
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("An error has occurred while trying to open file \"{0}\".", fileName));
            }
        }

    }
}
