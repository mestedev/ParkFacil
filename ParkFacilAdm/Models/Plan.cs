namespace ParkFacilAdm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PLAN")]
    public partial class Plan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan()
        {
            Component = new HashSet<Component>();
        }

        public int ID_TIPO_PLAN { get; set; }

        [Key]
        [Display(Name = "ID")]
        public int ID_PLAN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre no puede estar vacío.")]
        [Display(Name = "Nombre")]
        [StringLength(30)]
        public String NOMBRE_PLAN { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(255)]
        public String DESCRIPCION_PLAN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Precio no puede estar vacío.")]
        [Display(Name = "Precio")]
        public decimal PRECIO_PLAN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Precio Máximo Diario no puede estar vacío.")]
        [Display(Name = "Máximo")]
        public int MAXIMO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Cantidad de Minutos Gratis no puede estar vacío.")]
        [Display(Name = "Gratis")]
        public int MINUTOS_GRATIS { get; set; }

        [StringLength(50)]
        public string CREADOR_PLAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Component> Component { get; set; }
    }
}

