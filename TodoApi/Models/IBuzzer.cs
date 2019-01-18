using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public interface IBuzzer
    {
        string GetSignal(int input);
    }
}
