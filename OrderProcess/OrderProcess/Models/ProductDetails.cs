using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcess.Models
{
    public class Product
    {
        public ProductType ProductType;
        public DateTime  ProcessingDateTime;
        public string Name;

        public Product(string id)
        {
            if (id =="0")
            {
                ProductType = ProductType.Physical;
                Name = "Physical";
            }
            else if (id == "1")
            {
                ProductType = ProductType.Book;
                Name = "Book";
            }
            else if (id == "2")
            {
                ProductType = ProductType.Membership;
                Name = "Membership";
            }
            else if (id == "3")
            {
                ProductType = ProductType.MembershipUpgrade;
                Name = "MembershipUpgrade";
            }
            else if (id == "4")
            {
                ProductType = ProductType.Video;
                Name = "Video";
            } 
        }
    }

    /// <summary>
    /// Classification is made with assumption to keep it simple else books is also a physical
    /// </summary>
    public enum ProductType
    {
        Physical,
        Membership,
        MembershipUpgrade,
        Book,
        Video
    }
}