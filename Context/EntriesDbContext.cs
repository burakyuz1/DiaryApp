using DiaryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Context
{
    internal class EntriesDbContext: DbContext
    {
        public EntriesDbContext(): base("server = . ; database = MyDiaryApp ; integrated security = true")
        {

        }
        public DbSet<Entry> Entries { get; set; }

    }
}
