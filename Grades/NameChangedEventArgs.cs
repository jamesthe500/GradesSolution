using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class NameChangedEventArgs : EventArgs // Setting up inheritance from base class of .NET fw
    {
        // snippet prop tab tab = properties 
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
}
