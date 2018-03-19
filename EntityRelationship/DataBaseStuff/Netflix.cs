namespace DataBaseStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class Netflix : DbContext
    {

        public Netflix()
            : base("name=Netflix")
        {
        }

        public virtual DbSet<MovieList> MovieLists { get; set; }
  
    }


}