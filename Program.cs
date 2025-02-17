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

// 5
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
        Console.WriteLine($"Студент; Класс - {_grade}");
    }
}
public class Teacher : Person, ITeachable {
    public string _subject {get; set;}
    public Teacher(string name, int age, string subject) : base(name, age){
        _subject = subject;
    }
    public override void Introduce()
    {
        base.Introduce();
        Console.WriteLine($"Учитель; Предмет - {_subject}");
    }
    public void Teach(){
        Console.WriteLine($"Учитель {_name} проводит урок по {_subject}.");
    }
    
}



// 6
/*
6. Гонки (Классы, наследование, инкапсуляция, полиморфизм, интерфейсы)

Задача:
Создай абстрактный класс Racer с методом race().
Создай наследников:

CarRacer,
BikeRacer.

Добавь интерфейс TurboBoost, реализуй метод boost().

📌 Дополнительное задание: Сделай метод get_race_status(), который выводит текущую скорость гонщика.
*/
interface ITurboBoost{
    void Boost();
}
public abstract class Racer{
    public string _name{get; private set;}
    public int _speed{get; private set;}
    public Racer(string name, int speed){
        _name = name;
        _speed = speed;
    }
    public abstract void Rase();
    public virtual void Get_race_status(){
        Console.WriteLine($"{_name} движется со скоростью {_speed} км/ч.");
    }
}
public class CarRacer : Racer, ITurboBoost{
    public CarRacer(string name, int speed) : base(name, speed){}
    public override void Rase(){
        Console.WriteLine($"Автомобиль {_name} участвует в гонке.");
    }
    public void Boost(){
        Console.WriteLine($"Автомобиль {_name} активирует ускорение.");
    }
}
public class BikeRacer : Racer, ITurboBoost{
    public BikeRacer(string name, int speed) : base(name, speed){}
    public override void Rase(){
        Console.WriteLine($"Мотоцикл {_name} участвует в гонке.");
    }
    public void Boost(){
        Console.WriteLine($"Мотоцикл {_name} активирует ускорение.");
    }
}



// 7
/*
7. Интернет-магазин (Классы, инкапсуляция, наследование, интерфейсы, полиморфизм)

Задача:
Создай класс User с полями name, email.
Создай подклассы:

Customer (может покупать товары),
Admin (может добавлять товары).

Добавь интерфейс Manageable с методами add_product() и remove_product(), реализуй его в Admin.

📌 Дополнительное задание: Добавь корзину для покупок (Cart).
*/
interface IManageable{
    void Add_product(Products_store product);
    void Remove_product(Products_store product);
}
public abstract class User{
    public string _name {get; private set;}
    public string _email {get; private set;}
    public User(string name, string email){
        _name = name;
        _email = email;
    }
}
public class Products_store{
    public string _name {get; private set;}
    public double _price {get; private set;}
}
public class Cart {
    private List<Products_store> List_products = new List<Products_store>();
    public void Add_cart(Products_store product){
        List_products.Add(product);
        Console.WriteLine($"Товар {product._name} был добавлен в корзину.");
    }
    public void Delete_cart(Products_store product){
        if (List_products.Remove(product)){
            Console.WriteLine($"Товар {product._name} удалён из корзины.");
        }
        else{
            Console.WriteLine($"Товара {product._name} нет в корзине.");
        }
    }
}
public class Customer : User{
    public Cart Shopping_cart{get; private set;}
    public Customer(string name, string email) : base(name, email){
        Shopping_cart = new Cart();
    }
    public void Add_UserCart(Products_store product){
        Shopping_cart.Add_cart(product);
    }
}
public class Admin : User, IManageable{
    private List<Products_store> Products_List_Admin;
    public Admin (string name, string email, List<Products_store>  ProductsListAdmin) : base(name, email){
        Products_List_Admin = ProductsListAdmin;
    }
    public void Add_product(Products_store product){
        Products_List_Admin.Add(product);
        Console.WriteLine($"Админ {_name} добавил товар {product._name} в список возможных товаров.");
    }
    public void Remove_product(Products_store product){
        if (Products_List_Admin.Remove(product)){
            Console.WriteLine($"Админ {_name} удалил товар {product._name} из списка товаров.");
        }
        else{
            Console.WriteLine($"Товар {product._name} не был найден в списке товаров.");
        }
    }
}



// 8
/*
8. Музыкальная студия (Классы, наследование, интерфейсы, полиморфизм, инкапсуляция)

Задача:
Создай абстрактный класс Instrument с методом play().
Создай подклассы:

Guitar,
Piano.

Добавь интерфейс Tunable, реализуй метод tune().

📌 Дополнительное задание: Реализуй метод get_sound(), который возвращает звук инструмента.
*/
interface ITunable{
    void Tune();
}
public abstract class Instrument{
    public string name{get; private set;}
    public Instrument(string _name){
        name = _name;
    }
    public abstract void Play();
    public abstract void Get_sound();
}
public class Guitar : Instrument, ITunable{
    public Guitar(string _name) : base(_name){}
    public override void Play(){
        Console.WriteLine($"Гитара {name} исполняет мелодию.");
    }
    public override void Get_sound(){
        Console.WriteLine("Гитара издаёт разнообразные звуки");
    }
    public void Tune(){
        Console.WriteLine("Гитара настроена");
    }
}
public class Piano : Instrument, ITunable{
    public Piano(string _name) : base(_name){}
    public override void Play(){
        Console.WriteLine($"Пианино {name} исполняет мелодию.");
    }
    public override void Get_sound(){
        Console.WriteLine("Пианино издаёт разнообразные звуки");
    }
    public void Tune(){
        Console.WriteLine("Пианино настроена");
    }
}



// 9
/*
9. Библиотека (Классы, инкапсуляция, наследование, интерфейсы, полиморфизм)

Задача:
Создай класс Book с полями title, author.
Создай подклассы:

FictionBook,
ScienceBook.

Добавь интерфейс Readable с методом read().
*/
interface IReadable{
    void Read();
}
public abstract class Book : IReadable{
    public string Title{get; private set;}
    public string Author{get; private set;}
    public Book (string title, string author){
        Title = title;
        Author = author;
    }
    public abstract void Read();
}
public class FictionBook : Book{
    public FictionBook(string title, string author) : base(title, author){}
    public override void Read(){
        Console.WriteLine($"Я читаю художественную книгу {Title} от {Author}");
    }
}
public class ScienceBook : Book{
    public ScienceBook(string title, string author) : base(title, author){}
    public override void Read(){
        Console.WriteLine($"Я читаю научную книгу {Title} от {Author}");
    }
}



// 10
/*
10. Видеоигра (Классы, наследование, полиморфизм, интерфейсы, инкапсуляция)

Задача:
Создай класс Character с полями name, health.
Создай подклассы:

Warrior,
Mage.

Добавь интерфейс Fightable с методом attack().

📌 Дополнительное задание: Реализуй инвентарь (Inventory).
*/
interface IFightable{
    void Attack();
}
public abstract class Character{
    public string Name {get; private set;}
    public int Health {get; private set;}
    public Character(string name, int health){
        Name = name;
        Health = health;
    }
}
public class Warrior : Character, IFightable{
    public Warrior(string name, int health) : base(name, 100){}
    public void Attack(){
        Console.WriteLine($"{Name} атакует мечом.");
    }
}
public class Mage : Character{
    public Mage(string name, int health) : base(name, 100){}
    public void Attack(){
        Console.WriteLine($"{Name} атакует магией.");
    }
}

class Program
{
    static void Main()
    {

    }
}
