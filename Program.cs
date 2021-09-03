using System;
using System.Text.RegularExpressions;

namespace TimeConsoleApp3
{
    class TimeConsole
    {
        // Convert HH:MM to words
        static void convertToWords(int h, int m)
        {
            string[] numsM = { "zero", "one", "two", "three", "four",
                                "five", "six", "seven", "eight", "nine",
                                "ten", "eleven", "twelve", "thirteen",
                                "fourteen", "fifteen", "sixteen", "seventeen",
                                "eighteen", "nineteen", "twenty", "twenty one",
                                "twenty two", "twenty three", "twenty four",
                                "twenty five", "twenty six", "twenty seven",
                                "twenty eight", "twenty nine",
                            };

            string[] numsH = { "zero", "one", "two", "three", "four",
                                "five", "six", "seven", "eight", "nine",
                                "ten", "eleven", "twelve", "one",
                                "two", "three", "four", "five",
                                "six", "seven", "eight", "nine",
                                "ten", "eleven", "twelve",
                            };


            if ((h <= 23) && (m <= 59))
                {
                if (m == 0)
                    Console.WriteLine(numsH[h] + " o' clock ");

                else if (m == 1)
                    Console.WriteLine("one minute past " + numsH[h]);

                else if (m == 59)
                    Console.WriteLine("one minute to " +
                                        numsH[(h % 12) + 1]);

                else if (m == 15)
                    Console.WriteLine("quarter past " + numsH[h]);

                else if (m == 30)
                    Console.WriteLine("half past " + numsH[h]);

                else if (m == 45)
                    Console.WriteLine("quarter to " +
                                        numsH[(h % 12) + 1]);

                else if (m <= 30)
                    Console.WriteLine(numsM[m] + " minutes past " +
                                                            numsH[h]);

                else if (m > 30)
                    Console.WriteLine(numsM[60 - m] + " minutes to " +
                                                    numsH[(h % 12) + 1]);
                }
        }

        //Check the time is valid
        public bool IsTimeValid(string thetime)
        {
            Regex checktime = new Regex(@"(^\d+S[0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");

            return checktime.IsMatch(thetime);
        }

        // Run the main code
        public static void Main()
        {

            //Ask for and get a time or a return has been hit
            Console.WriteLine("Enter a time in a 24 hour format HH:MM (eg - 16:30), or just hit return to get the current time.");
            string timeEntered = Console.ReadLine();

            //If return has been entered get the hour and minutes for the current time
            if (timeEntered.Trim() == "")
                {
                    var src = DateTime.Now;
                    int hour = src.Hour;
                    int minutes = src.Minute;

                    convertToWords(hour, minutes);
                 }
            else
                {
                    TimeConsole checkTime = new TimeConsole();

                    if (checkTime.IsTimeValid(timeEntered) != true)
                        {
                            Console.WriteLine("Format of the time is incorrect.");
                        }
                    else
                        {
                            int hour = int.Parse(timeEntered.Substring(0,2));
                            int minutes = int.Parse(timeEntered.Substring(3, 2));

                            convertToWords(hour, minutes);
                        }
                }
        }
    }
}
