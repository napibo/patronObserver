using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronObserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creation of the newspaper which is the main subject
            Newspaper newspaper = new Newspaper();

            Console.WriteLine("First State of the newspaper");
            //here we create the observers of the newspaper
            SubscriberObserv observer1 = new SubscriberObserv("Natha");
            SubscriberObserv observer2 = new SubscriberObserv("Juan");
            SubscriberObserv observer3 = new SubscriberObserv("Franc");

            //we register the observers of the newspaper
            newspaper.register(observer1);
            newspaper.register(observer2);
            newspaper.register(observer3);

            //we changes the status for the trigger
            newspaper.ChangeState("New Post");
            Console.WriteLine("");
            Console.WriteLine("Second State");
            //here we can unsubscribe any observer
            newspaper.unregister(observer2);

            newspaper.ChangeState("New Post 2");

            Console.ReadKey();



        }

        interface IObserver
        { 
            void update(string mensaje);
        }

        interface INewspaper
        {
            void register(IObserver observer);
            void unregister(IObserver observer);
            void notifyObservers();
        }

        class Newspaper : INewspaper
        {
            private List<IObserver> _observers = new List<IObserver>();
            private string message;

            public void register(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void unregister(IObserver observer)
            {
                _observers.Remove(observer);
            }

            public void notifyObservers() {
                foreach (var observ in _observers)
                {
                    observ.update(message);
                }
            }

            public void ChangeState(string NewMessage) { 
                message = NewMessage;
                notifyObservers();
            }

        }

        class SubscriberObserv : IObserver
        {
            public string _Name { get; private set; }

            public SubscriberObserv (string name)
            {
                _Name = name;
            }

            public void update(string message)
            {
                Console.WriteLine($"Subscriptor {_Name} recibio el mensaje: {message} ");
            }

        }


    }
}
