using System;
using System.Collections.Generic;
using System.Text;

namespace LehmanBrothersReloaded
{
    public class OpeningHours
    {
        public bool IsOpen(DateTime time)
        {
            switch (time.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    // 10:30 - 19:00 offen
                    if (time.Hour == 10) // Sonderfall: Punkt 10:30
                        if (time.Minute >= 30)
                            return true;
                        else
                            return false;
                    if (time.Hour == 19) // Sonderfall: Punkt 19:00
                        if (time.Minute == 00)
                            return true;
                        else
                            return false;
                    if (time.Hour >= 10 && time.Hour <= 18)
                        return true;
                    else
                        return false;
                case DayOfWeek.Saturday:
                    // 10:30 - 14:00 offen
                    if (time.Hour == 10)
                        if (time.Minute >= 30)
                            return true;
                        else
                            return false;
                    if (time.Hour == 14) // Sonderfall: Punkt 14:00
                        if (time.Minute == 00)
                            return true;
                        else
                            return false;

                    if (time.Hour >= 10 && time.Hour <= 13)
                        return true;
                    else
                        return false;
                default: // Sunday
                    return false;
            }
        }
    }
}
