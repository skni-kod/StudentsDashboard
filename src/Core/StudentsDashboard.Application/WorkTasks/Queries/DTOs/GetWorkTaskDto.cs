using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDashboard.Application.WorkTasks.Queries.DTOs
{
    public class GetWorkTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date{ get; set; }
    }
}
