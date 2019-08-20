﻿namespace Jawilliam.CDF
{
    /// <summary>
    /// Represents the method that will handle an event when the event provides data.
    /// </summary>
    /// <typeparam name="TSender">The type of the event data generated by the event.</typeparam>
    /// <typeparam name="TEventArgs">The type of the source.</typeparam>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An object that contains the event data.</param>
    public delegate void EventHandler<TSender, TEventArgs>(TSender sender, TEventArgs e);
}
