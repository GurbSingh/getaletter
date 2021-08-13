using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using GetALetterForANumber.Interfaces;

namespace GetALetterForANumber.Concrete
{
    public class IntegerResponse : IIntegerResponse
    {
        [JsonProperty("inputValue")]
        public string InputVaule { get; set; }
        [JsonProperty("outputValue")]
        public string OutputValue { get; set; }
    }
}
