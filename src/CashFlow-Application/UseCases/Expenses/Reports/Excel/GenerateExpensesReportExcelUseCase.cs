using CashFlow_Domain.Enums;
using CashFlow_Domain.Reports;
using CashFlow_Domain.Repositories.Expenses;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;

namespace CashFlow_Application.UseCases.Expenses.Reports.Excel;
public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
{
    private const string CURRENCY_SYMBOL = "€";
    private readonly IExpensesReadOnlyRepository _repository;

    public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);
        if (expenses.Count == 0)
        {
            return [];
        }

        using var workbook = new XLWorkbook();

        workbook.Author = "CashFlow";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Arial";

        var worksheet = workbook.AddWorksheet(month.ToString("Y"));

        InsertHeader(worksheet);

        var raw = 2;
        foreach (var expense in expenses)
        {
            worksheet.Cell($"A{raw}").Value = expense.Title;
            worksheet.Cell($"B{raw}").Value = expense.Date;
            worksheet.Cell($"C{raw}").Value = ConvertPaymentMethod(expense.PaymentMethod);

            worksheet.Cell($"D{raw}").Value = expense.Amount;
            worksheet.Cell($"D{raw}").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";

            worksheet.Cell($"E{raw}").Value = ConvertCategory(expense.Category);
            worksheet.Cell($"F{raw}").Value = expense.Description;
            worksheet.Cell($"G{raw}").Value = expense.Notes;

            raw++;
        }

        worksheet.Columns().AdjustToContents();

        var file = new MemoryStream();
        workbook.SaveAs(file);

        return file.ToArray();
    }

    private string ConvertPaymentMethod(PaymentMethod payment)
    {
        return payment switch
        {
            PaymentMethod.Cash => ResourceReportPaymentMethods.CASH,
            PaymentMethod.CreditCard => ResourceReportPaymentMethods.CREDIT_CARD,
            PaymentMethod.DebitCard => ResourceReportPaymentMethods.DEBIT_CARD,
            PaymentMethod.EletronicTransfer => ResourceReportPaymentMethods.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }

    private string ConvertCategory(ExpensesCategories category)
    {
        return category switch
        {
            ExpensesCategories.Clothing => ResourceReportCategories.CLOTHING,
            ExpensesCategories.Education => ResourceReportCategories.EDUCATION,
            ExpensesCategories.Entertainment => ResourceReportCategories.ENTERTAINMENT,
            ExpensesCategories.Food => ResourceReportCategories.FOOD,
            ExpensesCategories.Health => ResourceReportCategories.HEALTH,
            ExpensesCategories.Housing => ResourceReportCategories.HOUSING,
            ExpensesCategories.Miscellaneous => ResourceReportCategories.MISCELLANEOUS,
            ExpensesCategories.PersonalCare => ResourceReportCategories.PERSONAL_CARE,
            ExpensesCategories.Transportation => ResourceReportCategories.TRANSPORTATION,
            ExpensesCategories.Utilities => ResourceReportCategories.UTILITIES,
            _ => string.Empty
        };
    }


    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
        worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
        worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_METHOD;
        worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
        worksheet.Cell("E1").Value = ResourceReportGenerationMessages.CATEGORY;
        worksheet.Cell("F1").Value = ResourceReportGenerationMessages.DESCRIPTION;
        worksheet.Cell("G1").Value = ResourceReportGenerationMessages.NOTES;

        worksheet.Cells("A1:G1").Style.Font.Bold = true;
        worksheet.Cells("A1:G1").Style.Fill.BackgroundColor =XLColor.FromHtml("#F5C2B6");

        worksheet.Cells("A1:C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cells("E1:G1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell("D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
    }
}
