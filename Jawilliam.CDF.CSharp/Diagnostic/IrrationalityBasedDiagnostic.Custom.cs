using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.Diagnostic
{
    partial class IrrationalityBasedDiagnostic
    {
        #region DeleteFirstIffDeleteSecond

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeleteFirstIffDeleteSecond(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeleteFirstIffDeleteSecond(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeleteFirstIffDeleteSecondCore(XElement, XElement, ref XElement, ref XElement)"/> is not executed and <see cref="DeleteFirstIffDeleteSecond(XElement, XElement, ref XElement, ref XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeleteFirstIffDeleteSecondBefore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<Imprecision> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeleteFirstIffDeleteSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeleteFirstIffDeleteSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        partial void DeleteFirstIffDeleteSecondAfter(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<Imprecision> result);

        /// <summary>
        /// Tests that first element is deleted if and only if second element was deleted.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeleteFirstIffDeleteSecond(XElement, XElement, ref XElement, ref XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeleteFirstIffDeleteSecondCore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            return new Imprecision[0];
        }

        /// <summary>
        /// Tests that first element is deleted if and only if second element was deleted.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeleteFirstIffDeleteSecond(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            IEnumerable<Imprecision> result = null;
            var ignoreCore = false;
            DeleteFirstIffDeleteSecondBefore(first, second, ref firstAction, ref secondAction, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.DeleteFirstIffDeleteSecondCore(first, second, ref firstAction, ref secondAction);
            DeleteFirstIffDeleteSecondAfter(first, second, ref firstAction, ref secondAction, ref result);
            return result;
        }

        #endregion

        #region InsertFirstIffInsertSecond

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="InsertFirstIffInsertSecond(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertFirstIffInsertSecond(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="InsertFirstIffInsertSecondCore(XElement, XElement, ref XElement, ref XElement)"/> is not executed and <see cref="InsertFirstIffInsertSecond(XElement, XElement, ref XElement, ref XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void InsertFirstIffInsertSecondBefore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<Imprecision> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="InsertFirstIffInsertSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertFirstIffInsertSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        partial void InsertFirstIffInsertSecondAfter(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<Imprecision> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="InsertFirstIffInsertSecond(XElement, XElement, ref XElement, ref XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> InsertFirstIffInsertSecondCore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            return new Imprecision[0];
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> InsertFirstIffInsertSecond(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            IEnumerable<Imprecision> result = null;
            var ignoreCore = false;
            InsertFirstIffInsertSecondBefore(first, second, ref firstAction, ref secondAction, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.InsertFirstIffInsertSecondCore(first, second, ref firstAction, ref secondAction);
            InsertFirstIffInsertSecondAfter(first, second, ref firstAction, ref secondAction, ref result);
            return result;
        }

        #endregion

        #region MoveFirstIffMoveSecond

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="MoveFirstIffMoveSecond(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MoveFirstIffMoveSecond(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="MoveFirstIffMoveSecondCore(XElement, XElement, ref XElement, ref XElement)"/> is not executed and <see cref="MoveFirstIffMoveSecond(XElement, XElement, ref XElement, ref XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void MoveFirstIffMoveSecondBefore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<Imprecision> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="MoveFirstIffMoveSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="MoveFirstIffMoveSecondCore(XElement, XElement, ref XElement, ref XElement)"/>.</param>
        partial void MoveFirstIffMoveSecondAfter(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction, ref IEnumerable<Imprecision> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <param name="firstAction">input or output for the action associated to first element.</param>
        /// <param name="secondAction">input or output for the action associated to second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="MoveFirstIffMoveSecond(XElement, XElement, ref XElement, ref XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> MoveFirstIffMoveSecondCore(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            return new Imprecision[0];
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="first">first element.</param>
        /// <param name="second">second element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> MoveFirstIffMoveSecond(XElement first, XElement second, ref XElement firstAction, ref XElement secondAction)
        {
            IEnumerable<Imprecision> result = null;
            var ignoreCore = false;
            MoveFirstIffMoveSecondBefore(first, second, ref firstAction, ref secondAction, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.MoveFirstIffMoveSecondCore(first, second, ref firstAction, ref secondAction);
            MoveFirstIffMoveSecondAfter(first, second, ref firstAction, ref secondAction, ref result);
            return result;
        }

        #endregion

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="InsertedFromMultiLineCommentTrivia(XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertedFromMultiLineCommentTrivia(XElement, int, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="InsertedFromMultiLineCommentTriviaCore(XElement, int, XElement)"/> is not executed and <see cref="InsertedFromMultiLineCommentTrivia(XElement, int, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void InsertedFromMultiLineCommentTriviaBefore(XElement property, int position, XElement parent, ref IEnumerable<Imprecision> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="InsertedFromMultiLineCommentTriviaCore(XElement, int, XElement)"/>.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="InsertedFromMultiLineCommentTriviaCore(XElement, int, XElement)"/>.</param>
        partial void InsertedFromMultiLineCommentTriviaAfter(XElement property, int position, XElement parent, ref IEnumerable<Imprecision> result);

        /// <summary>
        /// Analyzes an insert action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="InsertedFromMultiLineCommentTrivia(XElement, int, XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> InsertedFromMultiLineCommentTriviaCore(XElement property, int position, XElement parent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes an insert action.
        /// </summary>
        /// <param name="property">property element.</param>
        /// <param name="position">position where insert the property element in.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> InsertedFromMultiLineCommentTrivia(XElement property, int position, XElement parent)
        {
            IEnumerable<Imprecision> result = null;
            var ignoreCore = false;
            InsertedFromMultiLineCommentTriviaBefore(property, position, parent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.InsertedFromMultiLineCommentTriviaCore(property, position, parent);
            InsertedFromMultiLineCommentTriviaAfter(property, position, parent, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSingleLineCommentTrivia(XElement, XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSingleLineCommentTrivia(XElement, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSingleLineCommentTriviaCore(XElement, XElement)"/> is not executed and <see cref="DeletedFromSingleLineCommentTrivia(XElement, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSingleLineCommentTriviaBefore(XElement property, XElement parent, ref IEnumerable<Imprecision> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSingleLineCommentTriviaCore(XElement, XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSingleLineCommentTriviaCore(XElement, XElement)"/>.</param>
        partial void DeletedFromSingleLineCommentTriviaAfter(XElement property, XElement parent, ref IEnumerable<Imprecision> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSingleLineCommentTrivia(XElement, XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSingleLineCommentTriviaCore(XElement property, XElement parent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSingleLineCommentTrivia(XElement property, XElement parent)
        {
            IEnumerable<Imprecision> result = null;
            var ignoreCore = false;
            DeletedFromSingleLineCommentTriviaBefore(property, parent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.DeletedFromSingleLineCommentTriviaCore(property, parent);
            DeletedFromSingleLineCommentTriviaAfter(property, parent, ref result);
            return result;
        }

        /// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromMultiLineCommentTrivia(XElement, XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMultiLineCommentTrivia(XElement, XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromMultiLineCommentTriviaCore(XElement, XElement)"/> is not executed and <see cref="DeletedFromMultiLineCommentTrivia(XElement, XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromMultiLineCommentTriviaBefore(XElement property, XElement parent, ref IEnumerable<Imprecision> result, ref bool ignoreCore);

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromMultiLineCommentTriviaCore(XElement, XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMultiLineCommentTriviaCore(XElement, XElement)"/>.</param>
        partial void DeletedFromMultiLineCommentTriviaAfter(XElement property, XElement parent, ref IEnumerable<Imprecision> result);

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="parent">parent element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromMultiLineCommentTrivia(XElement, XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromMultiLineCommentTriviaCore(XElement property, XElement parent)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            yield break;
        }

        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromMultiLineCommentTrivia(XElement property, XElement parent)
        {
            IEnumerable<Imprecision> result = null;
            var ignoreCore = false;
            DeletedFromMultiLineCommentTriviaBefore(property, parent, ref result, ref ignoreCore);
            if (ignoreCore)
                return result;

            result = this.DeletedFromMultiLineCommentTriviaCore(property, parent);
            DeletedFromMultiLineCommentTriviaAfter(property, parent, ref result);
            return result;
        }
    }
}
