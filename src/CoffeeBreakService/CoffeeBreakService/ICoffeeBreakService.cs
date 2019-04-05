using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CoffeeBreakService
{
    [ServiceContract]
    public interface ICoffeeBreakService
    {
        [OperationContract]
        CoffeeBreakResponse RequestCoffeeBreak(CoffeeBreakRequest request); 
    }

    [DataContract]
    public class CoffeeBreakRequest
    {
        [DataMember]
        public DateTime RequestedCoffeeBreakTime { get; set; }
    }

    [DataContract]
    public class CoffeeBreakResponse
    {
        [DataMember]
        public DateTime CoffeeBreakTime { get; set; }
    }
}
