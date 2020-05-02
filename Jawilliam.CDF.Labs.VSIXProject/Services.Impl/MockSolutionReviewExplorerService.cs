using Jawilliam.CDF.Labs.Common.DBModel;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.Labs.VSIXProject.Services.Impl
{
    /// <summary>
    /// Implements a EF-based <see cref="ViewModels.SolutionReviewExplorerViewModel"/>'s service that .
    /// </summary>
    public class MockSolutionReviewExplorerService : SolutionReviewExplorerService
    {
        /// <summary>
        /// Gets the delta comparisons existing in a given project between the given left approach and the given right approach. 
        /// </summary>
        /// <param name="project">project name.</param>
        /// <param name="leftApproach">left approach.</param>
        /// <param name="rightApproach">right approach.</param>
        /// <returns>A summary for each existing delta comparison.</returns>
        public override IEnumerable<DisagreedDeltaDescriptor> GetDisagreedDeltas(string project, ChangeDetectionApproaches leftApproach, ChangeDetectionApproaches rightApproach)
        {
            yield return new DisagreedDeltaDescriptor { Index = 1, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 4, LrMismatches = 2, RlMismatches = 0 };
            yield return new DisagreedDeltaDescriptor { Index = 2, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 6, LrMismatches = 2, RlMismatches = 4 };
            yield return new DisagreedDeltaDescriptor { Index = 3, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 14, LrMismatches = 3, RlMismatches = 11 };
            yield return new DisagreedDeltaDescriptor { Index = 4, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 17, LrMismatches = 12, RlMismatches = 5 };
        }

        /// <summary>
        /// Loads the content of a given disagreed delta.
        /// </summary>
        /// <param name="project">project name.</param>
        /// <param name="leftDeltaId">left delta's ID.</param>
        /// <param name="rightDeltaId">right delta's ID.</param>
        /// <returns>The set of found disagreed mismatches.</returns>
        public override DisagreedDeltaContent LoadDisagreedDelta(string project, Guid leftDeltaId, Guid rightDeltaId, ApproachInfo info)
        {
            return new DisagreedDeltaContent 
            {
                LeftId = Guid.NewGuid(), 
                RightId = Guid.NewGuid(),
                //Comparison = new DeltaComparison
                //{
                //    Matching = "<MatchingComparison xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                //               "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                //    "<Matching>" +
                //    "" +
                //    "<LrMatch LeftApproach=\"2010\" " +
                //    "LeftOId=\"604\" LeftOType=\"IdentifierName\" LeftMId=\"5239\" LeftMType=\"IdentifierName\" " +
                //    "OriginalAtRightApproach=\"2011\" OriginalAtRightOId=\"-1\" OriginalAtRightOType=\"\" OriginalAtRightMId=\"-1\" " +
                //    "OriginalAtRightMType=\"\" ModifiedAtRightApproach=\"2011\" ModifiedAtRightOId=\"5239\" " +
                //    "ModifiedAtRightOType=\"IdentifierName\" ModifiedAtRightMId=\"5335\" ModifiedAtRightMType=\"IdentifierName\" />" +
                //    "" +
                //    "<LrMatch LeftApproach=\"2010\" " +
                //    "LeftOId=\"4394\" LeftOType=\"IdentifierToken\" LeftOHint=\"regions\" " +
                //    "LeftMId=\"4322\" LeftMType=\"IdentifierToken\" LeftMHint=\"regions\" " +
                //    "OriginalAtRightApproach=\"2011\" OriginalAtRightOId=\"-1\" OriginalAtRightOType=\"\" " +
                //    "OriginalAtRightMId=\"-1\" OriginalAtRightMType=\"\" ModifiedAtRightApproach=\"2011\" " +
                //    "ModifiedAtRightOId=\"-1\" ModifiedAtRightOType=\"\" ModifiedAtRightMId=\"-1\" ModifiedAtRightMType=\"\" />" +
                //    "" +
                //    "<LrMatch LeftApproach=\"2010\" " +
                //    "LeftOId=\"4408\" LeftOType=\"IdentifierToken\" LeftOHint=\"unallocatedShards\" " +
                //    "LeftMId=\"4336\" LeftMType=\"IdentifierToken\" LeftMHint=\"unallocatedShards\" " +
                //    "OriginalAtRightApproach=\"2011\" OriginalAtRightOId=\"-1\" OriginalAtRightOType=\"\" " +
                //    "OriginalAtRightMId=\"-1\" OriginalAtRightMType=\"\" " +
                //    "ModifiedAtRightApproach=\"2011\" ModifiedAtRightOId=\"-1\" ModifiedAtRightOType=\"\" " +
                //    "ModifiedAtRightMId=\"-1\" ModifiedAtRightMType=\"\" />" +
                //    "" +
                //    "<LrMatch LeftApproach=\"2010\" " +
                //    "LeftOId=\"603\" LeftOType=\"IdentifierToken\" LeftOHint=\"system\" " +
                //    "LeftMId=\"5238\" LeftMType=\"IdentifierToken\" LeftMHint=\"system\" " +
                //    "OriginalAtRightApproach=\"2011\" OriginalAtRightOId=\"-1\" OriginalAtRightOType=\"\" " +
                //    "OriginalAtRightMId=\"-1\" OriginalAtRightMType=\"\" " +
                //    "ModifiedAtRightApproach=\"2011\" ModifiedAtRightOId=\"5238\" ModifiedAtRightOType=\"IdentifierToken\" " +
                //    "ModifiedAtRightOHint=\"system\" ModifiedAtRightMId=\"5334\" ModifiedAtRightMType=\"IdentifierToken\" " +
                //    "ModifiedAtRightMHint=\"_system\" />" +
                //    "" +
                //    "<RlMatch RightApproach=\"2011\" " +
                //    "RightOId=\"5239\" RightOType=\"IdentifierName\" RightMId=\"5335\" RightMType=\"IdentifierName\" " +
                //    "OriginalAtLeftApproach=\"2010\" OriginalAtLeftOId=\"604\" OriginalAtLeftOType=\"IdentifierName\" " +
                //    "OriginalAtLeftMId=\"5239\" OriginalAtLeftMType=\"IdentifierName\" ModifiedAtLeftApproach=\"2010\" " +
                //    "ModifiedAtLeftOId=\"-1\" ModifiedAtLeftOType=\"\" ModifiedAtLeftMId=\"-1\" ModifiedAtLeftMType=\"\" />" +
                //    "" +
                //    "<RlMatch RightApproach=\"2011\" " +
                //    "RightOId=\"4315\" RightOType=\"IdentifierToken\" RightOHint=\"shards\" " +
                //    "RightMId=\"4387\" RightMType=\"IdentifierToken\" RightMHint=\"shards\" " +
                //    "OriginalAtLeftApproach=\"2010\" OriginalAtLeftOId=\"-1\" OriginalAtLeftOType=\"\" " +
                //    "OriginalAtLeftMId=\"-1\" OriginalAtLeftMType=\"\" " +
                //    "ModifiedAtLeftApproach=\"2010\" ModifiedAtLeftOId=\"-1\" ModifiedAtLeftOType=\"\" " +
                //    "ModifiedAtLeftMId=\"-1\" ModifiedAtLeftMType=\"\" />" +
                //    "" +
                //    "<RlMatch RightApproach=\"2011\" " +
                //    "RightOId=\"5238\" RightOType=\"IdentifierToken\" RightOHint=\"system\" " +
                //    "RightMId=\"5334\" RightMType=\"IdentifierToken\" RightMHint=\"_system\" OriginalAtLeftApproach=\"2010\" " +
                //    "OriginalAtLeftOId=\"603\" OriginalAtLeftOType=\"IdentifierToken\" OriginalAtLeftOHint=\"system\" " +
                //    "OriginalAtLeftMId=\"5238\" OriginalAtLeftMType=\"IdentifierToken\" OriginalAtLeftMHint=\"system\" " +
                //    "ModifiedAtLeftApproach=\"2010\" ModifiedAtLeftOId=\"-1\" ModifiedAtLeftOType=\"\" " +
                //    "ModifiedAtLeftMId=\"-1\" ModifiedAtLeftMType=\"\" />" +
                //    "" +
                //    "</Matching>" +
                //    "" +
                //    "</MatchingComparison>"
                //}
            };
        }
    }
}
