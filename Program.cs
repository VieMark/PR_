namespace PR_;
using System;
using System.Security.Cryptography.X509Certificates;

// 1
public class Animal{
    private string _name;
    public Animal(string name){
        _name = name;
    }
    public virtual void Make_sound(){
        Console.WriteLine($"Животное по имнени {_name} издаёт звук.");
    }
    public virtual void Info(){
        Console.WriteLine($"Имя - {_name}");
    }
}


// 2
public class BankAccount{
    private double _balance;

    public void Deposit(double amount){
        if (amount < 0){
            Console.WriteLine("Вы не можте пополнить счёт!");
        }
        else{
            _balance = _balance + amount;
            Console.WriteLine($"Вы успешно пополнили счёт! Ваш балланс - {_balanse}");
        }
    }
    public void Withdraw(double amount);
    public void Get_balance();
}



// 4
public interface Refuelable{
    void Refuel(double amount);
}
public abstract class Vehicle : Refuelable{
    public double Speed {get; set;}
    public virtual void Move(){
        Console.WriteLine($"Транспорт движется со скоростью - {Speed} км/ч");
    }
    public virtual void Get_Info(){
        Console.WriteLine("Данный транспорт обладает такими характеристиками :");
        Console.WriteLine($"Скорость - {Speed} км/ч");
    }
    public void Refuel(double amount) => Console.WriteLine($"Транспорт заправлен на {amount} литров");
}
public class Car : Vehicle {
    public string Brand {get; set;}
    public Car(double speed, string brand){
        Speed = speed;
        Brand = brand;
    }
    public override void Move()
    {
        Console.WriteLine($"Машина едет со скоростью - {Speed} км/ч");
    }
    public override void Get_Info()
    {
        Console.WriteLine("Данная машана обладает такими характеристиками :");
        Console.WriteLine($"Скорость - {Speed} км/ч");
        Console.WriteLine($"Бренд - {Brand}");
    }
}
public class Motorcycle : Vehicle{
    public string Type {get; set;}
    public Motorcycle(double speed, string type){
        Speed = speed;
        Type = type;
    }
    public override void Move()
    {
        Console.WriteLine($"Мотоцикл едет со скоростью - {Speed} км/ч");
    }
    public override void Get_Info()
    {
        Console.WriteLine("Данная машана обладает такими характеристиками :");
        Console.WriteLine($"Скорость - {Speed} км/ч");
        Console.WriteLine($"Тип - {Type}");
    }
}

//5
public interface ITeachable{
    void Teach();
}
public abstract class Person{
    public string Name {get; set;}
    public int Age {get; set;}
    public Person(string name, int age){
        Name = name;
        Age = age;
    }
}
public class Student : Person{
    public int Grade {get; set;}
    public Student(string name, int age, int grade){
        Name = name;
        Age = age;
        Grade = grade;
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
