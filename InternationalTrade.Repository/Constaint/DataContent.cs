using InternationalTrade.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Repository.Constaint
{
    public partial class DataContent : DbContext
    {
        public DataContent()
            : base("DataBase")
        {

        }
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<Embassy> Embassy { get; set; }
        public DbSet<Examine> Examine { get; set; }
        public DbSet<Trade> Trade { get; set; }
        public DbSet<TradeExamine> TradeExamine { get; set; }
        public DbSet<Visa> Visa { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}
