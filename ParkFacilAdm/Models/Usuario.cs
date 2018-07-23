namespace ParkFacilAdm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class Usuario
    {
       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        
        public Usuario()
        {
            Component = new HashSet<Component>();
        }

        public int ID_EMPRESA { get; set; }

        public int ID_TIPO_USUARIO { get; set; }

        [Key]
        [Display(Name = "ID")]
        public int ID_USUARIO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre no puede estar vacio.")]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public String NOMBRE_USUARIO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Los Apellidos no pueden estar vacios.")]
        [Display(Name = "Apellidos")]
        [StringLength(50)]
        public String APELLIDO_USUARIO { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$", ErrorMessage = "No es un email válido.")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public String MAIL_USUARIO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Usuario no puede estar vacio.")]
        [Display(Name = "Usuario")]
        [StringLength(30)]
        public String USUARIO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Password no puede estar vacia.")]
        [Display(Name = "Password")]
        [StringLength(50)]
        public String PASSWORD { get; set; }

        [Display(Name = "Estado")]
        public int ESTADO_USUARIO { get; set; }

        [Display(Name = "Creado")]
        public DateTime? FECHA_INGRESO_USUARIO { get; set; }

        [Display(Name = "Eliminado")]
        public DateTime? FECHA_TERMINO_USUARIO { get; set; }

        [Display(Name = "RUT")]
        [StringLength(15)]
        public string RUT_USUARIO { get; set; }

        [StringLength(50)]
        public string CREADOR_USUARIO { get; set; }

        [StringLength(50)]
        public string ID_USUARIO_OUT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Component> Component { get; set; }
    }
}
