﻿using AutoMapper;
using CashFlow_Communication.Responses;
using CashFlow_Domain.Repositories.Expenses;
using CashFlow_Exception;
using CashFlow_Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.GetById;
public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetExpenseByIdUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseExpenseJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if(result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ResponseExpenseJson>(result);
    }
}