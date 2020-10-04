using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderProcess.Models;

namespace OrderProcess.Intefaces
{
    public interface IPostprocessingRule
    {
        bool IsApplicable(Product product);
        string[] Execute();
    }
     
}