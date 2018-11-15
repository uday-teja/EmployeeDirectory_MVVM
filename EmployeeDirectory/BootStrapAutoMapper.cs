using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiModel = EmployeeDirectory.Models.Model;
using EmployeeDirectory.Data.Model;

namespace EmployeeDirectory
{
    public class BootStrapAutoMapper
    {
        /// <summary>
        /// Initializing Mapper for UI Model and Database Model
        /// </summary>
        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<UiModel.Employee, Employee>();
                x.CreateMap<Employee, UiModel.Employee>();
            });
        }
    }
}