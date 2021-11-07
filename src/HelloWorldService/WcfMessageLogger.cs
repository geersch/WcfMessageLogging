using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace HelloWorldService
{
    public class WcfMessageLogger : IDispatchMessageInspector, IServiceBehavior
    {
        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, 
            InstanceContext instanceContext)
        {
            Debug.Write(request.ToString());
            Debug.WriteLine(String.Empty);
            Debug.WriteLine(String.Empty);
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            Debug.Write(reply.ToString());
        }

        #endregion

        #region IServiceBehavior

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, 
            ServiceHostBase serviceHostBase)
        {
            foreach(ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach(var endpoint in dispatcher.Endpoints)
                {
                    endpoint.DispatchRuntime.MessageInspectors.Add(new WcfMessageLogger());
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, 
            ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
           BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, 
            ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }
}
