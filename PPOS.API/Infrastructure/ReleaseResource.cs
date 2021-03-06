using System;

namespace Happibook.API.Infrastructure
{
    public class ReleaseResource : IDisposable
    {
        private readonly Action release;

        public ReleaseResource(Action release)
        {
            this.release = release;
        }

        public void Dispose()
        {
            this.release();
        }
    }
}
