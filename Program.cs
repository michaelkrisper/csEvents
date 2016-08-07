using System;
using System.Collections.Generic;
using System.Linq;

namespace csEvents
{
    public class Program
    {
        public static void Main()
        {
            var c = new EventSubject();
            c.Finished += () => Console.WriteLine("Finished.");
            c.DoWork();

            var s = new ConcreteSubject();
            s.Attach(new ConcreteObserver());
            s.DoWork();

            Console.ReadKey();
        }
    }

    public class EventSubject
    {
        public event Action Finished;

        public void DoWork()
        {
            Console.WriteLine("Doing work.");
            Finished?.Invoke();
        }
    }

    public class Subject
    {
        private readonly HashSet<IObserver> _observers = new HashSet<IObserver>();
        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);
        protected void Notify() => _observers.ToList().ForEach(o => o.Update(this));
    }

    public class ConcreteSubject : Subject
    {
        public void DoWork()
        {
            Console.WriteLine("Doing work.");
            Notify();
        }
    }

    public interface IObserver
    {
        void Update(object sender);
    }

    public class ConcreteObserver : IObserver
    {
        public void Update(object sender) => Console.WriteLine("Finished.");
    }
}