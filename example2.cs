/* Save values from desktop application or load the saved values into the application*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace project_name
{
    class StatsSL
    {

        private static byte[] k = new byte[]
        {
        8,
        2,
        5,
        6,
        3,
        6,
        7,
        4
        };
        private static byte[] v = new byte[]
        {
        5,
        1,
        9,
        4,
        0,
        6,
        3,
        4
        };
        public static string Encyt(string text)
        {
            SymmetricAlgorithm symmetricAlgorithm = DES.Create();
            ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateEncryptor(StatsSL.k, StatsSL.v);
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            return Convert.ToBase64String(inArray);
        }
        public static string Decyt(string text)
        {
            SymmetricAlgorithm symmetricAlgorithm = DES.Create();
            ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateDecryptor(StatsSL.k, StatsSL.v);
            byte[] array = Convert.FromBase64String(text);
            byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
            return Encoding.Unicode.GetString(bytes);
        }
        public static bool WriteText(string FileNa, string Text)
        {
            byte[] array = Encoding.ASCII.GetBytes(StatsSL.Encyt(Text)).Reverse<byte>().ToArray<byte>();
            bool result;
            try
            {
                FileStream fileStream = new FileStream(FileNa + ".AnGer", FileMode.Create, FileAccess.Write);
                fileStream.Write(array, 0, array.Length);
                fileStream.Close();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static decimal LoadNum(string Data, int Loc)
        {
            return Convert.ToDecimal(StatsSL.GetValueFile(Data, Loc));
        }
        public static string GetValueFile(string TextData, int DataNum)
        {
            string[] array = TextData.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] array2 = array[DataNum].Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return array2[1];
        }
        public static string ReadText(string FileNa)
        {
            string result;
            try
            {
                result = StatsSL.Decyt(Encoding.ASCII.GetString(File.ReadAllBytes(FileNa + ".AnGer").Reverse<byte>().ToArray<byte>()));
            }
            catch
            {
                result = "";
            }
            return result;
        }
    }
}
