using IoC.Models;
using System;
using System.ComponentModel.Design;
using System.Windows;

namespace IoC.ViewModels
{
    public class Learn002VM
    {

        ServiceContainer ServiceContainer { get; }

        public BasicCommand CreateValueCommand { get; set; }
        public BasicCommand GetValueCommand { get; set; }
        public BasicCommand UpdateValueCommand { get; set; }

        public Learn002VM()
        {
            ServiceContainer = new ServiceContainer();
            CreateValueCommand = new(CreateValue);
            GetValueCommand = new(GetValue);
            UpdateValueCommand = new(UpdateValue);

        }

        void CreateValue()
        {
            try
            {
                ServiceContainer.AddService(typeof(TestClass1), new TestClass1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void GetValue()
        {
            var value = (TestClass1?)ServiceContainer.GetService(typeof(TestClass1));
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
            try
            {
                ServiceContainer.RemoveService(typeof(TestClass1));
                ServiceContainer.AddService(typeof(TestClass1), new TestClass1() { Garbage = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GetValue();
        }
    }
}
