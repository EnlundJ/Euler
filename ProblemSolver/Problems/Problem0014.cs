﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EulerDb.Entities;
using EulerHelper;

namespace ProblemSolver.Problems
{
    /// <summary>
    ///  <p>The following iterative sequence is defined for the set of positive integers:</p>
    ///  <p class="margin_left"><var>n</var> → <var>n</var>/2 (<var>n</var> is even)<br /><var>n</var> → 3<var>n</var> + 1 (<var>n</var> is odd)</p>
    ///  <p>Using the rule above and starting with 13, we generate the following sequence:</p>
    ///  <div class="center">13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1</div>
    ///  <p>It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.</p>
    ///  <p>Which starting number, under one million, produces the longest chain?</p>
    ///  <p class="note"><b>NOTE:</b> Once the chain starts the terms are allowed to go above one million.</p>
    /// </summary>
    public class Problem0014 : IProblem
    {
        public bool IsSelfContained => false;

        public Task<string> Run(Test test)
        {
            Problem0014Config config = test.GetParameters<Problem0014Config>();

            Dictionary<long, List<long>> results = new();
            for (long i = config.MinStart; i <= config.MaxStart; i++)
            {
                long count = 1;
                long current = i;
                while (current != 1)
                {
                    current = Miscellaneous.NextCollatz(current);
                    count++;
                }
                if (!results.ContainsKey(count))
                    results[count] = new List<long>() { i };
                else
                    results[count].Add(i);
            }
            return Task.FromResult(results[results.Keys.Max()].First().ToString());
        }
    }

    public class Problem0014Config : IProblemParameters
    {
        public long MinStart { get; set; }
        public long MaxStart { get; set; }
    }
}
