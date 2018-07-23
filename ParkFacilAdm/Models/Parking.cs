namespace ParkFacilAdm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PARKING")]
    public partial class Parking
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parking()
        {
            Component = new HashSet<Component>();
        }

        public int ID_EMPRESA { get; set; }

        [Key]
        [Display(Name = "ID")]
        public int ID_PARKING { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre no puede estar vacio.")]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        public String NOMBRE_PARK { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Dirección no puede estar vacía.")]
        [Display(Name = "Direccion")]
        [StringLength(255)]
        public String DIRECCION_PARK { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Comuna no pueden estar vacía.")]
        [Display(Name = "Comuna")]
        [StringLength(50)]
        public String COMUNA_PARK { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Región no puede estar vacía.")]
        [Display(Name = "Región")]
        [StringLength(50)]
        public String REGION_PARK { get; set; }

        [Display(Name = "# estacionamientos")]
        public decimal CANTIDAD_PARK { get; set; }


        [StringLength(50)]
        public string CREADOR_PARK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Component> Component { get; set; }
    }
}

