﻿namespace CashFlow_Exception.ExceptionsBase;
public abstract class CashFlowException : System.Exception
{
    protected CashFlowException(string message) : base(message)
    {

    }
}
