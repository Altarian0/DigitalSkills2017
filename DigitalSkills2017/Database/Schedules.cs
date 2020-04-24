//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DigitalSkills2017.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedules()
        {
            this.Tickets = new HashSet<Tickets>();
        }
    
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public int AircraftID { get; set; }
        public int RouteID { get; set; }
        public decimal EconomyPrice { get; set; }
        public decimal EconomyPrices { get; set; }
        public decimal BusinessPrice { get; set; }
        public decimal FirstClassPrice { get; set; }
        public bool Confirmed { get; set; }
        public string FlightNumber { get; set; }
        public int NumberOfStops = 0;
        public string Fullname
        {
            get
            {
                return $"{FlightNumber}, {Routes.Airports.IATACode}-{Routes.Airports1.IATACode}, {Date.ToString("dd.MM.yyyy")}, {Time}";
            }
        }
        public virtual Aircrafts Aircrafts { get; set; }
        public virtual Routes Routes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}