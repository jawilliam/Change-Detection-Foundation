namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Notifies an moved element. 
    /// </summary>
    /// <typeparam name="TElement">Type of the notified elements.</typeparam>
    public interface INotifyMovedElement<TElement>
    {
        /// <summary>
        /// Occurs when moved an element.
        /// </summary>
        public event EventHandler<object, MovedElementArgs<TElement>> MovedElement;
    }
}

    