using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProjectEntity
    {
        public int Id { get; set; }

        public string ProjectName { get; set; } = null!;

        public string ClientName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Budget { get; set; }

        public string Status { get; set; } = null!;
    }
}
