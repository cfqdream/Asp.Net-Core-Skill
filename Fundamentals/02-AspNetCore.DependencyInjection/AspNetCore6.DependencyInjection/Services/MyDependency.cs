﻿using AspNetCore6.DependencyInjection.Interfaces;

namespace AspNetCore6.DependencyInjection.Services
{
    #region snippet1
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage Message: {message}");
        }
    }
    #endregion

    #region snippet2
    public class MyDependency2 : IMyDependency
    {
        private readonly ILogger<MyDependency2> _logger;
        public MyDependency2(ILogger<MyDependency2> logger)
        { 
            _logger= logger;
        }
        public void WriteMessage(string message)
        {
            _logger.LogInformation($"MyDependency2.WriteMessage Message: {message}");
        }
    }
    #endregion
    public class MyDependency5 : IMyDependency
    {
        string MyInt { get; set; }
        public MyDependency5(string myInt)
        {
            MyInt = myInt;
        }
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency5.WriteMessage {MyInt} Message: {message}");
        }
    }

}
