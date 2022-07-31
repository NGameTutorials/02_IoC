using IoC.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace IoC.ViewModels
{
    public class Learn003VM
    {
        ServiceCollection ServiceContainer { get; }
        IServiceProvider? ServiceProvider { get; set; }

        public BasicCommand CreateValueCommand { get; set; }
        public BasicCommand GetValueCommand { get; set; }
        public BasicCommand UpdateValueCommand { get; set; }

        public Learn003VM()
        {
            ServiceContainer = new ServiceCollection();
            CreateValueCommand = new(CreateValue);
            GetValueCommand = new(GetValue);
            UpdateValueCommand = new(UpdateValue);
        }

        void CreateValue()
        {
            try
            {
                ServiceContainer.AddSingleton(typeof(TestClass1), (provider) => new TestClass1());
                //ServiceContainer.AddScoped(typeof(TestClass1), (provider) => new TestClass1());
                //ServiceContainer.AddTransient(typeof(TestClass1), (provider) => new TestClass1());
                ServiceProvider = ServiceContainer.BuildServiceProvider();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void GetValue()
        {
            //You can't get a service while you didn't Build ServiceProvider
            if (ServiceProvider == null)
            {
                MessageBox.Show("You can't get a service while you didn't Build ServiceProvider");
                return;
            }
            var value = (TestClass1?)ServiceProvider?.GetService(typeof(TestClass1));
            //Or
            //var value = ServiceProvider?.GetService<TestClass1>();
            if (value == null)
            {
                MessageBox.Show("You need to add service first");
            }
            else
                MessageBox.Show(value.Garbage.ToString());
        }

        void UpdateValue()
        {
            try
            {
                //This way is only works on Singlethon 
                //(Because provider always return same instance of an object, any change will affect the original instance)
                var value = ServiceProvider?.GetService<TestClass1>();
                if (value != null)
                    value.Garbage = !value.Garbage;
                GetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
