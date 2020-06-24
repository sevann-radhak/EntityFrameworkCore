using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dto
{
    public class SongDto
    {
        public int SongId { get; set; }
        public string Album { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
