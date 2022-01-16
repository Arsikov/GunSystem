using System;

namespace ResourceClasses
{
    public class ResourceRequest
    {
        protected Resource _resourceContainer;

        public ResourceRequest(Resource ResourceContainer, Action<int> ResourceModifyRequest)
        {
            _resourceContainer = ResourceContainer;

            ResourceModifyRequest += this.ResourceModifyRequest;
        }

        private void ResourceModifyRequest(int value)
        {
            _resourceContainer.OnModifyValue(value);
        }

        public int GetResourceValue()
        {
            return _resourceContainer.Value;
        }
    }
}
