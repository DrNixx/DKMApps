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
            var p = Process.Start(startInfo);
            p.WaitForExit(1000);
            var bytes = GetFileBytes(fnameOut);
            var resultStr = Encoding.GetEncoding(1251).GetString(bytes);
            resultStr = resultStr.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");

            File.Delete(fnameOut);
            File.Delete(fnameIn);

            return Encoding.GetEncoding(1251).GetBytes(resultStr);
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
            var bytes = GetFileBytes(fnameOut);
            //var resultStr = Encoding.GetEncoding(1251).GetString(bytes);

            File.Delete(fnameOut);
            File.Delete(fnameIn);

            return ByteToShort(bytes);
        }

        public static byte[] ShortToByte(short[] intArray)
        {
            byte[] result = new byte[intArray.Length * 2];
            Buffer.BlockCopy(intArray, 0, result, 0, result.Length);
            return result;
        }

        public static short[] ByteToShort(byte[] intArray)
        {
            short[] result = new short[intArray.Length / 2];
            Buffer.BlockCopy(intArray, 0, result, 0, intArray.Length);
            return result;
        }


        public static void SaveBytesToFile(string filename, byte[] bytesToWrite)
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

        public static byte[] GetFileBytes(string filename)
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
