using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constanse
{
    public static class Messages
    {
        // Car
        public static string CarAdded = "Araba Eklendi.";
        public static string CarDeleted = "Araba Silindi.";
        public static string CarUpdated = "Araba Güncellendi.";
        public static string GetCar = "Araba Getirildi.";
        public static string GetAllCar = "Tüm Arabalar Getirildi";

        // Brand
        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted = "Marka Silindi.";
        public static string BrandUpdated = "Marka Güncellendi.";
        public static string GetBrand = "Marka Getirildi.";
        public static string GetAllBrand = "Tüm Markalar Getirildi";

        // Color
        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorDeleted = "Renk Silindi.";
        public static string ColorUpdated = "Renk Güncellendi.";
        public static string GetColor = "Renk Getirildi.";
        public static string GetAllColor = "Tüm Renkler Getirildi";
    }
}