using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.DTO;
public class ItemEntityForUpdatesDto
{
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
}
