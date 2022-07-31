using IoC.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace IoC.ViewModels
{
    public class Learn004VM
    {
        ServiceCollection ServiceContainer { get; }
        IServiceProvider? ServiceProvider { get; set; }

        public BasicCommand CreateValueCommand { get; set; }
        public BasicCommand GetValueCommand { get; set; }
        public BasicCommand UpdateValueCommand { get; set; }

        public Learn004VM()
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
                //On singlethon service provider will call creator function at first getservice only.
                //ServiceContainer.AddSingleton(typeof(TestClass1), CreateTestClass1Instance);
                //ServiceContainer.AddScoped(typeof(TestClass1), CreateTestClass1Instance);
                ServiceContainer.AddTransient(typeof(TestClass1), CreateTestClass1Instance);
                ServiceProvider = ServiceContainer.BuildServiceProvider();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool garbageValue = false;
        TestClass1 CreateTestClass1Instance(IServiceProvider serviceProvider)
        {
            return new TestClass1()
            {
                Garbage = garbageValue
            };
        }

        void GetValue()
        {
            //You can't get a service while you didn't Build ServiceProvider
            if (ServiceProvider == null)
            {
                MessageBox.Show("You can't get a service while you didn't Build ServiceProvider");
                return;
            }
            //var value = (TestClass1?)ServiceProvider?.GetService(typeof(TestClass1));
            //Or
            var value = ServiceProvider?.GetService<TestClass1>();
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
                garbageValue = !garbageValue;
                GetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
