using System;
using System.Globalization;
using GetALetterForANumber.Interfaces;


namespace GetALetterForANumber.Concrete
{
    public class IntegerRequest : IIntegerRequest
    {
        public IIntegerResponse Test (string input)
        {
            IIntegerResponse response = new IntegerResponse() { InputVaule = input, OutputValue = input };

            if (int.TryParse(input, out int value))
            {
                int mod7 = value % 7;
                int mod9 = value % 9;
                response.OutputValue = (mod7 == 0 && mod9 == 0) ? "EG" : (mod7 == 0 && mod9 != 0) ? "E" : (mod7 != 0 && mod9 == 0) ? "G" : input;
            }

            return response;

        }
    }
}
