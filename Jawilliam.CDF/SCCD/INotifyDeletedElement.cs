namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Notifies a deleted element. 
    /// </summary>
    /// <typeparam name="TElement">Type of the notified elements.</typeparam>
    public interface INotifyDeletedElement<TElement>
    {
        /// <summary>
        /// Occurs when deleted an element.
        /// </summary>
        public event EventHandler<object, DeletedElementArgs<TElement>> DeletedElement;
    }
}

    