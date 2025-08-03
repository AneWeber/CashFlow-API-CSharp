using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow_Application.AutoMapper;
using CashFlow_Application.UseCases.Expenses.Delete;
using CashFlow_Application.UseCases.Expenses.GetAll;
using CashFlow_Application.UseCases.Expenses.Register;
using CashFlow_Application.UseCases.Expenses.Reports.Excel;
using CashFlow_Application.UseCases.Expenses.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow_Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpensesUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
    }
}