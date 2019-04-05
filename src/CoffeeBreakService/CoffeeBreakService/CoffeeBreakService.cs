using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CoffeeBreakService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CoffeeBreakService : ICoffeeBreakService
    {
        public CoffeeBreakResponse RequestCoffeeBreak(CoffeeBreakRequest request)
        {
            if ((request.RequestedCoffeeBreakTime.Hour >= 8 && request.RequestedCoffeeBreakTime.Hour <= 10) ||
                (request.RequestedCoffeeBreakTime.Hour >= 13 && request.RequestedCoffeeBreakTime.Hour <= 15))
            {
                return new CoffeeBreakResponse
                {
                    CoffeeBreakTime = request.RequestedCoffeeBreakTime
                };
            }

            if (request.RequestedCoffeeBreakTime.Hour < 8)
            {
                return new CoffeeBreakResponse
                {
                    CoffeeBreakTime = new DateTime(request.RequestedCoffeeBreakTime.Year, request.RequestedCoffeeBreakTime.Month, request.RequestedCoffeeBreakTime.Day, 8, 0, 0)
                };
            } 
            else if (request.RequestedCoffeeBreakTime.Hour < 13)
            {
                return new CoffeeBreakResponse
                {
                    CoffeeBreakTime = new DateTime(request.RequestedCoffeeBreakTime.Year, request.RequestedCoffeeBreakTime.Month, request.RequestedCoffeeBreakTime.Day, 13, 0, 0)
                };
            }
            else if (request.RequestedCoffeeBreakTime.Hour > 15) 
            {
                return new CoffeeBreakResponse
                {
                    CoffeeBreakTime = new DateTime(request.RequestedCoffeeBreakTime.Year, request.RequestedCoffeeBreakTime.Month, request.RequestedCoffeeBreakTime.Day, 15, 0, 0)
                };
            }
            else
            {
                return null;
            }
        }
    }
}
