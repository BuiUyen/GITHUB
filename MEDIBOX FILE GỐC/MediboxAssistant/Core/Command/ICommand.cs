using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medibox.Model;

namespace Medibox.Command
{
    public interface ICommand
    {        
        int DM_Intent_TypeID { get; }
        String ExecuteCommand(Intent_Request data);
    }
}
