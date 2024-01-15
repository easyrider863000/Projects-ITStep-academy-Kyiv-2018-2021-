using _04_PingPong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            Ping ping = new Ping();
            Pong pong = new Pong();
            ping.Changed += pong.Change;
            pong.Changed += ping.Change;
            ping.Step();
        }
    }
}
