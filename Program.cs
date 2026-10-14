/*
* Name: Joseph Juszak
* Course: CSCI 1250, Section 001
* Assignment: Lab 04, The Group Trip
* Date: October 7, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
*              reports on a whole group instead of one person.
*/

Console.WriteLine("===== Part 1:The Trip ======");
Console.WriteLine("");


Console.WriteLine("How many miles are you traveling round trip? ");
double miles = Convert.ToDouble(Console.ReadLine ());

Console.WriteLine("How many miles per gallon does your car use? ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("What is the price of gas per gallon? ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

double fuel = fuelCost(miles, milesPerGallon, pricePerGallon);


Console.WriteLine("How many pizzas are you ordering?");
double pizzas = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("What is the price of a pizza?");
double priceOfPizza = Convert.ToDouble(Console.ReadLine());


double pizzaCost = pizzas * priceOfPizza;
double tripTotal = fuel + pizzaCost;

Console.WriteLine("Fuel Cost: " +fuel.ToString("C"));
Console.WriteLine("Pizza Cost: " + pizzaCost.ToString("C"));
Console.WriteLine("Total Trip Cost: " + tripTotal.ToString("C"));



Console.WriteLine("");
Console.WriteLine("===== Part 2: The Group ======");
Console.WriteLine("");

string[] names = {"Ada", "Grace", "Alan", "Katherine"};
double[] hoursWorked = {22, 15, 30, 18};
double[] hourlyRate = {13.50, 16.00, 11.20, 14.80};

int numberGoing = names.Length;

const double SLICES_PER_PIZZA = 8.0;

double slicesPerPerson = ((pizzas / SLICES_PER_PIZZA) / numberGoing);

double tripPerPerson = tripTotal / numberGoing;

System.Console.WriteLine("People going: " + names.Length);
System.Console.WriteLine("Slices each: " + slicesPerPerson);
System.Console.WriteLine("Cost per person: " +tripPerPerson.ToString("F2"));



Console.WriteLine("");
Console.WriteLine("===== Part 3: Who Works How Long =====");


const double TAX_RATE = 0.18;


double[] pay = new double[names.Length];

for(int i =0; i < names.Length; i++)
{
    pay[i] = takeHomePay(hoursWorked[i], hourlyRate[i]);
}

double[] payPerHour = new double[names.Length];

for(int i =0; i < names.Length; i++)
{
    payPerHour[i] = takeHomePayPerHour(pay[i], hoursWorked[i]);
}

double[] hoursNeeded = new double[names.Length];

for(int i =0; i < names.Length; i++)
{
    hoursNeeded[i] = (tripTotal/names.Length) / payPerHour[i];
} 

for(int i =0; i < names.Length; i++)
{
    Console.WriteLine($"{names[i]}: takes home {pay[i].ToString("C")} for {hoursWorked[i]} hours, {payPerHour[i].ToString("C")}, must work {hoursNeeded[i].ToString("F2")} hours. ");
} 


static double fuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

static double takeHomePay(double hoursWorked, double hourlyRate)
{
    double grossPay = hoursWorked * hourlyRate;
    double taxWithheld= grossPay * TAX_RATE;
    return grossPay - taxWithheld;
}

static double takeHomePayPerHour(double pay, double hoursWorked)
{
    return pay / hoursWorked;
}

















