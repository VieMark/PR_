namespace PR_;
using System;
using System.Security.Cryptography.X509Certificates;

public abstract class Animal { // нельзя создать объект
    public string Name {get; set;}

    public abstract void MakeSound();
}

public class Dog : Animal { // можно создать объект  
    public Dog (string name) {
        Name = name;
    }
    public override void MakeSound(){
        Console.WriteLine($"Собака {Name} говорит : Гав - Гав");
    }  
}

public class Cat : Animal{
    public Cat(string name){
        Name = name;
    }
    public override void MakeSound(){
        Console.WriteLine($"Кошка {Name} говорит : Мяу - Мяу");
    }
}

public class Cow : Animal{
    public Cow(string name){
        Name = name;
    }
    public override void MakeSound(){
        Console.WriteLine($"Корова {Name} говорит : Муу");
    }
}


public abstract class Transport {
    public double Speed{get; set;}
    public abstract void Move();
}
public class Car : Transport{
    public Car(double speed){
        Speed = speed;
    }
    public override void Move()
    {
        Console.WriteLine($"Еду по дороге со скоростью {Speed} км/ч");
    }
}
public class Boat : Transport{
    public Boat(double speed){
        Speed = speed;
    }
    public override void Move()
    {
        Console.WriteLine($"Плыву по воде со скоростью {Speed} км/ч");
    }
}
public class Plane : Transport{
    public Plane(double speed){
        Speed = speed;
    }
    public override void Move()
    {
        Console.WriteLine($"Лечу в небе со скоростью {Speed} км/ч");
    }
}


public abstract class BankAccount {
    public double Balance{get; set;}
    public abstract void Withdraw(double amount);
    public void Deposit(double amount){
        if (amount < 0){Console.WriteLine("Нельзя пополнить балланс !");}
        else{
            Balance = Balance + amount;
            Console.WriteLine($"Вы успешно пополнили балланс ! Ваш счёт составляет - {Balance} руб.");
        }
    }
}
public class SavingsAccount : BankAccount{
    public SavingsAccount (double balance){
        Balance = balance;
    }
    public override void Withdraw(double amount){
        if (Balance - amount >= 100){
            Balance = Balance - amount;
            Console.WriteLine($"Вы сняли - {amount} руб. Ваш счёт составляет - {Balance} руб.");
        }
        else {
            Console.WriteLine("Невозможно снять деньги ! Остаётся меньше 100 руб") ;
        }
    }
}
public class CreditAccount : BankAccount{
    public CreditAccount(double balance){
        Balance = balance;
    }
    public override void Withdraw(double amount)
    {
        if (Balance - amount >= -500){
            Balance = Balance - amount;
            Console.WriteLine($"Вы сняли - {amount} руб. Ваш счёт составляет - {Balance} руб.");
        }
        else{
            Console.WriteLine($"Невозможно снять деньги ! Ваш балланс составляет - {Balance} руб.") ;
        }
    }
}


public abstract class GameCharacter(){
    public string Name{get; set;}
    public abstract void Attack();
}
public class Warrior : GameCharacter{
    public Warrior(string name){
        Name = name;
    }
    public override void Attack()
    {
        Console.WriteLine($"{Name} атакует мечом!");
    }
}
public class Mage : GameCharacter{
    public Mage(string name){
        Name = name;
    }
    public override void Attack()
    {
        Console.WriteLine($"{Name} атакует магией!");
    }
}
public class Archer : GameCharacter{
    public Archer(string name){
        Name = name;
    }
    public override void Attack()
    {
        Console.WriteLine($"{Name} стреляет из лука!");
    }
}


public abstract class Robot {
    public string Model{get; set;}
    public abstract void PerformTask(); 
}
public class CleanerRobot : Robot {
    public CleanerRobot(string model){
        Model = model;
    }
    public override void PerformTask()
    {
        Console.WriteLine($"{Model} убирает комнату");
    }
}
public class CookRobot : Robot {
    public CookRobot(string model){
        Model = model;
    }
    public override void PerformTask()
    {
        Console.WriteLine($"{Model} готовит еду");
    }
}
public class GuardRobot : Robot {
    public GuardRobot(string model){
        Model = model;
    }
    public override void PerformTask()
    {
        Console.WriteLine($"{Model} охраняет помещение");
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals= new List<Animal> {new Dog("Шарик"), new Cow("Бурёнка") , new Cat("Сёма")};
        foreach (var a in animals)
        {
            a.MakeSound();
        }

        Transport [] massiv = {new Car(120), new Boat(50.5) , new Plane(5555.5)};
        foreach (var i in massiv)
        {
            i.Move();
        }


        SavingsAccount SavAkk = new SavingsAccount(1000);
        SavAkk.Deposit(200.1);
        SavAkk.Withdraw(1300);
        SavAkk.Withdraw(1190.1);
        SavAkk.Withdraw(1100.1);
        SavAkk.Deposit(-190);

        CreditAccount CredAkk = new CreditAccount(111.5);
        CredAkk.Withdraw(600);
        CredAkk.Withdraw(100);
        CredAkk.Deposit(1000);
        CredAkk.Deposit(-189.77);

        GameCharacter [] Hero = {new Mage("Рик"), new Archer("Рудольф"), new Warrior("Дерек")};
        foreach (var i in Hero){
            i.Attack();
        }

        CleanerRobot ClRob = new CleanerRobot("KL-1-cleaner");
        CookRobot CoRob = new CookRobot("BCM-123-cook");
        GuardRobot GuRob = new GuardRobot("GRP-57-guard");

        ClRob.PerformTask();
        CoRob.PerformTask();
        GuRob.PerformTask();
    }
}
