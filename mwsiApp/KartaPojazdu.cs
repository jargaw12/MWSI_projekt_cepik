//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mwsiApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class KartaPojazdu
    {
        public int idKartyPojazdu { get; set; }
        public string VIN { get; set; }
        public int idTypNadwozia { get; set; }
        public Nullable<int> idMarka { get; set; }
        public Nullable<int> idModel { get; set; }
        public int idRodzajPaliwa { get; set; }
        public Nullable<System.DateTime> dataWydaniaKartyPojazdu { get; set; }
        public Nullable<System.DateTime> dataPierwszejRejestracji { get; set; }
        public Nullable<int> pojemnosc { get; set; }
        public Nullable<double> mocSilnika { get; set; }
        public Nullable<int> liczbaMiejsc { get; set; }
        public Nullable<int> srZuzyciePaliwa { get; set; }
        public Nullable<int> masaWlasna { get; set; }
        public Nullable<int> ladownosc { get; set; }
        public Nullable<bool> wydano { get; set; }
    }
}
