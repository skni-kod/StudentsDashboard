﻿
namespace StudentsDashboard.Domain.Entities
{
    public class WorkTask
    {
        public int Id { get; set; }
        public int Id_Customer { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public DateTime Date { get; set; }
    }
}
