namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Notifies a matched element. 
    /// </summary>
    /// <typeparam name="TElement">Type of the notified elements.</typeparam>
    public interface INotifyMatchedElement<TElement>
    {
        /// <summary>
        /// Occurs when matched an element.
        /// </summary>
        public event EventHandler<object, MatchedElementArgs<TElement>> MatchedElement;
    }
}

    