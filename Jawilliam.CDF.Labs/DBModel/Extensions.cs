using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.DBModel
{
    /// <summary>
    /// Contains shared methods logically associated to entities available in the DBModel
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Loads the original and modified versions for a given revision pair ID and file FORMAT.
        /// </summary>
        /// <param name="source">repository database which the file versions will be loaded from.</param>
        /// <param name="revisionPair">revision pair</param>
        /// <param name="forwardIfTrueOtherwiseBackward">the order of the file revision pair (original, modified) if true, otherwise (modified, original).</param>
        /// <param name="fileFormat">file format</param>
        /// <param name="originalFileVersion">to store the loaded original file version.</param>
        /// <param name="modifiedFileVersion">to store the loaded modified file version.</param>
        public static void LoadFileRevisionPair(this GitRepository source, FileModifiedChange revisionPair,
            bool forwardIfTrueOtherwiseBackward, FileFormatKind fileFormat,
            ref FileFormat originalFileVersion, ref FileFormat modifiedFileVersion)
        {
            originalFileVersion = forwardIfTrueOtherwiseBackward
                                    ? source.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fileFormat &&
                                                                                           ff.FileVersion.Id == revisionPair.FromFileVersion.Id)
                                    : source.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fileFormat &&
                                                                                           ff.FileVersion.Id == revisionPair.FileVersion.Id);
            modifiedFileVersion = forwardIfTrueOtherwiseBackward
                    ? source.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fileFormat &&
                                                                           ff.FileVersion.Id == revisionPair.FileVersion.Id)
                    : source.FileFormats.AsNoTracking().SingleOrDefault(ff => ff.Kind == fileFormat &&
                                                                           ff.FileVersion.Id == revisionPair.FromFileVersion.Id);
        }
    }
}
