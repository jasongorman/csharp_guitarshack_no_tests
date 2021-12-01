using System;

namespace GuitarShack.Test
{
    public interface ISalesHistory
    {
        int Total(int productId, DateTime startDate, DateTime endDate);
    }
}