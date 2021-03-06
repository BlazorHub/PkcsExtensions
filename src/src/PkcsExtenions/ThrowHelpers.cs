﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PkcsExtenions
{
    internal static class ThrowHelpers
    {
        public static void NotImplemented(string className, [CallerMemberName] string methodName = null)
        {
            throw new NotImplementedException($"{className}.{methodName} is not implement in this version PkcsExtenions.");
        }

        public static void CheckRange(string parameter1Name, int parameter1, string parameter2Name, int parameter2)
        {
            if (parameter1 >= parameter2)
            {
                throw new ArgumentOutOfRangeException($"Argument {parameter1Name} mus by less than argument {parameter2Name}.");
            }
        }

        public static void CheckNullOrEempty(string name, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Argument {name} is empty string.");
            }
        }

        public static void CheckNull(string name, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
