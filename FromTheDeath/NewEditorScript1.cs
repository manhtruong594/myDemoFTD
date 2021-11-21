using UnityEditor;
using UnityEngine;

namespace P01_EnumVar
{
    using System;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            // In biến enum ra console
            var gender = Gender.Male;
            WriteLine($"My gender is {gender} ({(int)gender})");

            var day = DayOfWeek.Tuesday;
            WriteLine($"Today is {day} ({(int)day})");

            var color = Color.Blue;
            WriteLine($"My favorite color is {color} ({(int)color})");

            var month = Month.Aug;
            WriteLine($"My birth month is {month} ({(int)month})");

            WriteLine("--------------------------");

            // Chuyển đổi từ số sang enum
            gender = (Gender)1;
            WriteLine($"My gender is {gender} ({(int)gender})");

            month = (Month)8;
            WriteLine($"My birth month is {month} ({(int)month})");

            WriteLine("--------------------------");

            // Sử dụng các phương thức của lớp Enum

            // GetNames trả về danh sách tên hằng
            foreach (var d in Enum.GetNames(typeof(DayOfWeek)))
            {
                Write($"{d} ");
            }
            WriteLine();
            // GetValues trả về danh sách hằng (bao gồm cả tên và giá trị)
            foreach (var d in Enum.GetValues(typeof(DayOfWeek)))
            {
                Write($"{(int)d} ");
            }
            WriteLine();

            WriteLine("--------------------------");

            // Đọc giá trị số từ bàn phím và chuyển thành kiểu enum sử dụng lớp Enum

            Write("What is your gender? ");
            // đọc một số từ bàn phím (0, 1, 2) và chuyển thành kiểu Gender
            gender = (Gender)Enum.Parse(typeof(Gender), ReadLine());
            WriteLine($"Your gender is {gender}");
            if (gender == Gender.Unknown)
                WriteLine("Sorry!");

            Write("What is your favorite color? ");
            // đọc một số (1, 2 hoặc 3) và chuyển thành kiểu Color
            color = (Color)Enum.Parse(typeof(Color), ReadLine());
            WriteLine($"Your favorite color is {color}");

            Write("What is your birth month? ");
            // đọc một số (từ 1 đến 12) và chuyển thành kiểu Month
            month = (Month)Enum.Parse(typeof(Month), ReadLine());
            switch (month)
            {
                case Month.Feb:
                case Month.Mar:
                case Month.Apr:
                    WriteLine("You're born in Spring!");
                    break;

                case Month.May:
                case Month.Jun:
                case Month.Jul:
                    WriteLine("You're born in Summer!");
                    break;

                case Month.Aug:
                case Month.Sep:
                case Month.Oct:
                    WriteLine("You're born in Autumn!");
                    break;

                case Month.Nov:
                case Month.Dec:
                case Month.Jan:
                    WriteLine("You're born in Winter!");
                    break;
            }

            ReadKey();
        }
    }

    /// <summary>
    /// Enum chứa danh sách giới tính
    /// </summary>
    enum Gender
    {
        Male, Female, Unknown
    }

    /// <summary>
    /// Enum chứa danh sách ngày trong tuần
    /// </summary>
    enum DayOfWeek
    {
        Monday = 2, // hằng Monday có giá trị bằng 2
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,
        Saturday = 7,
        Sunday = 8
    }

    /// <summary>
    /// Enum chứa 3 hằng số màu kiểu byte
    /// </summary>
    enum Color : byte
    {
        Red = 1,
        Green = 2,
        Blue = 3
    }

    /// <summary>
    /// Enum chứa tên các tháng, giá trị bắt đầu từ 1
    /// </summary>
    enum Month
    {
        Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
    }
}