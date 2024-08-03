using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestBase
{
    public class RestResponse<T>
    {
        public T Data { get; set; } = default!;
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int? RecordCount { get; set; }
        public List<ResponseLink> Links { get; set; } = [];
    }
}
