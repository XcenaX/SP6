using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolsTest
{
    public class ThreadInfo
    {
        public int Id { get; set; }
        public int ProgrammThreadId { get; set; }
        public bool IsActive { get; set; }

        public ThreadInfo(int Id, int ProgrammThreadId, bool IsActive)
        {
            this.Id = Id;
            this.ProgrammThreadId = ProgrammThreadId;
            this.IsActive = IsActive;
        }
    }
}
