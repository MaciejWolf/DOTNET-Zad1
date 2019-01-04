using System;
using System.Collections.Generic;
using System.Text;

namespace MaciejWolf_Task1
{
    class Buzzer
    {
        private const int FIZZ_NUMBER = 2;
        private const int BUZZ_NUMBER = 3;

        private const String FIZZ_SIGNAL = "Fizz";
        private const String BUZZ_SIGNAL = "Buzz";

        public String GetSignal(int input)
        {
            string signal = "";

            if (input % FIZZ_NUMBER == 0)
            {
                signal += FIZZ_SIGNAL;
            }

            if (input % BUZZ_NUMBER == 0)
            {
                signal += BUZZ_SIGNAL;
            }

            return signal;
        }
    }
}
