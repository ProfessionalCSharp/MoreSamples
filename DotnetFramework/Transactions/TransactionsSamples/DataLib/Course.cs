using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Transactions
{
    [Serializable]
    public class Course
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
    }
}
