using System;

namespace csharp_cmd
{
    public class MyEventArgs
    {
        public MyEventArgs(int arg) { Counter = arg; }
        public int Counter { get; private set; }
    }

    class Foo
    {
        public delegate void MyEventHandler(object sender, MyEventArgs e);
        public event MyEventHandler OnFifteen;

        private int _counter;
        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                _counter = value;

                if (value == 15)
                    if (OnFifteen != null)
                        OnFifteen(this, new MyEventArgs(value));
            }
        }
    }

    class TestEvent
    {
        public static void Start()
        {
            bool triggered = true;

            var foo = new Foo { Counter = 10 };

            foo.OnFifteen += (object o, MyEventArgs arg) =>
            {
                triggered = false;
                Console.WriteLine("Event fired! Value is {0}", arg.Counter);
            };

            foo.OnFifteen += (object o, MyEventArgs arg) =>
                {
                    Console.WriteLine("Event fired! Value is {0}", arg.Counter);
                    Console.WriteLine("Event fired! Value is {0}", arg.Counter);
                };

            for (var i = 1; i <= 10 && triggered; i++)
                Console.WriteLine("foo.Counter = {0}", ++foo.Counter);
        }
    }
}
