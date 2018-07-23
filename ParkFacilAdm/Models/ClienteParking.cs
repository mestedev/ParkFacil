namespace ParkFacilAdm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENTE_PARKING")]
    public partial class ClienteParking
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClienteParking()
        {
            Component = new HashSet<Component>();
        }

        public int ID_ESTADO_CLIENTE { get; set; }


        public int ID_EMPRESA { get; set; }

 
        public int ID_PARKING { get; set; }

        public int ID_TIPO_CLIENTE { get; set; }

        [Key]
        public int ID_CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Component> Component { get; set; }
    }
}