namespace ParkFacilAdm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENTE")]
    public partial class Cliente
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]


        public Cliente()
        {
            Component = new HashSet<Component>();
        }

        public int ID_ESTADO_CLIENTE { get; set; }

        public int ID_TIPO_CLIENTE { get; set; }

        [Key]
        [Display(Name = "ID")]
        public int ID_CLIENTE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre no puede estar vacio.")]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public String NOMBRE_CLIENTE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Los Apellidos no pueden estar vacios.")]
        [Display(Name = "Apellidos")]
        [StringLength(50)]
        public String APELLIDO_CLIENTE { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$", ErrorMessage = "No es un email válido.")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public String MAIL_CLIENTE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Patente no puede estar vacía.")]
        [Display(Name = "Patente")]
        [StringLength(30)]
        public String PATENTE_CLIENTE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Teléfono no puede estar vacío.")]
        [Display(Name = "Telefono")]
        [StringLength(20)]
        public String TELEFONO_CLIENTE { get; set; }

        [Display(Name = "Creado")]
        public DateTime? FECHA_INGRESO_CLIENTE { get; set; }

        [Display(Name = "Eliminado")]
        public DateTime? FECHA_TERMINO_CLIENTE { get; set; }

        [Display(Name = "RUT")]
        [StringLength(15)]
        public string RUT_CLIENTE { get; set; }

        [StringLength(50)]
        public string CREADOR_CLIENTE { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "La Vigencia no puede estar vacía.")]
        public int VIGENCIA_CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Component> Component { get; set; }

    }
}
