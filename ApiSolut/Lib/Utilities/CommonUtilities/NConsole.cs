using System;
using System.Threading;

namespace CommonUtilities
{
    public static class NConsole
    {
        public static ConsoleKeyInfo ReadKeyWithTimeout(int millisTimeOut = 3000)
        {
            var k = new ConsoleKeyInfo();
            for (var cnt = millisTimeOut; cnt > 0; cnt--)
            {
                if (Console.KeyAvailable)
                {
                    k = Console.ReadKey();
                    break;
                }

                Thread.Sleep(1);
            }
            return k;
        }
        
        public static string ReadKeyWithTimeoutAsString(int secondsUntilTimeout = 3)
        {
            var k = new ConsoleKeyInfo();
            for (var cnt = secondsUntilTimeout; cnt > 0; cnt--)
            {
                if (Console.KeyAvailable)
                {
                    k = Console.ReadKey();
                    break;
                }

                Thread.Sleep(1000);
            }
            return k.Key.ToString();
        }
        
    }
}