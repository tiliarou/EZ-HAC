using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EZ_HAC
{
    class HacRunner
    {
        Process Hactool;

        public HacRunner()
        {
            Hactool = new Process();

            Hactool.StartInfo.FileName = "hactool.exe";

            Hactool.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        }

        public void RunHactoolCommand(string Args)
        {
            Hactool.StartInfo.Arguments = Args;
            Hactool.Start();
            Hactool.WaitForExit();
        }
    }
}
