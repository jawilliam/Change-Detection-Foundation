//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Jawilliam.CDF.Labs.VSIXProject.Models.Impl
//{
//    /// <summary>
//    /// Structures recurrent actions based on a <see cref="Subject"/>
//    /// </summary>
//    public class RateableMatchWorkFlow
//    {
//        private RateableMatch _subject;

//        /// <summary>
//        /// Gets or sets the object of interest.
//        /// </summary>
//        public virtual RateableMatch Subject
//        {
//            get { return _subject ?? throw new ArgumentNullException(nameof(this.Subject)); }
//            set { _subject = value; }
//        }

//        public virtual void Run(RateableMatch subject)
//        {
//            if (subject.ExpectedOriginal4ThisModified_GumTreeId == null &&
//                subject.ExpectedOriginal4ThisModified != null)
//            {
//                //subject.ExpectedOriginal4ThisModified.GumTreeId = "-1";
//                subject.ExpectedOriginal4ThisModified.Id = "-1";
//                subject.ExpectedOriginal4ThisModified.Type = "";
//                subject.ExpectedOriginal4ThisModified.Hint = null;
//            }
//                else if (subject.ExpectedOriginal4ThisModified_GumTreeId != null)
//                {
//                    var original = this.Model.LoadedDisagreedDelta.FullAsts
//                        .GumTreeOriginals[subject.ExpectedOriginal4ThisModified_GumTreeId];
//                    subject.ExpectedOriginal4ThisModified ??= new Common.DBModel.ElementDescription
//                    {
//                        //GumTreeId = "-1",
//                        Id = "-1",
//                        Type = "",
//                        Hint = null
//                    };
//                    //subject.ExpectedOriginal4ThisModified.GumTreeId = original.GtID();
//                    subject.ExpectedOriginal4ThisModified.Id = original.RmId();
//                    subject.ExpectedOriginal4ThisModified.Type = original.Attribute("kind")?.Value ?? original.Name.LocalName;
//                    subject.ExpectedOriginal4ThisModified.Hint = original.Value;
//                }
//                subject.RaisePropertyChanged(ObservableObject.GetPropertyName(() => subject.ExpectedOriginal4ThisModified));
//            }
//            else if (e.PropertyName == ObservableObject.GetPropertyName(()
//                => rm.ExpectedModified4ThisOriginal_GumTreeId))
//            {
//                if (rm.ExpectedModified4ThisOriginal_GumTreeId == null &&
//                    rm.ExpectedModified4ThisOriginal != null)
//                {
//                    //rm.ExpectedModified4ThisOriginal.GumTreeId = "-1";
//                    rm.ExpectedModified4ThisOriginal.Id = "-1";
//                    rm.ExpectedModified4ThisOriginal.Type = "";
//                    rm.ExpectedModified4ThisOriginal.Hint = null;
//                }
//                else if (rm.ExpectedModified4ThisOriginal_GumTreeId != null)
//                {
//                    var modified = this.Model.LoadedDisagreedDelta.FullAsts
//                        .GumTreeModifieds[rm.ExpectedModified4ThisOriginal_GumTreeId];
//                    rm.ExpectedModified4ThisOriginal ??= new Common.DBModel.ElementDescription
//                    {
//                        //GumTreeId = "-1",
//                        Id = "-1",
//                        Type = "",
//                        Hint = null
//                    };
//                    //rm.ExpectedModified4ThisOriginal.GumTreeId = modified.GtID();
//                    rm.ExpectedModified4ThisOriginal.Id = modified.RmId();
//                    rm.ExpectedModified4ThisOriginal.Type = modified.Attribute("kind")?.Value ?? modified.Name.LocalName;
//                    rm.ExpectedModified4ThisOriginal.Hint = modified.Value;
//                }
//                rm.RaisePropertyChanged(ObservableObject.GetPropertyName(() => rm.ExpectedModified4ThisOriginal));
//            }
//        }
//    }
//    }
//}
