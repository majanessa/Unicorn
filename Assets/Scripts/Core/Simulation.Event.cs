namespace Core
{
    public static partial class Simulation
    {
        /// <summary>
        /// An event is something that happens at a point in time in a simulation.
        /// The Precondition method is used to check if the event should be executed,
        /// as conditions may have changed in the simulation since the event was 
        /// originally scheduled.
        /// </summary>
        public abstract class Event : System.IComparable<Event>
        {
            internal float Tick;

            public int CompareTo(Event other)
            {
                return Tick.CompareTo(other.Tick);
            }

            protected abstract void Execute();

            protected virtual bool Precondition() => true;

            internal virtual void ExecuteEvent()
            {
                if (Precondition())
                    Execute();
            }

            /// <summary>
            /// This method is generally used to set references to null when required.
            /// It is automatically called by the Simulation when an event has completed.
            /// </summary>
            internal virtual void Cleanup()
            {

            }
        }

        /// <summary
        /// T="adds the ability to hook into the OnExecute callback
        /// whenever the event is executed. Use this class to allow functionality
        /// to be plugged into your application with minimal or zero configuration.">
        /// Event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class Event<T> : Event where T : Event<T>
        {
            private static System.Action<T> _onExecute;

            internal override void ExecuteEvent()
            {
                if (!Precondition()) return;
                Execute();
                _onExecute?.Invoke((T)this);
            }
        }
    }
}
