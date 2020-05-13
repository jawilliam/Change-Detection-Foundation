namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Notifies a inserted element. 
    /// </summary>
    /// <typeparam name="TElement">Type of the notified elements.</typeparam>
    public interface INotifyInsertedElement<TElement>
    {
        /// <summary>
        /// Occurs when inserted an element.
        /// </summary>
        public event EventHandler<object, InsertedElementArgs<TElement>> InsertedElement;
    }
}

    