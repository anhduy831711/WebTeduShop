using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool Disposing)
        {
           if(!isDisposed && Disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }

        //Overide this to dispose custom objects
        protected virtual void DisposeCore()
        {

        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }
    }
}
