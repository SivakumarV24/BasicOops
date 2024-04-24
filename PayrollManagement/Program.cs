using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using PayrollManagement;
namespace StudentAdmission
{
    class Program
    {
        public static void Main(string[] args)
        {
        //Add Default value
        Operations.AddDefaultValue();
        //Show MAinMenu
        Operations.MainMenu();
        }
    }

}