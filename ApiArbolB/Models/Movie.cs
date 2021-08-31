using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiArbolB.Models
{
    public class Movie:IComparable
    {
        public string director { get; set; }
        public float imdbRating { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public int rottenTomatoesRating { get; set; }
        public string title { get; set; }

        public int CompareTo(object obj)
        {
            var temp = obj as Movie;

            if (string.Compare(this.title, temp.title) == 0)
            {
                return 0;
            }
            else if (string.Compare(this.title, temp.title) == 1)
            {
                return 1;
            }
            if (string.Compare(this.title, temp.title) == -1)
            {
                return -1;
            }

            return 2;
        }



    }
}
