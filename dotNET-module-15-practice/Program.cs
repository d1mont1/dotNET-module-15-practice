using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Reflection;

namespace dotNET_module_15_practice
{
    class Program
    {
        static void ex1()
        {
            Console.WriteLine("\nЗАДАЧА №1\n");

            Type type = typeof(MyClass);

            Console.WriteLine("Имя класса: " + type.Name);


            Console.WriteLine("\nКонструкторы:");
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }


            Console.WriteLine("\nПоля и свойства:");
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"{field.FieldType} {field.Name} ({field.Attributes})");
            }
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"{property.PropertyType} {property.Name} ({property.Attributes})");
            }


            Console.WriteLine("\nМетоды:");
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"{method.ReturnType} {method.Name} ({method.Attributes})");
            }
        }

        static void ex2()
        {
            Console.WriteLine("\nЗАДАЧА №2\n");

            Type type = typeof(MySecondClass);
            object instance = Activator.CreateInstance(type);
            Console.WriteLine("Экземпляр MySecondClass создан!");
        }

        static void ex3()
        {
            Console.WriteLine("\nЗАДАЧА №3\n");

            Type type = typeof(MyThirdClass);
            object instance = Activator.CreateInstance(type);

            var property = type.GetProperty("Number"); // Изменение значения свойства
            property.SetValue(instance, 10);

            var method = type.GetMethod("Method"); 
            method.Invoke(instance, null); // Вызов метода

            Console.WriteLine("Значение свойства Number: " + property.GetValue(instance));
        }

        static void ex4()
        {
            Console.WriteLine("\nЗАДАЧА №4\n");

            Type type = typeof(MyFourthClass);
            object instance = Activator.CreateInstance(type);

            MethodInfo method = type.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(instance, null); // Вызов приватного метода
        }

        static void Main(string[] args)
        {
            ex1();
            ex2();
            ex3();
            ex4();
        }
    }
}
