﻿using System;
using System.Windows;

namespace CSharp_Pechura02_03.Tools.Managers
{
    internal static class StationManager
    {
        internal static Person CurrentPerson { get; set; }



        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
