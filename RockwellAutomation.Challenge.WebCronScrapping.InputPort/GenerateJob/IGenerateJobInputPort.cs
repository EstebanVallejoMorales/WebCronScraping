using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockwellAutomation.Challenge.WebCronScrapping.InputPort.GenerateJob
{
    public interface IGenerateJobInputPort
    {
        Task Handler(string url, string cronExpresion);
    }
}
