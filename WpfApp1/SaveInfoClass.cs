using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class SaveInfoClass
    {
        private const char DELIMITER = '|';

        public enum Gender
        {
            Male = 0,
            Female = 1,
        }

        public enum Language
        {
            Croatian = 0,
            English = 1,
        }
        public enum AccessMethod
        {
            API = 0,
            File = 1
        }

        public enum Resolution
        {
            Res1 = 0,
            Res2 = 1,
            Res3 = 2
        }

        public Gender SelectedGender { get; set; }
        public Language SelectedLanguage { get; set; }
        public AccessMethod SelectedMethod { get; set; }
        public Resolution SelectedResolution { get; set; }

        public override string ToString()
        => $"{SelectedGender}, {SelectedLanguage}, {SelectedMethod}, {SelectedResolution}";

        public static SaveInfoClass Parse(string line)
        {
            string[] splitlines = line.Split(DELIMITER);
            if (splitlines.Length == 4)
            {
                if (!(splitlines[0].Length > 0) && !(splitlines[1].Length > 0) && !(splitlines[2].Length > 0) && !(splitlines[3].Length > 0))
                {
                    throw new InvalidDataException();
                }
                return new SaveInfoClass
                {
                    SelectedGender = (Gender)int.Parse(splitlines[0]),
                    SelectedLanguage = (Language)int.Parse(splitlines[1]),
                    SelectedMethod = (AccessMethod)int.Parse(splitlines[2]),
                    SelectedResolution = (Resolution)int.Parse(splitlines[3])
                };
            }
            else
            {
                throw new InvalidDataException();
            };
        }
        public static void WriteToFile(string PATH, SaveInfoClass infoclass)
        {
            string[] temp = new string[1];
            temp[0] = Write(infoclass);
            File.WriteAllLines(PATH, temp);
        }

        public static string Write(SaveInfoClass infoclass)
        {
            return $"{(int)infoclass.SelectedGender}{DELIMITER}{(int)infoclass.SelectedLanguage}{DELIMITER}{(int)infoclass.SelectedMethod}{DELIMITER}{(int)infoclass.SelectedResolution}";
        }
    }
}
