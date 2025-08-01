﻿using CashFlow_Communication.Requests;
using CashFlow_Communication.Responses;

namespace CashFlow_Application.UseCases.Expenses.Register;
public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);

}
