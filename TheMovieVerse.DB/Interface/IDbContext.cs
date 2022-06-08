using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieVerse.DB.Interface
{
    public interface IDbContext
    {
        int SaveChanges();
    }
}
