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
    
    public partial class Uzytkownik
    {
        public string PESEL { get; set; }
        public string login { get; set; }
        public string haslo { get; set; }
        public string imie { get; set; }
        public string imie2 { get; set; }
        public string nazwisko { get; set; }
        public string telefon { get; set; }
        public Nullable<System.DateTime> dataUrodzenia { get; set; }
        public Nullable<int> idWojewodztwo { get; set; }
        public Nullable<int> idPowiat { get; set; }
        public Nullable<int> idMiejscowosc { get; set; }
        public string ulica { get; set; }
        public Nullable<int> nrDomu { get; set; }
        public Nullable<int> nrLokalu { get; set; }
        public string miejsceUrodzenia { get; set; }
    }
}
