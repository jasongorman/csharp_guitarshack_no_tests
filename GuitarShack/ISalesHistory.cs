using System;

namespace GuitarShack
{
    public interface ISalesHistory
    {
        int Total(int productId, DateTime startDate, DateTime endDate);
    }
}