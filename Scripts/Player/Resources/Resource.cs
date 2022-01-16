using System;

namespace ResourceClasses
{
    public abstract class Resource
    {
        public Action<int> OnModifyValue;

        public int Value { get; protected set; }

        protected Resource()
        {
            OnModifyValue += ModifyValue;
        }

        protected virtual void ModifyValue(int modifyValue)
        {
            Value += modifyValue;
        }
    }
}