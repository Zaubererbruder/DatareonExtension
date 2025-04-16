using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramModules.Tests.Models
{
    public static class EqualsHelper
    {
        public static bool Equals<T>(T value1, T Value2)
        {
            return EqualityComparer<T>.Default.Equals(value1, Value2);
        }
    }
}
