using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerializeProject
{
    [Serializable]
    public class Employe
    {
        public string? Name { set; get; }
        public int Age { set; get; }
        public Company? Company { set; get; }

    }

    [Serializable]
    public class Company
    {
        public string? Title { set; get; }
        public Address? Address { set; get; }
    }

    [Serializable]
    public class Address
    {
        public string? City { set; get; }
        public string? Street { set; get; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Serialize
            //Employe employe = new Employe() { Name = "Bob", Age = 34 };

            //using(FileStream file = new("employes.bin", FileMode.OpenOrCreate))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(file, employe);
            //}

            //Deserialize
            //using (FileStream file = new("employes.bin", FileMode.Open))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    Employe employe = formatter.Deserialize(file) as Employe;

            //    Console.WriteLine($"Employe: name -> {employe?.Name}, age -> {employe?.Age}");
            //}

            // Serialize Collection
            //List<Company> companies = new()
            //{
            //    new(){ Title = "Yandex", Address = new(){ City = "Moscow", Street = "Tverskaya st." } },
            //    new(){ Title = "BaltFlot", Address = new(){ City = "St-Peterbug", Street = "Dostoevsky st." } }
            //};

            //List<Employe> employes = new()
            //{
            //    new(){ Name = "Joe", Age = 43, Company = companies[0] },
            //    new(){ Name = "Mike", Age = 22, Company = companies[1] },
            //    new(){ Name = "Whiliam", Age = 37, Company = companies[0] }
            //};

            //using (FileStream file = new("employes.bin", FileMode.OpenOrCreate))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(file, employes);
            //}


            //
            using (FileStream file = new("employes.bin", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var employes = formatter.Deserialize(file) as List<Employe>;

                foreach (var item in employes!)
                {
                    Console.WriteLine($"Employe: name -> {item?.Name}, " +
                                      $" age -> {item?.Age} company -> {item?.Company?.Title}");
                    Console.WriteLine($"\tcompany city -> {item?.Company?.Address?.City}" +
                                      $" street -> {item?.Company?.Address?.Street}");
                }
            }
        }
    }
}