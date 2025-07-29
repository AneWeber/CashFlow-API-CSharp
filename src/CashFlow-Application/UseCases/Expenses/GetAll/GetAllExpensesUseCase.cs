using AutoMapper;
using CashFlow_Communication.Responses;
using CashFlow_Domain.Repositories.Expenses;

namespace CashFlow_Application.UseCases.Expenses.GetAll;
public class GetAllExpenseUseCase : IGetAllExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;

    public GetAllExpenseUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseExpensesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseExpensesJson
        {
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
}
