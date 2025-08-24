﻿using CashFlow_Domain.Entities;

namespace CashFlow_Domain.Repositories.Expenses;
public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll(Entities.User user);
    Task<Expense?> GetById(Entities.User user, long id);

    Task<List<Expense>> FilterByMonth(DateOnly date);
}
