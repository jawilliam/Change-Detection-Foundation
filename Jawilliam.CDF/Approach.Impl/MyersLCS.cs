using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Impl
{
    /// <summary>
    /// Implements Longest Common Subsequence and Shorter Edit Script algorithm ("An O(ND) Difference Algorithm and Its Variations").
    /// </summary>
    /// <typeparam name="TSymbol">Type of the symbols.</typeparam>
    public class MyersLCS<TSymbol>
    {
        /// <summary>
        /// Stores the values of the <see cref="Equal"/> property.
        /// </summary>
        private Func<TSymbol, TSymbol, bool> _areEqual;

        /// <summary>
        /// Gets or sets the equality comparison function.
        /// </summary>
        public virtual Func<TSymbol, TSymbol, bool> Equal
        {
            get { return this._areEqual ?? (this._areEqual = (original, modified) => object.Equals(original, modified)); }
            set { this._areEqual = value; }
        }

        /// <summary>
        /// Computes the difference units to apply over the <paramref name="original"/> tree to get the <paramref name="modified"/> sequences.  
        /// </summary>
        /// <param name="original">the previous version of the <paramref name="modified"/> sequence.</param>
        /// <param name="modified">the next version of the <paramref name="original"/> sequence.</param>
        /// <returns>An script containing the difference units.</returns>
        public virtual IEnumerable<Command> Run(IEnumerable<TSymbol> original, IEnumerable<TSymbol> modified)
        {
            TSymbol[] originalSymbols = original.ToArray();
            TSymbol[] modifiedSymbols = modified.ToArray();

            int N = originalSymbols.Length;
            int M = modifiedSymbols.Length;
            int MAX = N + M;

            if (MAX == 0)
            {
                this.LengthOfShortestEditScriptIsGreaterThanMAX = false;
                return new Command[0];
            }

            int[] V = new int[2 * MAX + 1];
            Func<int, int> kAccessInV = (k) => k + MAX;
            V[kAccessInV(1)] = 0;

            var DPaths = new List<int[]>(MAX + 1);
            int SES = -1;
            for (int D = 0; D <= MAX; D++)
            {
                if (SES != -1)
                    break;

                for (int k = -D; k <= D; k += 2)
                {
                    int x = 0, y = 0;
                    if (k == -D || (k != D && V[kAccessInV(k - 1)] < V[kAccessInV(k + 1)]))
                        x = V[kAccessInV(k + 1)];
                    else
                        x = V[kAccessInV(k - 1)] + 1;

                    y = x - k;

                    while (x < N && y < M && this.Equal(originalSymbols[x], modifiedSymbols[y]))
                    {
                        x = x + 1;
                        y = y + 1;
                    }
                    V[kAccessInV(k)] = x;
                    if (x >= N && y >= M)
                    {
                        SES = D;
                        this.LengthOfShortestEditScriptIsGreaterThanMAX = false;
                        break;
                    }
                }

                int[] VSet = new int[2 * MAX + 1];
                V.CopyTo(VSet, 0);
                DPaths.Add(VSet);
            }

            if (SES == -1)
            {
                this.LengthOfShortestEditScriptIsGreaterThanMAX = true;
                return new Command[0];
            }
            else
            {
                return this.GetSolutionPath(DPaths, originalSymbols, modifiedSymbols).Reverse().ToArray();
            }
        }

        /// <summary>
        /// Builds the solution from the furthest reaching sets.
        /// </summary>
        /// <param name="vs">furthest reaching sets.</param>
        /// <param name="originalSymbols">the previous version of the <paramref name="modified"/> sequence.</param>
        /// <param name="modifiedSymbols">the next version of the <paramref name="original"/> sequence.</param>
        /// <returns>The commands of the edit script.</returns>
        protected virtual IEnumerable<Command> GetSolutionPath(IList<int[]> vs, TSymbol[] originalSymbols, TSymbol[] modifiedSymbols)
        {
            int N = originalSymbols.Length;
            int M = modifiedSymbols.Length;

            Tuple<int, int> p = new Tuple<int, int>(N, M); // start at the end
            for (int d = vs.Count - 1; p.Item1 > 0 || p.Item2 > 0; d--)
            {
                var V = vs[d];
                int k = p.Item1 - p.Item2;
                Func<int, int> kAccessInV = (i) => i + (M + N);

                int xEndPoint = V[kAccessInV(k)];
                Tuple<int, int> endPoint = new Tuple<int, int>(xEndPoint, xEndPoint - k);

                bool down = (k == -d || (k != d && V[kAccessInV(k - 1)] < V[kAccessInV(k + 1)])); // down or right?

                int kPrev = down ? k + 1 : k - 1;
                int xStartPoint = V[kAccessInV(kPrev)];
                Tuple<int, int> startPoint = new Tuple<int, int>(xStartPoint, xStartPoint - kPrev); // start point

                int xPrevEndPoint = down ? xStartPoint : xStartPoint + 1;
                Tuple<int, int> prevEndPoint = new Tuple<int, int>(xPrevEndPoint, xPrevEndPoint - k);

                while (prevEndPoint.Item1 < endPoint.Item1 && prevEndPoint.Item2 < endPoint.Item2 && this.Equal(originalSymbols[prevEndPoint.Item1], modifiedSymbols[prevEndPoint.Item2]))
                {
                    yield return new Command { Kind = CommandKind.Match, Symbol = originalSymbols[prevEndPoint.Item1], AIndex = prevEndPoint.Item1, BIndex = prevEndPoint.Item2 };
                    prevEndPoint = new Tuple<int, int>(prevEndPoint.Item1 + 1, prevEndPoint.Item2 + 1);
                }

                int xMiddlePoint = down ? xStartPoint : xStartPoint + 1;
                int yMiddlePoint = xMiddlePoint - k;

                if (startPoint.Item1 == 0 && startPoint.Item2 == -1 && down)
                {
                    p = new Tuple<int, int>(0, 0);
                }
                else
                {
                    yield return down
                        ? new Command() { Kind = CommandKind.Insert, Symbol = modifiedSymbols[yMiddlePoint - 1], AIndex = xMiddlePoint - 1, BIndex = yMiddlePoint - 1 }
                        : new Command() { Kind = CommandKind.Delete, Symbol = originalSymbols[xMiddlePoint - 1], AIndex = xMiddlePoint - 1, BIndex = -1 };

                    p = startPoint;
                }
            }
        }

        /// <summary>
        /// Gets whether or not the last algorithm executed finished by "Length of Shortest Edit Script is greater than MAX" condition.
        /// </summary>
        public virtual bool LengthOfShortestEditScriptIsGreaterThanMAX { get; protected set; }

        /// <summary>
        /// Contains the options of command associated to the <see cref="FindingLongestCommonSubsequenceOrShortestEditScriptDifference{TSymbol}"/> algorithm.
        /// </summary>
        public enum CommandKind
        {
            /// <summary>
            /// Means a symbol must be inserted.
            /// </summary>
            Insert,

            /// <summary>
            /// Means a symbol must be deleted.
            /// </summary>
            Delete,

            /// <summary>
            /// Means a symbol matching.
            /// </summary>
            Match
        }

        /// <summary>
        /// Represents a command result associated to the <see cref="MyersLCS{TSymbol}"/> algorithm.
        /// </summary>
        public class Command
        {          
            /// <summary>
            /// Gets or sets the kind of the command.
            /// </summary>
            public virtual CommandKind Kind { get; set; }

            /// <summary>
            /// Gets or sets the symbol to be inserted, deleted or matching depending of the <see cref="Kind"/> command kind.
            /// </summary>
            public virtual TSymbol Symbol { get; set; }

            /// <summary>
            /// Gets or sets the index of the command applied to the original (A) sequence.
            /// </summary>
            public virtual int AIndex { get; set; }

            /// <summary>
            /// Gets or sets the index of the command applied to the modified (B) sequence.
            /// </summary>
            public virtual int BIndex { get; set; }
        }
    }
}
