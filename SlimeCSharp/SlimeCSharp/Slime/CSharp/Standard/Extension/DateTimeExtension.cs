using System;

namespace Slime.Standard {

    public static class DateTimeExtension {

        public static TimeSpan DeltaTimeToNow(this DateTime starttime) {
            TimeSpan now = DateTime.Now.Subtract(starttime);
            return now;
        }

    }

}