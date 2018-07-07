using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EZ_HAC
{
    class HacHelper
    {
        private struct HacInfo
        {
            public string FileHash;
            public string VersionString;
        }

        private static HacInfo[] HacVersions =
        {
            new HacInfo { FileHash = "1f609b4d4814e238522b54a49f7a5251", VersionString = "1.1.0" },
            new HacInfo { FileHash = "8a99a879262036eb2ed12d92f358ce56", VersionString = "1.0.1" },
            new HacInfo { FileHash = "f3433e97261c1f8d907aa2bbc5ffa024", VersionString = "1.0.0" }
        };

        public static string HacVersionString;

        public static void RunChecks()
        {
            CheckHactoolExe();
            CheckHactoolKeys();
        }

        private static void CheckHactoolExe()
        {
            if (!File.Exists("hactool.exe"))
            {
                MessageBox.Show("The hactool executable was not found, please make sure the hactool executable is in the same path as the EZ-HAC executable!", "Error!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }

            bool   InvalidHash = true;
            string HacHash     = GetFileHash("hactool.exe");

            // Debug outputs hactool executable hash
#if DEBUG
            Console.WriteLine($"hactool Executable File Hash: {HacHash}");
#endif

            for (int Index = 0; Index < HacVersions.Length; Index++)
            {
                HacInfo HacVersionInfo = HacVersions[Index];

                if (HacVersionInfo.FileHash == HacHash)
                {
                    InvalidHash  = false;
                    HacVersionString = HacVersionInfo.VersionString;
                }
            }

            // Debug does not show a messagebox for invalid hactool executable hashes
            if (InvalidHash)
            {
#if !DEBUG
                DialogResult HashResult = MessageBox.Show("The hactool executable hash does not match verified hactool hashes, do you want to continue? Some functions of EZ-HAC may not function with an invalid hactool executable!", "Warning!", MessageBoxButtons.YesNo);

                if (HashResult == DialogResult.No)
                {
                    Environment.Exit(0);
                }
                else
                {
#endif
                    HacVersionString = "Unknown";
#if !DEBUG
                }
#endif
            }
        }

        private static void CheckHactoolKeys()
        {
            if (!File.Exists("keys.dat"))
            {
                MessageBox.Show("Your hactool keys were not found, please make sure your hactool keys is in the same path as the EZ-HAC executable and called \"keys.dat\"!", "Error!", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private static string GetFileHash(string FileName)
        {
            using (MD5 HashContext = MD5.Create())
            {
                using (FileStream Stream = File.OpenRead(FileName))
                {
                    return BitConverter.ToString(HashContext.ComputeHash(Stream)).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
