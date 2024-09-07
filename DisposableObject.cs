using System;

namespace Suburb.Utils
{
    public class DisposableObject : IDisposable
    {
        private readonly Action onDispose;
        private bool isDisposed;

        public DisposableObject(Action onDispose)
        {
            this.onDispose = onDispose;
        }

        public void Dispose()
        {
            if (isDisposed)
                return;
            
            isDisposed = true;
            onDispose?.Invoke();
        }
    }
}
