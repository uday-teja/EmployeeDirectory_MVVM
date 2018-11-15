﻿using EmployeeDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeDirectory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindowViewModel MainWindowInstance { get; set; }

        public App()
        {
            BootStrapAutoMapper.InitializeAutoMapper();
        }
    }
}