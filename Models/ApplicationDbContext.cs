using Microsoft.EntityFrameworkCore;

 namespace ProjectApi.Models
 {
     public class ApplicationDbContext : DbContext
     {

        public DbSet<Person> Persons {get;set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        } 
       
     }
 }