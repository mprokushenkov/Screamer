using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bstm.Functional
{
    public static class Idioms
    {
        public static T Id<T>(T subject) => subject;
    }
}
