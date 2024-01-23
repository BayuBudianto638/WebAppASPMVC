using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebAppASPMVC.Helpers;

namespace WebAppASPMVC.Services
{
    public class GenerateCsvService<T>
    {
        public byte[] ExportToCsv(List<T> data)
        {
            var csvData = HelperService.WriteCsv(data);
            return Encoding.UTF8.GetBytes(csvData);
        }
    }
}