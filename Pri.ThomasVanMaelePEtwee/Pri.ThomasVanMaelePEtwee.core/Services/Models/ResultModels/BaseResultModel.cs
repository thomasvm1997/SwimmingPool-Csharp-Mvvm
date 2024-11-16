using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.ThomasVanMaelePEtwee.core.Services.Models.ResultModels
{
    public class BaseResultModel
    {

        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}

