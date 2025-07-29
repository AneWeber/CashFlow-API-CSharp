namespace CashFlow_Exception.ExceptionsBase;
public class NotFoundException : CashFlowException
{
    public NotFoundException(string message) : base(message)
    {
    }
}