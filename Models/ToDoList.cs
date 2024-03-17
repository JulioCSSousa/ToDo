using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToDo.Models.Enum;

namespace ToDo.Models
{
    public class ToDoList
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }

        public ToDoList() { }

        public ToDoList(int id, DateTime date, string title, string? description, Status status)
        {
            Id = id;
            Date = date;
            Title = title;
            Description = description;
            Status = status;
        }
    }
}
