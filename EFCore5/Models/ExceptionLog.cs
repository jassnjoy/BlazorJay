using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore5.Models
{
    public partial class ExceptionLog
    {
        public long ExceptionId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
}
