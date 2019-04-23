namespace Homework_12_04
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {
        // Контекст настроен для использования строки подключения "AppContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Homework_12_04.AppContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "AppContext" 
        // в файле конфигурации приложения.
        public AppContext()
            : base("name=AppContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}