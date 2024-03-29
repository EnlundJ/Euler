﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EulerDb.Entities;
using EulerHelper;

namespace ProblemSolver.Problems
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    public class Problem0004 : IProblem
    {
        public bool IsSelfContained => false;

        public Task<string> Run(Test test)
        {
            Problem0004Config config = test.GetParameters<Problem0004Config>();

            List<long> result = new();
            for (int i = (int)Math.Pow(10, config.Digits - 1); i < Math.Pow(10, config.Digits); i++)
                for (int j = (int)Math.Pow(10, config.Digits - 1); j < Math.Pow(10, config.Digits); j++)
                    if (Miscellaneous.IsPalindrome((i * j).ToString()))
                        result.Add(i * j);

            return Task.FromResult(result.Max().ToString());
        }
    }

    public class Problem0004Config : IProblemParameters
    {
        public int Digits { get; set; }
    }
}
