using IoC.Models;
using System.ComponentModel.Design;
using System.Windows;

namespace IoC.ViewModels
{
    public class Learn001VM
    {
        public TestClass1? Object1 { get; set; }
        public static TestClass1? Object2 { get; set; }

        public BasicCommand CreateValueCommand { get; set; }
        public BasicCommand GetValueCommand { get; set; }
        public BasicCommand UpdateValueCommand { get; set; }

        public Learn001VM()
        {
            CreateValueCommand = new(CreateValue);
            GetValueCommand = new(GetValue);
            UpdateValueCommand = new(UpdateValue);
        }

        void CreateValue()
        {
            Object1 = new TestClass1();
            Object2 = new TestClass1();
        }

        void GetValue()
        {
            var value = Object1;
            //Same thing for Object2
            //var value = Object2;
            if (value == null)
            {
                MessageBox.Show("You need to add service first");
            }
            else
            {
                MessageBox.Show(value.Garbage.ToString());
            }
        }

        void UpdateValue()
        {
            if (Object1 != null)
                Object1.Garbage = !Object1.Garbage;
            if(Object2 != null)
                Object2.Garbage = !Object2.Garbage;
            GetValue();
        }
    }
}
