using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;
using System.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDBContext())
            {
                db.Templetes.Add(new Templete { Name = "Test" });
                db.SaveChanges();
            }
            using (var db = new MyDBContext())
            {
                foreach (var note in db.Templetes)
                {
                    Console.WriteLine("Template {0} = {1}", note.Id, note.Name);
                }
            }
            Console.ReadKey();
        }
        public class Templete
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
         public class MyDBContext : DbContext
         {
             public MyDBContext() : base("MyDBContext")
             {
             }
             public DbSet<Templete> Templetes { get; set; }
         }
    }
}
