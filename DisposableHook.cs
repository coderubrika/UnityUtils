using System;

namespace Suburb.Utils
{
    public class DisposableHook : IDisposable
    {
        private readonly Action onDispose;

        public DisposableHook(Action onDispose)
        {
            this.onDispose = onDispose;
        }

        public void Dispose()
        {
            onDispose?.Invoke();
        }
    }
}
