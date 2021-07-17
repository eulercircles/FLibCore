using System;
using System.Linq;
using System.Diagnostics;

namespace FLibCore.Common
{
  /// <summary>
  /// An event wrapper that ensures a handler can only subscribe once to an event.
  /// Prevents accidental multiple subscription, leading to unintentional multiple calls of the same event handler.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class SafeEvent<T> where T: EventArgs
  {
    private EventHandler<T> _event;

    /// <summary>
		/// Subscribes the handler method to the event. If the handler method is already subscribed, it will *not* be subscribed again.
		/// </summary>
		/// <param name="handler">The delegate method that will react to and handle this event.</param>
    public void Subscribe(EventHandler<T> handler)
    {
      Debug.Assert(handler != null);
      if (_event == null || !_event.GetInvocationList().Contains(handler)) { _event += handler; }
    }

    /// <summary>
    /// Unsubscribes the handler method from the event.
    /// </summary>
    /// <param name="handler">The delegate method to unsubscribe from this event.</param>
    public void Unsubscribe(EventHandler<T> handler)
		{
      Debug.Assert(handler != null);
      if (_event != null && _event.GetInvocationList().Contains(handler)) { _event -= handler; }
		}

    /// <summary>
    /// Invokes the event.
    /// </summary>
    /// <param name="sender">The object that is invoking the event.</param>
    /// <param name="args">Optional arguments to pass with the event invocation.</param>
    public void Invoke(object sender, T args) => _event?.Invoke(sender, args);
  }

  /// <summary>
  /// Provides a wrapper around <typeparamref name="SafeEvent">SafeEvent<typeparamref name="T"></typeparamref></typeparamref> 
  /// so that the Invoke method is not available to subscribers.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class Event<T> where T : EventArgs
	{
    private readonly SafeEvent<T> _innerEvent;

    public Event(SafeEvent<T> innerEvent)
		{
      _innerEvent = innerEvent ?? throw new ArgumentNullException(nameof(innerEvent));
		}

    public void Subscribe(EventHandler<T> handler) => _innerEvent.Subscribe(handler);
    public void Unsubscribe(EventHandler<T> handler) => _innerEvent.Unsubscribe(handler);
	}
}
