using BethanysPieShopHRM.HR;

namespace BethanyPieShopHRM.Tests;

public class EmployeeTests
{
    [Fact]
    public void PerformWork_Add_NumberOfHoursWorked()
    {
        // Arrange
        Employee bethy = new Employee(
           "Bethany",
           "Mirrot",
           "mirrot.bethany@gmail.com",
           birthDay:  new DateTime(1995 ,7 ,21)
            );
        // Act
        bethy.PerformWork();
        // Assert
        Assert.Equal(2, bethy.NumberOfHoursWorked);
    }
    [Fact]
    public void PerformWork_Add_Custom_NumberOfHoursWorked()
    {
        // Arrange
        int workedThisWeek = 28;
        Employee bethy = new Employee(
            "Bethany",
            "Mirrot",
            "mirrot.bethany@gmail.com",
            birthDay:  new DateTime(1995 ,7 ,21)
        );
        // Act
        bethy.PerformWork(workedThisWeek);
        // Assert
        Assert.Equal(workedThisWeek + 1, bethy.NumberOfHoursWorked);
    }
}