using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13e_250115_xy
{
    public class ArtistCategories
    {
        public List<Artist> csicska = new List<Artist>();
        public List<Artist> basic = new List<Artist>();
        public List<Artist> goat = new List<Artist>();

        public void Add(Artist artist)
        {
            if(Enumerable.Range(0, 200).Contains((int)artist.Stats.Sales))
            {
                this.csicska.Add(artist);
                return;
            }
            if(Enumerable.Range(200, 400 -200).Contains((int)artist.Stats.Sales))
            {
                this.basic.Add(artist);
                return;
            }
            if(Enumerable.Range(400, int.MaxValue -400).Contains((int)artist.Stats.Sales))
            {
                this.goat.Add(artist);
                return;
            }

            throw new Exception("lol");
        } 
    }
    public class ArtistStats 
    {
        public double Albums;
        public double Sales;
        public double Awards;
    }
    // nevezd át az osztályt
    public class Artist
    {
        public string Name {  get; set; }
        public string Publisher {  get; set; }
        public ArtistStats Stats { get; set; }
        public string Release {  get; set; }
        
        // a csv fájl alapján vedd fel az osztály attribútumait (2p)
        public Artist(string line)
        {
            // inicializáld az objektumot a "line" string feldolgozásával! (2p)
            string[] tokens = line.Split(';');

            this.Name = tokens[0];
            this.Publisher = tokens[1];
            this.Release = tokens[3];

            var numbers = tokens[2].
                Trim(new char[] { '{', '}' }).
                Split(',').
                Select(e => double.Parse(e)).
                ToList();
            this.Stats = new ArtistStats()
            {
                Albums = numbers[0],
                Sales = numbers[1],
                Awards = numbers[2]
            };
        }
        public static List<Artist> InsertionSort(List<Artist> list, Func<Artist, double> selector)
        {
            var result = new List<Artist>();

            int i;
            foreach (var artist in list) 
            {
                for(i = 1; i <= result.Count(); i++)
                {
                    if (selector(result[i-1]) < selector(artist))
                    {
                        result.Insert(i-1, artist);
                        break;
                    }
                }
                
                if(i >= result.Count())
                {
                    result.Add(artist);
                }
            }

            return result;
        }
    }
}
