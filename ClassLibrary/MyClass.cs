using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ClassLibrary
{
    public class MyClass
    {
        public int PublicProperty { get; set; }
        private string PrivateField;
        public MyClass() { }
        private MyClass(int value) { }
        public void PublicMethod() { }
        private void PrivateMethod() { }
    }
}
