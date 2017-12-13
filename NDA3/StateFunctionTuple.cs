using System;
using System.Collections.Generic;

namespace NDA3
{
    public class StateFunctionTuple
    {
        public StateFunctionTuple(State s,
            Func<int, IEnumerable<StateFunctionTuple>, IEnumerable<StateFunctionTuple>> func)
        {
            State = s;
            TransitionFunction = func;
        }

        public State State { get; }
        public Func<int, IEnumerable<StateFunctionTuple>, IEnumerable<StateFunctionTuple>> TransitionFunction { get; }
    }
}