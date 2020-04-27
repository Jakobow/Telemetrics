using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemetrics.Models
{
    public class Telegram 
    {
        public long Id { get; set; }
        public DateTime date { get; set; }
        public float p1 { get; set; }
        public float p2 { get; set; }
        public float p3 { get; set; }
        public float p4 { get; set; }
        public float p5 { get; set; }
        public string t1 { get; set; }

        public Telegram()
        {
            date = System.DateTime.Now;
            p1 = 0;
            p2 = 0;
            p3 = 0;
            p4 = 0;
            p5 = 0;
            t1 = "TEST";

        }

        public Telegram(float p1_, float p2_, float p3_, float p4_, float p5_, string t1_)
        {
            date = System.DateTime.Now;
            p1 = p1_;
            p2 = p2_;
            p3 = p3_;
            p4 = p4_;
            p5 = p5_;
            t1 = t1_;

        }
    }
}
