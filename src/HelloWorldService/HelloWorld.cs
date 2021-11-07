using System;

namespace HelloWorldService
{
    public class HelloWorld : IHelloWorld
    {
        public string Hello(string name)
        {
            return String.Format("Hello, {0}.", name);
        }
    }
}
