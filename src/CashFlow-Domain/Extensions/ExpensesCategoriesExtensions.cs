using CashFlow_Domain.Enums;
using CashFlow_Domain.Reports;

namespace CashFlow_Domain.Extensions;
public static class ExpensesCategoriesExtensions
{
    public static string ExpensesCategoriesToString(this ExpensesCategories expensesCategories)
    {
        return expensesCategories switch
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
}
