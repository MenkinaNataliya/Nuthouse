namespace DataBase
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbModel : DbContext
    {
        // Контекст настроен для использования строки подключения "DbModel" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "DataBase.DbModel" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "DbModel" 
        // в файле конфигурации приложения.
        public DbModel()
            : base("Nuthouse")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Denomination> Denominations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
       
        public virtual DbSet<Status> status {get; set;}
        public virtual DbSet<City> city { get; set; }
        public virtual DbSet<ChangeHistory> History { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}