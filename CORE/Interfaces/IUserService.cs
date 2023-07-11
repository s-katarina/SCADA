using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;

namespace CORE.Interfaces
{
    [ServiceContract]
    interface IUserService
    {
        [OperationContract]
        bool Login(string username, string password);
        [OperationContract]
        void Add(User user);
    }
}
