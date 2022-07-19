using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Models.Siniflarim
{
    public class Class1
    {
        public IEnumerable<TBLKitap> KitapDeger { get; set; }
        public IEnumerable<TBLHakkimizda> HakkimizdaDeger { get; set; }
    }
}