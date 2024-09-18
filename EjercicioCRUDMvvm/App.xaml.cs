using Microsoft.EntityFrameworkCore;
using EjercicioCRUDMvvm.Data;

namespace EjercicioCRUDMvvm
{
    public partial class App : Application
    {
        public static AppDbContext DbContext { get; private set; }

        public App()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=app.db");
            DbContext = new AppDbContext(optionsBuilder.Options);

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
