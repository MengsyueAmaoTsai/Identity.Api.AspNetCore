using System.Collections.ObjectModel;

using Microsoft.Extensions.DependencyInjection;

using RichillCapital.Domain;

namespace RichillCapital.Persistence;

public static class SeedProvider
{
    public static readonly Collection<User> Users = [
        User.Create(UserId.From("1").Value, Email.From("mengsyue.tsai@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Amy").Value).Value,
        User.Create(UserId.From("2").Value, Email.From("mengsyue.tsai2@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Alice").Value).Value,
        User.Create(UserId.From("3").Value, Email.From("mengsyue.tsai3@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("YoYo").Value).Value,
        User.Create(UserId.From("4").Value, Email.From("mengsyue.tsai4@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Apple").Value).Value,
        User.Create(UserId.From("5").Value, Email.From("mengsyue.tsai5@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Julie").Value).Value,
        User.Create(UserId.From("6").Value, Email.From("mengsyue.tsai6@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Mason").Value).Value,
        User.Create(UserId.From("7").Value, Email.From("mengsyue.tsai7@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Osvaldo").Value).Value,
        User.Create(UserId.From("8").Value, Email.From("mengsyue.tsai8@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Cory").Value).Value,
        User.Create(UserId.From("9").Value, Email.From("mengsyue.tsai9@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Jay").Value).Value,
        User.Create(UserId.From("10").Value, Email.From("mengsyue.tsai10@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("YuChen").Value).Value,
        User.Create(UserId.From("11").Value, Email.From("mengsyue.tsai11@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Hog").Value).Value,
        User.Create(UserId.From("12").Value, Email.From("mengsyue.tsai12@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Yang").Value).Value,
        User.Create(UserId.From("13").Value, Email.From("mengsyue.tsai13@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Billy").Value).Value,
        User.Create(UserId.From("14").Value, Email.From("mengsyue.tsai14@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Chou").Value).Value,
        User.Create(UserId.From("15").Value, Email.From("mengsyue.tsai15@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Coco").Value).Value,
        User.Create(UserId.From("16").Value, Email.From("mengsyue.tsai16@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Kin").Value).Value,
        User.Create(UserId.From("17").Value, Email.From("mengsyue.tsai17@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Benson").Value).Value,
        User.Create(UserId.From("18").Value, Email.From("mengsyue.tsai18@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("YaoBai").Value).Value,
        User.Create(UserId.From("19").Value, Email.From("mengsyue.tsai19@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Dragon").Value).Value,
        User.Create(UserId.From("20").Value, Email.From("mengsyue.tsai20@outlook.com").Value, Password.From("Pa55w0rd!").Value, UserName.From("Joy").Value).Value,
    ];

    public static void Populate(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<MsSqlEfCoreDbContext>();

        context.Set<User>().AddRange(Users);

        context.SaveChanges();
    }
}