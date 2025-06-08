using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace ToDoH.Models.Todos
{
    public class TodoItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public string Title { get; set; }

        public bool Completed { get; set; }

        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }  
    }
}
