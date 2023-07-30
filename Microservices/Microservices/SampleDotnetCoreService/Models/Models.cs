using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleDotnetCoreService.Models
{
    [Table("tblTrainee", Schema ="dbo")]
    public class Trainee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TraineeId")]
        public int Id { get; set; }
        [Column("traineeName")]
        public string TraineeName { get; set; } = string.Empty;
        [Column("emailAddress")]
        public string EmailAddress { get; set; } = string.Empty;
        [Column("contactno")]
        public long MobileNo { get; set; }
    }

    public class TraineeDbContext : DbContext
    {
        public TraineeDbContext(DbContextOptions<TraineeDbContext> dbOptions) : base(dbOptions)
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(dbCreator != null)
                {
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    if (!dbCreator.HasTables()) dbCreator.CreateTables();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }

        public DbSet<Trainee> Trainees { get; set; }
    }
}
