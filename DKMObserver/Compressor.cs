using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKMObserver
{
    internal static class Compressor
    {
        public static byte[] CompressArray(short[] inpArray)
        {
            var fnameIn = Path.GetTempFileName();
            var fnameOut = Path.GetTempFileName();

            SaveBytesToFile(fnameIn, ShortToByte(inpArray));

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) +  @"\compress.exe";
            startInfo.Arguments = fnameIn + " " + fnameOut;
            Process.Start(startInfo);

            var result = GetFileBytes(fnameOut);

            File.Delete(fnameOut);
            File.Delete(fnameIn);

            return result;
        }

        public static short[] UncompressArray(byte[] inpArray)
        {
            var fnameIn = Path.GetTempFileName();
            var fnameOut = Path.GetTempFileName();

            SaveBytesToFile(fnameIn, inpArray);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\uncompress.exe";
            startInfo.Arguments = fnameIn + " " + fnameOut;
            var p = Process.Start(startInfo);
            p.WaitForExit(1000);
            var result = GetFileBytes(fnameOut);

            File.Delete(fnameOut);
            File.Delete(fnameIn);

            return ByteToShort(result);
        }

        private static byte[] ShortToByte(short[] intArray)
        {
            byte[] result = new byte[intArray.Length * 2];
            Buffer.BlockCopy(intArray, 0, result, 0, result.Length);
            return result;
        }

        private static short[] ByteToShort(byte[] intArray)
        {
            short[] result = new short[intArray.Length / 2];
            Buffer.BlockCopy(intArray, 0, result, 0, result.Length);
            return result;
        }


        private static void SaveBytesToFile(string filename, byte[] bytesToWrite)
        {
            if (filename != null && filename.Length > 0 && bytesToWrite != null)
            {
                if (!Directory.Exists(Path.GetDirectoryName(filename)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                }

                FileStream file = File.Create(filename);

                file.Write(bytesToWrite, 0, bytesToWrite.Length);

                file.Close();
            }
        }

        private static byte[] GetFileBytes(string filename)
        {
            if (File.Exists(filename))
            {
                FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read);
                byte[] fileBytes = new byte[fs.Length];
                fs.Read(fileBytes, 0, (int)fs.Length);
                fs.Close();
                return fileBytes;
            }

            return null;
        }
    }
}
