using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool success, string message) : base(true, message)
        {
        }

        public SuccessResult(string message) : base(false, message)
        {
        }

        public SuccessResult() : base(false)
        {
        }
    }
}
