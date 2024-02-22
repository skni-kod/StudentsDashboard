
namespace StudentsDashboard.Domain.Entities
{
    public class WorkTask
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
