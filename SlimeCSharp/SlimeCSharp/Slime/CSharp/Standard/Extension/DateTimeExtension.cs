using System;

namespace Slime.CSharp {

    public static class DateTimeExtension {

        public static TimeSpan DeltaTimeToNow(this DateTime starttime) {
            TimeSpan now = DateTime.Now.Subtract(starttime);
            return now;
        }

    }

}