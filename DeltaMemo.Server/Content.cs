using System;
using System.Collections.Generic;

namespace DeltaMemo.Server
{
    public partial class Content
    {
        public long Id { get; set; }
        public string Text { get; set; } = null!;
        public DateTime WroteDate { get; set; }
    }
}
