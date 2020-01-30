using System;

namespace BookShop.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string Response { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}