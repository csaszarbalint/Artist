using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace _13e_250115_xy
{
    class Program
    {
        static List<Artist> _instances = null;
        static void Main(string[] args)
        {
            // Olvasd be a csv fájlt (2p)
            // Töltsd fel a _instances listát a MyClass osztály példányaiból (2p)
            _instances = new List<Artist>(); 
            foreach(string line in File.ReadAllLines("artists.csv").Skip(1))
            {
                _instances.Add(new Artist(line));
            }

            // Oldd meg a feladatok.txt pontjait LINQ kifejezésekkel! (8p)

            { //5.
                Console.WriteLine(_instances
                    .OrderByDescending(artist => artist.Stats.Albums)
                    .First()
                    .Name
                );
            }
            
            { //6.
                Console.WriteLine(_instances
                    .Average(artist => artist.Stats.Sales)
                );
            }

            { //7.
                ArtistCategories ac = new ArtistCategories();
                _instances.ForEach(artist => ac.Add(artist));
            }
            
            { //8.
                var result = Artist.InsertionSort(_instances, a => a.Stats.Sales / a.Stats.Albums);
            }
        }
    }
}
