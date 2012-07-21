using System;
using System.Configuration;

namespace ThreeBytes.ProjectHollywood.Configuration.Concrete.Paging
{
    public class PagingConfigurationManager
    {
        private static volatile PagingConfigurationSection uniqueInstance;
        private static object syncRoot = new Object();

        public PagingConfigurationManager()
        {
        }

        public static PagingConfigurationSection GetInstance()
        {
            //The approach below ensures that only one instance is created and only 
            //when the instance is needed. Also, the uniqueInstance variable is 
            //declared to be volatile to ensure that assignment to the instance variable 
            //completes before the instance variable can be accessed. Lastly, 
            //this approach uses a syncRoot instance to lock on, rather than 
            //locking on the type itself, to avoid deadlocks.

            if (uniqueInstance == null)
            {
                lock (syncRoot)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance =
                            (PagingConfigurationSection)ConfigurationManager.GetSection("pagingConfiguration");
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
