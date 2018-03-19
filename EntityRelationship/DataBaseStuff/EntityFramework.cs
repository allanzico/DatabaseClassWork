using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataBaseStuff
{
    class EntityFramework
    {
        
        public void insertData()
        {
            Stopwatch timer = new Stopwatch();
            using (var db = new Netflix())
            {
                
                var name = "movie";
                var age = 14;
                var rating = 5;
                timer.Start();
                for ( int i = 0; i < 10000; i++)
                {
                    var movie = new MovieList { MovieKey = i, MovieName = name, MinAge = age, Rating = rating };
                    db.MovieLists.Add(movie);
                    db.SaveChanges();    
                }
                timer.Stop();
            }

            Console.WriteLine("done inserting in {0}", timer.ElapsedMilliseconds);
            timer.Reset();
        }
        public void updateData()
        {
            Stopwatch timer = new Stopwatch();
            using (var db = new Netflix())
            {
                int movies = db.MovieLists.Max(n => n.MovieKey);

                timer.Start();
                for (int i = 0; i <= movies; i++)
                {
                    var name = db.MovieLists.Find(i);
                    try
                    {
                        name.MovieName = "newMovie";
                    }
                    catch(Exception e)
                    {
                        
                    }
                   
                    db.SaveChanges();

                }
                timer.Stop();
                
            }
            Console.WriteLine("done updating in {0}", timer.ElapsedMilliseconds);
            timer.Reset();
        }
        public void deleteData()
        {
            Stopwatch timer = new Stopwatch();
            using (var db = new Netflix())
            {

                int movies = db.MovieLists.Max(n => n.MovieKey);

                timer.Start();
                for (int i = 0; i <= movies; i++)
                {
                    var name = db.MovieLists.Find(i);
                    try
                    {
                        db.MovieLists.Remove(name);
                    }
                    catch(Exception e)
                    {
                        
                    }
                   
                    db.SaveChanges();

                }
                timer.Stop();

            }
            Console.WriteLine("deleted in {0}", timer.ElapsedMilliseconds);
        }
    }
}
