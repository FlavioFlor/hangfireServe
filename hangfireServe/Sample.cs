using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace hangfireServe
{
    public interface ISample 
    {
        void Start();
    }

    public class Sample : ISample
    {
        public void Start()
        {
            Console.WriteLine("FIRE ON");
        }
    }
    
}


