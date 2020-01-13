
using System;


namespace GeneticDams.BLL
{
    /// <summary>
    /// Abstract handler to implement
    /// </summary>
    public abstract class AbstractHandler
    {
        // Self reference
        private AbstractHandler _nextHandler;

        public AbstractHandler SetNext(AbstractHandler handler)
        {
            _nextHandler = handler;
            // We connect the handlers here to make the chain
            return handler;
        }

        // Abstract method to implement (virtual it is like override method)
        /// <summary>
        /// Handle method that we will reimplement
        /// </summary>
        /// <param name="request">Object to process</param>
        /// <returns>Response string</returns>
        public virtual object Handle(object request)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// This class implements AbstractHandler
    /// </summary>
    public class UserHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) != "")
            {
                return "User";
            }
            else
            {
                // Call to parent method (next handler)
                return base.Handle(request);
            }
        }
    }

    /// <summary>
    /// This class implements AbstractHandler
    /// </summary>
    public class AdminHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "admin@uah.es")
            {
                return "Admin";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    /// <summary>
    /// This class implements AbstractHandler
    /// </summary>
    public class SpecialistHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "spec@uah.es")
            {
                return "Specialist";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
    public  class ClientHandler
    {
        public static string Use(AbstractHandler handler, String userType)
        {
                var result = handler.Handle(userType);
            string response;
                if (result != null)
                {
                response = result.ToString();
                }
                else
                {
                response = "Not role found";
                }
            return response;
            }
        
    }
}
