using System;

namespace Invsion.Src.Shared.Errors
{
    class SingletonNotInitializedException : Exception
    {
        public SingletonNotInitializedException (string singletonName)
            : base(String.Format("Singleton has not been initialized: {0}", singletonName))
        {}
    }
}
