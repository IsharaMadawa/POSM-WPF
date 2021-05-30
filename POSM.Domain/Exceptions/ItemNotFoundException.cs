using System;

namespace POSM.Domain.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public int ItemId { get; set; }

        public ItemNotFoundException(int itemId)
        {
            ItemId = itemId;
        }

        public ItemNotFoundException(string message, int itemId) : base(message)
        {
            ItemId = itemId;
        }

        public ItemNotFoundException(string message, Exception innerException, int itemId) : base(message, innerException)
        {
            ItemId = itemId;
        }
    }
}
