using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCardLib
{
    public delegate void ProgressCallback(int progress);

    public class DataReader
    {
        private ADCCard card;

        private int freq = 160;

        private int diagLen = 60;

        public List<short> buffer = new List<short>();

        private ProgressCallback callback = null;

        public DataReader(ADCCard card, int freq, int diagLen)
        {
            this.card = card;
            this.freq = freq;
            this.diagLen = diagLen;

        }

        public bool DoMonitor()
        {

            return true;
        }

        public bool DoReadSample(IProgress<int> progress)
        {

            if (this.card.InitCard(this.freq))
            {
                var start = card.StartRead();
                if (start)
                {
                    for (var i = 0; i < this.freq; i++)
                    {
                        card.ReadValue(false);
                    }

                    buffer.Clear();
                    var simpleCountMax = diagLen * this.freq;
                    do
                    {
                        var val = (short)card.ReadValue(false);
                        buffer.Add(val);

                        if (progress != null)
                        {
                            progress.Report(val);
                        }
                        
                    } while (card.IsReading && buffer.Count < simpleCountMax);
                }
            }

            return true;
        }

        public void Execute()
        {

        }
    }
}
