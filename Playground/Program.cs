using static System.Console;
using Domain.Models;

// C# 9 Preview

decimal balance =
    new Account() // starts as active account
    .Deposit(200) // 200
    .Deposit(300) // 500
    .Close() // it turns to close, so it cannot deposit or withdraw
    .Deposit(5000) // do nothing
    .Withdraw(2000) // do nothing
    .Freeze() // it turns to freeze, so it will turn to active if deposit or withdraw 
    .Deposit(500) // 1000 then turn to active 
    .Freeze() // it turns to freeze, so it will turn to active if deposit or withdraw 
    .Close() // it turns to close, so it cannot deposit or withdraw
    .Deposit(1000) // do nothing
    .Activate()
    .Deposit(2000) // 3000 
    .Balance;

WriteLine(balance); // 3000
