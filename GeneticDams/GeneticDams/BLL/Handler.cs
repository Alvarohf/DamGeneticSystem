
using System;


namespace GeneticDams.BLL
{
    /// <summary>
    /// Abstract handler to implement the chain of responsability
    /// </summary>
    public abstract class AbstractHandler
    {
        // Self reference
        private AbstractHandler _nextHandler;

        /// <summary>
        /// Set the next handler to use in the chain
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
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
    /// This class implements AbstractHandler for a normal user
    /// </summary>
    public class UserHandler : AbstractHandler
    {
        /// <summary>
        /// Handle a request for a normal user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A string with user</returns>
        override
        public object Handle(object request)
        {
            // All users are normal users
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
    /// This class implements AbstractHandler for admin
    /// </summary>
    public class AdminHandler : AbstractHandler
    {
        /// <summary>
        /// Handle a request for an admin
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A string with admin</returns>
        override
        public object Handle(object request)
        {
            // Only the admin passes
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
        /// <summary>
        /// Handle a request for a specialist
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A string with specialist</returns>
        override
        public object Handle(object request)
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
    /// <summary>
    /// Class that use the handlers
    /// </summary>
    public class ClientHandler
    {
        /// <summary>
        /// Use the handlers to get the type
        /// </summary>
        /// <param name="handler">Handler to use</param>
        /// <param name="userType">User type to use in the handler</param>
        /// <returns>A string with the type of user</returns>
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
