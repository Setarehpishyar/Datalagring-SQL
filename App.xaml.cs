using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Data;
using ProjectManagementApp.Repositories;
using ProjectManagementApp.Services;
using ProjectManagementApp.ViewModels;
using System.Windows;

namespace ProjectManagementApp
{
    public partial class App : Application
    {
        public static IHost? Host { get; private set; }

        public App()
        {
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite("Data Source=projects.db"));

                    services.AddScoped<ProjectRepository>();

                    services.AddScoped<ProjectService>();
                    services.AddScoped<CustomerService>();

                    services.AddScoped<MainViewModel>();
                    services.AddScoped<ProjectViewModel>();

                    services.AddSingleton<MainWindow>(provider =>
                        new MainWindow(provider.GetRequiredService<MainViewModel>()));
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (Host == null)
            {
                MessageBox.Show("Application failed to initialize.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
                return;
            }

            var mainWindow = Host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Host?.Dispose();
        }
    }
}
