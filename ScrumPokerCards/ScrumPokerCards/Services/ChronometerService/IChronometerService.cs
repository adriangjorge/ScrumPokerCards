using System;

namespace ScrumPokerCards.Services.ChronometerService
{
    public interface IChronometerService
    {
        // Commands

        void Start();
        void Pause();
        void Reset();

        // Statusses

        bool IsRunning();
        bool IsResetted();

        TimeSpan CurrentTime();
    }
}
