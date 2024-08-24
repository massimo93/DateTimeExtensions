#region License

// 
// Copyright (c) 2011-2012, João Matos Silva <kappy@acydburne.com.pt>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("it-IT")]
    public class IT_ITHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public IT_ITHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(new YearDependantHoliday(year => year < 1978 || year > 1984, ChristianHolidays.Epiphany));
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(new YearDependantHoliday(year => year < 1977, ChristianHolidays.CorpusChristi));
            this.InnerHolidays.Add(new YearDependantHoliday(year => year < 1977, ChristianHolidays.Ascension));
            this.InnerHolidays.Add(AnniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated);
            this.InnerHolidays.Add(SaintJosephDay);
            this.InnerHolidays.Add(LiberationDay);
            this.InnerHolidays.Add(EarlyXxCenturyWorkersDay);
            this.InnerHolidays.Add(LateModernPeriodWorkersDay);
            this.InnerHolidays.Add(RepublicDay);
            this.InnerHolidays.Add(new YearDependantHoliday(year => year < 1977, ChristianHolidays.StsPeterAndPaul));
            this.InnerHolidays.Add(ChristianHolidays.Assumption);
            this.InnerHolidays.Add(ChristianHolidays.AllSaints);
            this.InnerHolidays.Add(UnityAndArmedForcesDay);
            this.InnerHolidays.Add(ChristianHolidays.ImaculateConception);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
        }

        //17 March - Anniversary of the Unification of Italy, officially celebrated every 50 years starting from 1961 (included)
        private static Holiday anniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated;

        public static Holiday AnniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated
        {
            get
            {
                return anniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated ??
                       (anniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated = new YearDependantHoliday(
                           year => year >= 1961 && (year - 1961) % 50 == 0,
                           new FixedHoliday("Anniversary of the Unification of Italy Day (Officially Celebrated)", 3,
                               17)
                       ));
            }
        }

        //19 March - Saint Joseph Day, until 1977 excluded
        private static Holiday saintJosephDay;

        public static Holiday SaintJosephDay
        {
            get
            {
                return saintJosephDay ?? (saintJosephDay = new YearDependantHoliday(
                    year => year < 1977, new FixedHoliday("Saint Joseph Day", 3, 19)));
            }
        }
        
        //25 April - Liberation Day
        private static Holiday liberationDay;

        public static Holiday LiberationDay
        {
            get
            {
                if (liberationDay == null)
                {
                    liberationDay = new FixedHoliday("Liberation Day", 4, 25);
                }
                return liberationDay;
            }
        }

        //21 April - Rome Birthday - Early XX Century Italian Workers Day, introduced in 1924 and suppressed in 1944, both included
        private static Holiday earlyXxCenturyWorkersDay;

        public static Holiday EarlyXxCenturyWorkersDay
        {
            get
            {
                return earlyXxCenturyWorkersDay ?? (earlyXxCenturyWorkersDay = new YearDependantHoliday(
                    year => year >= 1924 && year <= 1944,
                    new FixedHoliday("Early XX Century Italian Workers Day", 4, 21)
                ));
            }
        }
        
        //1 May - Late modern period Italian Workers Day
        private static Holiday lateModernPeriodWorkersDay;

        public static Holiday LateModernPeriodWorkersDay
        {
            get
            {
                return lateModernPeriodWorkersDay ?? (lateModernPeriodWorkersDay = new YearDependantHoliday(
                    year => year >= 1945,
                    new FixedHoliday("Italian Workers Day", 5, 1)
                ));
            }
        }

        //2 June - Republic Day, since 1946 excluded
        private static Holiday republicDay;

        public static Holiday RepublicDay
        {
            get
            {
                return republicDay ?? (republicDay = new YearDependantHoliday(
                    year => year > 1946, new FixedHoliday("Republic Day", 6, 2)
                ));
            }
        }
        
        //4 November - Italian National Unity and Armed Forces Day, until 1977 excluded
        private static Holiday unityAndArmedForcesDay;

        public static Holiday UnityAndArmedForcesDay
        {
            get
            {
                return unityAndArmedForcesDay ?? (unityAndArmedForcesDay = new YearDependantHoliday(
                    year => year < 1977, new FixedHoliday("Unity and Armed Forces Day", 4, 11)
                ));
            }
        }
    }
}
