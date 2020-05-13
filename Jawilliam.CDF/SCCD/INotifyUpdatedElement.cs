namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Notifies an updated element. 
    /// </summary>
    /// <typeparam name="TElement">Type of the notified elements.</typeparam>
    public interface INotifyUpdatedElement<TElement>
    {
        /// <summary>
        /// Occurs when updated an element.
        /// </summary>
        public event EventHandler<object, UpdatedElementArgs<TElement>> UpdatedElement;
    }
}

    