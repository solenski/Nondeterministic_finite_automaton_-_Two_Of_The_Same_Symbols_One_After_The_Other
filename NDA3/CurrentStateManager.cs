using System.Collections.Generic;
using System.Linq;

namespace NDA3
{
    public class CurrentStateManager
    {
        private readonly HashSet<StateFunctionTuple> stateDefinitions = new HashSet<StateFunctionTuple>
        {
            new StateFunctionTuple(
                State.Q0,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        statdefs.First(x => x.State == State.Q0),
                        statdefs.First(x => (int) x.State == symbol + 1)
                    }),
            new StateFunctionTuple(
                State.Q1,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q1
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q2,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q2
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q3,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q3
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q4,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q4
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q5,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q5
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q6,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q6
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q7,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q7
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q8,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q8
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q9,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q9
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q10,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        symbol + 1 == (int) State.Q10
                            ? statdefs.First(x => x.State == State.Q11)
                            : statdefs.First(x => x.State == State.Q0)
                    }),
            new StateFunctionTuple(
                State.Q11,
                (symbol, statdefs) =>
                    new List<StateFunctionTuple>
                    {
                        statdefs.First(x => x.State == State.Q11)
                    })
        };


        public HashSet<StateFunctionTuple> CurrentStates { get; private set; } = new HashSet<StateFunctionTuple>();

        public CurrentStateManager()
        {
            this.CurrentStates.Add(this.stateDefinitions.First(x => x.State == State.Q0));
        }

        public void ExecuteSymbol(int symbol)
        {
            CurrentStates = new HashSet<StateFunctionTuple>(
                CurrentStates.SelectMany(
                    x => x.TransitionFunction(symbol, stateDefinitions)));
        }
    }
}