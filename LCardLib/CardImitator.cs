using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCardLib
{
    public class CardImitator : ADCCard
    {
        private readonly Random rand = new Random();

        public CardImitator() : base()
        {
            IsPresent = true;
            NumBits = 14;
            CalcMaxMinValues();
        }

        protected override string GetCardDescription()
        {
            return "Имитатор карты АЦП";
        }

        protected override string GetCardName()
        {
            return "Имитатор";
        }

        public override bool InitCard(int readFreq)
        {
            IsReading = false;
            Freq = readFreq;
            return IsPresent;
        }

        public override void StopCard()
        {
            fReading = false;
        }

        public override int ReadValue(bool stopCondition = false)
        {
            //var s = (int)Math.Ceiling(1000 / Freq);
            //System.Threading.Thread.Sleep(s);
            System.Threading.Thread.Sleep(1);
            return rand.Next((MaxValue - MinValue) / 15) + MinValue + (MaxValue - MinValue) * 3 / 5;
        }

        public override bool StartRead()
        {
            fReading = true;
            return true;
        }

        public override void StopRead()
        {
            fReading = false;
        }
    }
}
