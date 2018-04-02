using ScrumPokerCards.Helpers;
using System;

namespace ScrumPokerCards.Services.ChronometerService
{
    public class ChronometerService : IChronometerService
    {
        /* Private Atributes */

        private Nullable<DateTime> _startTime;
        private Nullable<TimeSpan> _offSet;

        /* Constructors */

        public ChronometerService()
        {
            _startTime = LocalSettings.Chronometer.StartTime;
            _offSet = LocalSettings.Chronometer.OffSet;
        }

        /* Properties */

        private Nullable<DateTime> StartTime
        {
            set
            {
                _startTime = value;
                LocalSettings.Chronometer.StartTime = value;
            }
        }

        private Nullable<TimeSpan> OffSet
        {
            set
            {
                _offSet = value;
                LocalSettings.Chronometer.OffSet = value;
            }
        }

        /* Implement Methods : IChronometerService */

        public void Start()
        {
            StartTime = DateTime.Now;
            if (_offSet == null)
                OffSet = new TimeSpan(0, 0, 0);
        }

        public void Pause()
        {
            OffSet = _offSet.Value.Add(CurrentInterval());
            StartTime = null;
        }

        public void Reset()
        {
            StartTime = null;
            OffSet = null;
        }

        public bool IsRunning()
        {
            return _startTime != null;
        }

        public bool IsResetted()
        {
            return _offSet == null;
        }

        public TimeSpan CurrentTime()
        {
            if (_offSet == null)
            {
                return TimeSpan.Zero;
            }
            else if (_startTime == null)
            {
                return _offSet.Value;
            }
            else
            {
                return _offSet.Value.Add(CurrentInterval());
            }
        }

        /* Private Methods */

        private TimeSpan CurrentInterval()
        {
            return DateTime.Now.Subtract(_startTime.Value);
        }
    }
}
