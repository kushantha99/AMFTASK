using Postgrest.Attributes;
using Postgrest.Models;

namespace TaskManagerTest.Models
{
    [Table("usertask")]  // Table name in PostgreSQL
    public class UserTask : BaseModel
    {
        [PrimaryKey("id", false)]  // The primary key for the table, "id" is the column name in the table
        public int TaskID { get; set; }

        [Column("title")]  // Column for the task title
        public string Title { get; set; }

        [Column("description")]  // Column for the task description
        public string Description { get; set; }
    }
}
