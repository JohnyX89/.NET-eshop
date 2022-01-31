using System;

namespace eshop.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Source { get; set; }

        public string Message { get; set; }


    }
}