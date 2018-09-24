//using System.Linq;
//using Jawilliam.CDF.Approach;

//namespace Jawilliam.CDF.Labs
//{
//    /// <summary>
//    /// Implements imprecision diagnostic through a redundant names checking.
//    /// </summary>
//    public class RedundantNameChecking : RedundancyChecking<FileRevisionPairAnalyzer.CandidateName>
//    {
//        /// <summary>
//        /// Returns a configuration to check for redundant names.
//        /// </summary>
//        public virtual void AutoConfig()
//        {
//            this.Config = new Criterion
//            {
//                IsSubject = m => m.Element.Label == "name",
//                Nickname = "Name",
//                AsSubject = delegate (ElementTree tree)
//                {
//                    var context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(tree));
//                    return context == null ? null : new CandidateName { Tree = tree, Context = context };
//                },
//                GetScopes = a => a.Context.OuterScopes(a.Tree),
//                FilterOut = delegate (CandidateName original, CandidateName modified, string pattern, DetectionResult detectionResult)
//                {
//                    switch (pattern)
//                    {
//                        case "UU":
//                            return detectionResult.Matches.Any(m => m.Original.Id == original.Tree.Root.Id &&
//                                                                    m.Modified.Id == modified.Tree.Root.Id);
//                        case "MM":
//                            return detectionResult.Matches.Any(m => m.Original.Id == original.Tree.Root.Id &&
//                                                                    m.Modified.Id == modified.Tree.Root.Id);
//                        default: return false;
//                    }
//                },
//                AreRedundant = (original, modified, pattern, delta) => original.Tree.Root.Value == modified.Tree.Root.Value,
//                AsResult = (original, modified, pattern, delta) => new MissedElement
//                {
//                    Modified = new MissedVersion
//                    {
//                        Type = modified.Context.NameOf(modified.Tree),
//                        Element = modified.Tree
//                    },
//                    Original = new MissedVersion
//                    {
//                        Type = original.Context.NameOf(original.Tree),
//                        Element = original.Tree
//                    }
//                }
//            };
//        }
//    }
//}