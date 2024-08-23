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
            this.InnerHolidays.Add(ChristianHolidays.Epiphany);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(AnniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated);
            this.InnerHolidays.Add(SaintJosephDay);
            this.InnerHolidays.Add(LiberationDay);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(RepublicDay);
            this.InnerHolidays.Add(ChristianHolidays.Assumption);
            this.InnerHolidays.Add(ChristianHolidays.AllSaints);
            this.InnerHolidays.Add(ChristianHolidays.ImaculateConception);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
        }

        //17 March - Anniversary of the Unificatio of Italy, officially celebrated every 50 years starting from 1961 (included)
        private static Holiday anniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated;

        public static Holiday AnniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated
        {
            get
            {
                if (anniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated == null)
                {
                    anniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated = new YearDependantHoliday(
                        year => year >= 1961 && (year - 1961) % 50 == 0 , 
                        new FixedHoliday("Anniversary of the Unification of Italy Day (Officially Celebrated)", 3, 17)
                    );
                }
                return anniversaryOfTheUnificationOfItalyDayOfficiallyCelebrated;
            }
        }

        //19 March - Saint Joseph Day, until 1977 excluded
        private static Holiday saintJosephDay;

        public static Holiday SaintJosephDay
        {
            get
            {
                if (saintJosephDay == null)
                {
                    saintJosephDay = new YearDependantHoliday(
                        year => year < 1977, new FixedHoliday("Saint Joseph Day", 3, 19));
                }
                return saintJosephDay;
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

        //2 June - Republic Day
        private static Holiday republicDay;

        public static Holiday RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new FixedHoliday("Republic Day", 6, 2);
                }
                return republicDay;
            }
        }
        
        //29 June - Saint Peter and Paul Feast, until 1977 excluded
        private static Holiday saintPeterAndPaulFeast;

        private static Holiday SaintPeterAndPaulFeast
        {
            get
            {
                if (saintPeterAndPaulFeast == null)
                {
                    saintPeterAndPaulFeast = new YearDependantHoliday(
                        year => year < 1977, new FixedHoliday("Saint Peter and Paul Feast", 6, 29)
                    );
                }
                return saintPeterAndPaulFeast;
            }
        }
    }
}
