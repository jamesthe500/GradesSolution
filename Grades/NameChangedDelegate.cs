using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // here is delegate. It doesn't do anything itself, it just know what needs to be published, two strings in this case. 
    //public delegate void NameChangedDelegate(string existingName, string newName);

    // .NET convention for events. Always 2 args. 1 is the name of the event, 2 is an object containing all arguments or info.
    // a custom class is needed.
    // The parameter that passes along the arguments for the event's TYPE will always end in "EventArgs"
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args); // object type allows anything to be passed this is another convention


}
