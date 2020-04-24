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
    
    public partial class Tickets : ICloneable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tickets()
        {
            this.AmenitiesTickets = new HashSet<AmenitiesTickets>();
        }
    
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ScheduleID { get; set; }
        public int CabinTypeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string PassportNumber { get; set; }
        public int PassportCountryID { get; set; }
        public string BookingReference { get; set; }
        public bool Confirmed { get; set; }
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AmenitiesTickets> AmenitiesTickets { get; set; }
        public virtual CabinTypes CabinTypes { get; set; }
        public virtual Schedules Schedules { get; set; }
        public virtual Users Users { get; set; }

        public object Clone()
        {
            return this;
        }
    }
}
