﻿using System;
using System.Diagnostics;

namespace Tests.Diagnostics
{
    public class ConditionEvaluatesToConstant
    {
        void Loops(int length)
        {
            if (length > 2)
            {
                for (int i = 0; i < length; i++) // False positive
                {
                    Console.WriteLine();
                }
            }
        }

        void MultipleVarRanges(int i, int j)
        {
            if (i > 0 && i < 40)
            {
                if (j >= 39)
                {
                    if (i == j &&
                        i == 39) // Noncompliant
                    {

                    }
                }
            }
        }

        static void NotEqualsWithNumericConstraints(char ch)
        {
            if (ch < 32 && ch != 9)
            { }
        }

        void Increment()
        {
            var i = 0;
            i++;
            if (i == 1) { }     // Noncompliant
            if (i++ == 1) { }   // Noncompliant
            if (i == 2) { }     // Noncompliant
        }

        void NumericLong(long longValue)
        {
            if (longValue == 1L)
            {
                if (longValue == 1L) { } // Compliant
            }
        }

        void Numeric(int j)
        {
            var i = 42;
            if (i == 42) { } // Noncompliant {{Change this condition so that it does not always evaluate to "true".}}
            if (i != 42) { } // Noncompliant {{Change this condition so that it does not always evaluate to "false".}}

            if (j == 0)
            {
                if (i == j) { } // Noncompliant {{Change this condition so that it does not always evaluate to "false".}}
                if (j == 0) { } // Noncompliant {{Change this condition so that it does not always evaluate to "true".}}
            }

            if (j > 5)
            {
                if (j < 5) { } // Noncompliant {{Change this condition so that it does not always evaluate to "false".}}
            }

            if (j >= 5 && j < 6)
            {
                if (j > 7) { } // Noncompliant {{Change this condition so that it does not always evaluate to "false".}}
            }

            if (j >= 5 && j < 6)
            {
                if (j == 5) { } // Noncompliant {{Change this condition so that it does not always evaluate to "true".}}
            }

            i = GetInt();
            if (i >= 42 && j <= 42 && i == j)
            {
                if (i == 42) { } // Noncompliant {{Change this condition so that it does not always evaluate to "true".}}
                if (j == 42) { } // Noncompliant {{Change this condition so that it does not always evaluate to "true".}}
            }
        }

        int GetInt() { return 12; }
    }
}
