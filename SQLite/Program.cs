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
            //Add record
            using (var db = new MyDBContext())
            {
                db.Templetes.Add(new Templete { Name = "Test111" });
                db.Templetes.Add(new Templete { Name = "Test11" });
                db.SaveChanges();
            }
            //delete record from id
                using (var db = new MyDBContext())
                {
                 var del = db.Templetes.SingleOrDefault(x => x.Id == 1);
                 if (del != null)
                 {
                     db.Templetes.Remove(del);
                     db.SaveChanges();
                 }
            }
            //Writing
                using (var db = new MyDBContext())
                {
                    foreach (var templete in db.Templetes)
                    {
                        Console.WriteLine("Template {0} = {1}", templete.Id, templete.Name);
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
