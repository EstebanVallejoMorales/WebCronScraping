using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.InputPort.JobManagement
{
    public interface IUnescheduleJobInputPort
    {
        Task Handler(string jobId);
    }
}
