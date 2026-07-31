using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireFly.utils
{
    public class MiscUtil
    {
        public enum CarType
        {
            None = 0,
            Sedan = 1,      // 승용(Sedan)	: 01 ~ 69 
            Van = 2,        // 승합(Van)	: 70 ~ 79
            Bus = 3,        // 버스(Bus)	: 72, 73
            Truck = 4,      // 화물(Truck)	: 80 ~ 97
            Pick = 5,       // 특수(Pick)	: 98, 99

            Etc = 99
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public  string  Check2Str(bool val)
        {
            if (val) return "T";
            return "F";
        }

        public byte[] ToBytes(string val, int len)
        {
            byte[] retv = new byte[len];
            byte[] temp = Encoding.UTF8.GetBytes(val);

            Array.Clear(retv, 0, retv.Length);
            if (temp.Length > len)
            {
                System.Array.Copy(temp, temp.Length - len, retv, 0, len);
            }
            else if (temp.Length < len)
            {
                System.Array.Copy(temp, 0, retv, len - temp.Length, temp.Length);
            }
            else System.Array.Copy(temp, retv, temp.Length);

            return retv;
        }

        public byte[] ToBytes(int i, int Digits)
        {
            string str = i.ToString(string.Format("D{0}", Digits));
            return Encoding.UTF8.GetBytes(str);
        }

        public byte[] FixNum(int val, int len)
        {
            byte[] retv = new byte[len];
            byte[] temp = BitConverter.GetBytes(val);
            Array.Reverse(temp);

            Array.Clear(retv, 0, retv.Length);
            if (temp.Length > len)
            {
                System.Array.Copy(temp, temp.Length - len, retv, 0, len);
            }
            else if (temp.Length < len)
            {
                System.Array.Copy(temp, 0, retv, len - temp.Length, temp.Length);
            }
            else System.Array.Copy(temp, retv, temp.Length);

            return retv;
        }

        public string GetValue4CarType(string car_no)
        {
            CarType type = GetCarType(car_no);
            switch (type)
            {
                case CarType.None: return "0";
                case CarType.Sedan: return "1";
                case CarType.Van: return "2";
                case CarType.Bus: return "3";
                case CarType.Truck: return "4";
                case CarType.Pick: return "5";
            }
            return "9";
        }

        public CarType GetCarType(string car_no)
        {

            string temp = car_no;

            int idx = IsHangul(temp);

            while (idx == 0)
            {
                temp = temp.Substring(1, temp.Length - 1);
                idx = IsHangul(temp);
            }
            if (idx > 3) return CarType.None;

            string head = temp.Substring(0, idx);

            int.TryParse(head, out int type);

            if (type >= 100) return CarType.Sedan;
            if (type >= 01 && type <= 69) return CarType.Sedan;
            if (type == 72 || type == 73) return CarType.Bus;
            if (type >= 70 && type <= 79) return CarType.Van;
            if (type == 98 || type == 99) return CarType.Pick;
            if (type >= 80 && type <= 97) return CarType.Truck;

            return CarType.Etc;
        }

        public int IsHangul(string str)
        {
            char[] inputchars = str.ToCharArray();
            var sb = new StringBuilder();
            for (int idx = 0; idx < inputchars.Length; idx++)
            {
                if (char.GetUnicodeCategory(inputchars[idx]) == UnicodeCategory.OtherLetter)
                {
                    return idx;
                }
            }

            return 0;
        }

    }
}
