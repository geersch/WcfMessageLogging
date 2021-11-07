using System.ServiceModel;

namespace HelloWorldService
{
    [ServiceContract]
    public interface IHelloWorld
    {
        [OperationContract]
        string Hello(string name);
    }
}
