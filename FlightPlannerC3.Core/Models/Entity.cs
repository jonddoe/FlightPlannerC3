using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightPlannerC3.Core.Models
{
    public abstract class Entity
    {
        [Key]
         public int Id { get; set; }
    }
}