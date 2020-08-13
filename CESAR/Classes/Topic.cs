using System;
using System.Collections.Generic;
using System.Text;

namespace CESAR.Classes
{
    public class Topic
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public string Category { get; set; }
        public bool IsLocked { get; set; }
    }
}
