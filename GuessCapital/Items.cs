using System;
using System.Collections.Generic;

namespace GuessCapital
{
    public class Capital
    {
        public class Region
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }

        public class Europe
        {
            public string Name { get; set; }  //name of nation 
            public string CapitalCity { get; set; } //capital city
            public Region Region { get; set; } //region id
            public string Iso2code { get; set; }
        }

        public class World
        {
            public string Name { get; set; }  //name of nation 
            public string CapitalCity { get; set; } //capital city
            public Region Region { get; set; } //region id
            public string Iso2code { get; set; }
        }
    }

}