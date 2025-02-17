namespace PR_;
using System;
using System.Security.Cryptography.X509Certificates;

// 1
/*
1. Зоопарк (Базовые классы, наследование, полиморфизм, инкапсуляция, интерфейсы)

Задача:
Создай класс Animal с закрытым полем _name и методом make_sound().
Создай наследников:

Lion (рычит: "Р-р-р!"),
Elephant (трубит: "Тууу!"),
Parrot (говорит: "Привет!").

Добавь интерфейс CanFly, реализуй его в Parrot (метод fly()).
Создай массив животных и вызови их make_sound().

📌 Дополнительное задание: Реализуй метод info(), который выводит имя и тип животного.
*/
interface ICanFly{
    void Fly();
}
public abstract class Animal{
    private string _name;
    public Animal(string name){
        _name = name;
    }
    public abstract void Make_sound();
    public void Info(){
        Console.WriteLine($"Имя - {_name} ; Тип - {GetType().Name}");
    }
}
public class Lion : Animal{
    public Lion(string name) : base(name){}
    public override void Make_sound()
    {
        Console.WriteLine("рычит: Р-р-р! ");
    }
}
public class Elephant : Animal{ 
    public Elephant(string name) : base(name){}
    public override void Make_sound()
    {
        Console.WriteLine("трубит: Тууу! ");
    }
}
public class Parrot : Animal, ICanFly{
    
    public Parrot(string name) : base(name){}
    public override void Make_sound()
    {
        Console.WriteLine("говорит: Привет!");
    }
    public void Fly(){
        Console.WriteLine($"Попугай летит");
    }
}



/*
2. Банковская система (Инкапсуляция, наследование, полиморфизм, интерфейсы)

Задача:
Создай класс BankAccount с закрытым полем _balance.
Добавь методы:

deposit(amount),
withdraw(amount),
get_balance().

Создай наследников:

SavingsAccount (накопительный счет, нельзя снимать деньги),
CreditAccount (счет с лимитом на -1000).

📌 Дополнительное задание: Сделай интерфейс Transaction, добавь в него transfer(amount, account).
*/
// 2
interface ITransaction{
    void Transfer(double amount, BankAccount account);
}
public class BankAccount : ITransaction{
    private double _balance;
    public BankAccount (double startBalanse){
        _balance = startBalanse;
    }

    public virtual void Deposit(double amount){
        if (amount > 0){   
            _balance = _balance + amount;
            Console.WriteLine($"Вы успешно пополнили счёт на {amount}. Ваш балланс - {_balance}");
        }
        else{
            Console.WriteLine("Вы не можте пополнить счёт!");
        }
    }
    public virtual bool Withdraw(double amount){
        if (amount > 0 && amount < _balance){
            _balance = _balance - amount;
            Console.WriteLine($"Вы сняли {amount}. Ваш счёт составляет - {_balance}");
            return true;
        }
        else{
            Console.WriteLine("Недостаточно средств.");
            return false;
        }
    }
    public double Get_balance(){
        return _balance;
    }
    public void Transfer(double amount, BankAccount account){
        if (Withdraw(amount)==true){
            account.Deposit(amount);
            Console.WriteLine($"Был выполнен перевод на аккаунт {account.GetType().Name}. Сумма перевода - {amount}");
        }
    }
}
public class SavingsAccount : BankAccount{
    public SavingsAccount(double startBalanse) : base(startBalanse){}
    public override bool Withdraw(double amount)
    {
        Console.WriteLine("Снятие средств запрещено.");
        return false;
    }
}
public class CreditAccount : BankAccount{
    public CreditAccount(double startBalanse) : base(startBalanse){}
    public override bool Withdraw(double amount)
    {
        if (Get_balance() - amount >= -1000){
            return base.Withdraw(amount);
        }
        else{
            Console.WriteLine("Превышен кредитный лимит.");
            return false;
        }
    }
}



// 3
/*
3. Магазин (Классы, наследование, инкапсуляция, полиморфизм, интерфейсы)

Задача:
Создай класс Product с полями name, price.
Создай подклассы:

FoodProduct (добавь shelf_life – срок годности),
Electronics (добавь warranty – гарантия).

Создай интерфейс Discountable, добавь метод apply_discount(percent).
Реализуй интерфейс в Product.

📌 Дополнительное задание: Напиши метод print_info(), выводящий информацию о товаре.
*/
interface IDiscountable{
    void Apply_discount(double percent);
}
public abstract class Product : IDiscountable{
    private string _name;
    private double _price;
    public Product(string name, double prise){
        _name = name;
        _price = prise;
    }
    public virtual void Apply_discount(double percent){
        if (percent > 0 && percent <= 100){
            _price = _price * (percent / 100);
            Console.WriteLine($"Была применена скидка - {percent}.");
        }
        else{
            Console.WriteLine("Неверное число.");
        }
    }
    public virtual void Print_info(){
        Console.WriteLine($"Название - {_name}; Цена - {_price}");
    }
}
public class FoodProduct : Product{
    private string _shelf_life;
    public FoodProduct(string name, double price, string shelf_life) : base(name, price){
        _shelf_life = shelf_life;
    }
    public override void Print_info()
    {
        base.Print_info();
        Console.WriteLine($"Спок годности - {_shelf_life}");
    }
}
public class Electronics : Product{
    private int _warranty;
    public Electronics(string name, double price, int warranty) : base(name, price){
        _warranty = warranty;
    }
    public override void Print_info()
    {
        base.Print_info();
        Console.WriteLine($"Гарантия - {_warranty}");
    }
}



// 4
/*
4. Автосалон (Наследование, полиморфизм, инкапсуляция, интерфейсы)

Задача:
Создай абстрактный класс Vehicle с полем speed и методом move().
Создай наследников:

Car (имеет поле brand),
Motorcycle (имеет поле type).

Добавь интерфейс Refuelable с методом refuel(amount).

📌 Дополнительное задание: Реализуй метод get_info(), который выводит характеристики транспорта.
*/
public interface IRefuelable{
    void Refuel(int amount);
}
public abstract class Vehicle : IRefuelable{
    public int _speed {get; private set;}
    public Vehicle(int speed){
        _speed = speed;
    }
    public abstract void Move();
    public virtual void Get_Info(){
        Console.WriteLine($"Скорость - {_speed} км/ч");
    }
    public void Refuel(int amount){
        Console.WriteLine($"Транспорт заправлен на {amount} литров");
    }
}
public class Car : Vehicle {
    public string _brand {get; set;}
    public Car(int speed, string brand) : base(speed){
        _brand = brand;
    }
    public override void Move()
    {
        Console.WriteLine($"Машина {_brand} едет со скоростью - {_speed} км/ч");
    }
    public override void Get_Info()
    {
        base.Get_Info();
        Console.WriteLine($"Бренд - {_brand}");
    }
}
public class Motorcycle : Vehicle{
    public string _type {get; set;}
    public Motorcycle(int speed, string type) : base(speed){
        _type = type;
    }
    public override void Move()
    {
        Console.WriteLine($"Мотоцикл типа {_type} едет со скоростью - {_speed} км/ч");
    }
    public override void Get_Info()
    {
        base.Get_Info();
        Console.WriteLine($"Тип - {_type}");
    }
}

//5
/*
5. Школа (Классы, инкапсуляция, наследование, полиморфизм, интерфейсы)

Задача:
Создай класс Person с полями name, age.
Создай подклассы:

Student (добавь grade),
Teacher (добавь subject).

Добавь интерфейс Teachable с методом teach().

📌 Дополнительное задание: Реализуй метод introduce(), который выводит информацию о человеке.
*/
interface ITeachable{
    void Teach();
}
public abstract class Person{
    public string _name {get; private set;}
    public int _age {get; private set;}
    public Person(string name, int age){
        _name = name;
        _age = age;
    }
    public virtual void Introduce(){
        Console.WriteLine($"Имя - {_name}; Возраст - {_age}.");
    }
}
public class Student : Person{
    private int _grade;
    public Student(string name, int age, int grade) : base(name, age){
        _grade = grade;
    }
    public override void Introduce()
    {
        base.Introduce();
        
    }
}
public class Teacher : Person, ITeachable {
    public string Subject {get; set;}
    public Teacher(string name, int age, string subject){
        Name = name;
        Age = age;
        Subject = subject;
    }
    public void Teach(){
        
    }
    
}
class Program
{
    static void Main()
    {

    }
}
