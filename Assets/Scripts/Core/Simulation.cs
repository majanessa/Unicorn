using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// The Simulation class implements the discrete event simulator pattern.
    /// Events are pooled, with a default capacity of 4 instances.
    /// </summary>
    public static partial class Simulation
    {
        private static readonly HeapQueue<Event> EventQueue = new HeapQueue<Event>();
        private static readonly Dictionary<System.Type, Stack<Event>> EventPools = new Dictionary<System.Type, Stack<Event>>();

        /// <summary>
        /// Create a new event of type T and return it, but do not schedule it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T New<T>() where T : Event, new()
        {
            if (!EventPools.TryGetValue(typeof(T), out var pool))
            {
                pool = new Stack<Event>(4);
                pool.Push(new T());
                EventPools[typeof(T)] = pool;
            }
            if (pool.Count > 0)
                return (T)pool.Pop();
            else
                return new T();
        }

        /// <summary>
        /// Clear all pending events and reset the tick to 0.
        /// </summary>
        public static void Clear()
        {
            EventQueue.Clear();
        }

        /// <summary>
        /// Schedule an event for a future tick, and return it.
        /// </summary>
        /// <returns>The event.</returns>
        /// <param name="tick">Tick.</param>
        /// <typeparam name="T">The event type parameter.</typeparam>
        public static T Schedule<T>(float tick = 0) where T : Event, new()
        {
            var ev = New<T>();
            ev.Tick = Time.time + tick;
            EventQueue.Push(ev);
            return ev;
        }

        /// <summary>
        /// Return the simulation model instance for a class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T GetModel<T>() where T : class, new()
        {
            return InstanceRegister<T>.Instance;
        }
        
        /// <summary>
        /// Tick the simulation. Returns the count of remaining events.
        /// If remaining events is zero, the simulation is finished unless events are
        /// injected from an external system via a Schedule() call.
        /// </summary>
        /// <returns></returns>
        public static int Tick()
        {
            var time = Time.time;
            while (EventQueue is { Count: > 0 } && EventQueue.Peek().Tick <= time)
            {
                var ev = EventQueue.Pop();
                var tick = ev.Tick;
                ev.ExecuteEvent();
                if (ev.Tick > tick)
                {
                    //event was rescheduled, so do not return it to the pool.
                }
                else
                {
                    // Debug.Log($"<color=green>{ev.tick} {ev.GetType().Name}</color>");
                    ev.Cleanup();
                    try
                    {
                        EventPools[ev.GetType()].Push(ev);
                    }
                    catch (KeyNotFoundException)
                    {
                        //This really should never happen inside a production build.
                        Debug.LogError($"No Pool for: {ev.GetType()}");
                    }
                }
            }
            return EventQueue.Count;
        }
    }
}
