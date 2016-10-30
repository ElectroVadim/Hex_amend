using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Parsing
    {
        private string hexfile;
        private string text = "00000000";
        private string[] hexValuesS;
        public void adres(string hexfile)
        {
            this.hexfile = hexfile;
        }

        public void Text(string text)
        {
            this.text = text;
        }
        public void rewrite()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(hexfile);
            for(int i = 1;i<111;i++) file.ReadLine();
            string str = file.ReadLine(); 
            
            Console.WriteLine(str);

            Console.WriteLine(hexfile);

            string str1 = string.Empty;
            using (System.IO.StreamReader reader = System.IO.File.OpenText(hexfile))
            {
                
                str1 = reader.ReadToEnd();
                hexValuesS = str1.Split('\n');
                 string hexstring = hexValuesS[110].Remove(0, 1);

                 
                 string c = hexstring.Substring(0, 12);
                 string b = hexstring.Substring(20, 22);
                 text = c + text + b;
                 hexstring = text;  
                 hexstring = hexstring.Substring(0, hexstring.Length - 2);
                 text = hexstring;

                 for (int i = 0; i < hexstring.Length; i += 3)
                 {
                     hexstring = hexstring.Insert(i, " ");
                 }

                 hexstring = hexstring.Substring(1, hexstring.Length-1);
                 int Dec = 0;
                 string hexValues = hexstring;
                 string[] hexValuesSplit = hexValues.Split(' ');
                 foreach (String hex in hexValuesSplit)
                 {
                     int value = Convert.ToInt32(hex, 16);
                     //Console.WriteLine("hexadecimal value = {0},{1}",hex, value);
                     Dec += value;
                 }
                 Console.WriteLine(Dec);
                 Dec = 0 - Dec;
                 file.Close();
                  string crc = String.Format("0x{0:X}", Dec);
                  crc = crc.Substring(crc.Length-2,2);
                  Console.WriteLine(crc);
                  text =":"+ text + crc;
                  Console.WriteLine(text);
                  hexValuesS[110] = text;
                 
            }
            file.Close();
            System.IO.File.WriteAllLines(hexfile, hexValuesS);
            file.Close(); 
        }

    }
}
