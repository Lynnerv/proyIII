using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyIII.Models
{
    [Table("t_contacto")]
    public class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Clave primaria autoincrementable

        [Required]  // Hace que el campo sea obligatorio
        public string Name { get; set; }  // Nombre del contacto

        [Required]
        [EmailAddress]  // Valida que el email esté en el formato correcto
        public string Email { get; set; }  // Correo electrónico

        [Required]
        public string Message { get; set; }  // Mensaje del contacto

        [DataType(DataType.DateTime)]  // Valida que sea una fecha
        public DateTime Date { get; set; } = DateTime.UtcNow;  // Utiliza UTC por defecto


        public string? Phone { get; set; }  // Teléfono del contacto, opcional

        public string? Subject { get; set; }  // Asunto del mensaje, opcional

        public string? IPAddress { get; set; }  // Dirección IP desde donde se envió el mensaje, opcional

        public string? Status { get; set; }  // Estado del contacto (pendiente, respondido, etc.), opcional
    }
}

