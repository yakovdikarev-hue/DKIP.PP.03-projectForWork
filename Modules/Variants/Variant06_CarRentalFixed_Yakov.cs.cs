namespace ReviewSamples.Modules.Variants;
// Исправленная версия для варианта 6. Автор: Дикарёв Я.В.
public class Car
{
    public string Name { get; set; }
    public decimal DailyRate { get; set; }
}

public class RentalRequest
{
    public Car Car { get; set; }
    public int Days { get; set; }
    public bool Insurance { get; set; }
    public bool ChildSeat { get; set; }
}

public class RentalService
{
    private const decimal InsuranceFee = 500m;
    private const decimal ChildSeatFee = 300m;
    private const decimal LongTermDiscountRate = 0.1m;
    private const int LongTermDaysThreshold = 7;

    public decimal Calculate(RentalRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));
        
        if (request.Car == null)
            throw new ArgumentException("Автомобиль не указан", nameof(request));
        
        if (request.Car.DailyRate < 0)
            throw new ArgumentException("Суточная ставка не может быть отрицательной", nameof(request));
        
        if (request.Days <= 0)
            throw new ArgumentException("Количество дней аренды должно быть положительным", nameof(request));

        decimal total = request.Car.DailyRate * request.Days;

        if (request.Insurance)
            total += InsuranceFee;

        if (request.ChildSeat)
            total += ChildSeatFee;

        if (request.Days > LongTermDaysThreshold)
            total -= total * LongTermDiscountRate;

        return total;
    }
}
