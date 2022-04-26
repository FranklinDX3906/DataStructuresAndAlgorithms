// 主函数，用于测试
using System;
using Test;

class MainTest
{
    static void Main()
    {
        Person PersonTest = new Person();
        PersonTest.Name = "test0";
        Console.WriteLine(PersonTest.Name);

        Person1 PersonTest1 = new Person1();
        PersonTest1.Name = "test1";
        Console.WriteLine(PersonTest1.Name);
    }
}