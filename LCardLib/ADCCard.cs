using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCardLib
{
    public abstract class ADCCard : IDisposable
    {
        private bool _disposed = false;

        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        public byte NumBits { get; protected set; }
        public bool IsPresent { get; protected set; }

        protected bool fReading;

        public bool IsReading { 
            get => fReading; 
            set 
            { 
                if (fReading != value)
                {
                    fReading = value;
                    if (fReading)
                    {
                        StartRead();
                    } else
                    {
                        StopRead();
                    }
                }
            } 
        }

        public double Freq { get; protected set; }

        public string CardName { get => GetCardName(); }

        public string CardDescription { get => GetCardDescription(); }

        public ADCCard()
        {
            fReading = false;
            Freq = 0;
            NumBits = 0;
            this.CalcMaxMinValues();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            // Dispose of managed resources here.
            if (disposing)
            {

            }

            // Dispose of any unmanaged resources not wrapped in safe handles.
            StopCard();
            _disposed = true;
        }

        protected abstract string GetCardDescription();
        protected abstract string GetCardName();

        abstract public int ReadValue(bool stopCondition);
        abstract public bool StartRead();
        abstract public void StopRead();

        abstract public bool InitCard(int readFreq);
        abstract public void StopCard();

        protected void CalcMaxMinValues()
        {
            int x = 2;
            for (var i = 2; i < NumBits; i++)
            {
                x *= 2;
            }

            MaxValue = x - 1;
            MinValue = -x;
        }
    }
}
