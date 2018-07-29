using System.Diagnostics;

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

        public void RunCommand(string Args)
        {
            Hactool.StartInfo.Arguments = Args;
            Hactool.Start();
            Hactool.WaitForExit();
        }
    }
}
