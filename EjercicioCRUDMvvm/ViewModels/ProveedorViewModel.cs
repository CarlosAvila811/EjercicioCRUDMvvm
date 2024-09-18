using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.EntityFrameworkCore;

namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class ProveedorViewModel : ObservableObject
    {
        private Proveedor _proveedor = new Proveedor();
        public Proveedor Proveedor
        {
            get => _proveedor;
            set => SetProperty(ref _proveedor, value);
        }

        public ObservableCollection<Proveedor> Proveedores { get; } = new ObservableCollection<Proveedor>();

        [RelayCommand]
        public async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(Proveedor.Nombre) ||
                string.IsNullOrWhiteSpace(Proveedor.Direccion) ||
                string.IsNullOrWhiteSpace(Proveedor.Telefono) ||
                string.IsNullOrWhiteSpace(Proveedor.Email) ||
                string.IsNullOrWhiteSpace(Proveedor.Ciudad))
            {
                await Shell.Current.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            var context = App.DbContext;
            if (Proveedor.Id == 0)
            {
                context.Proveedores.Add(Proveedor);
            }
            else
            {
                context.Proveedores.Update(Proveedor);
            }
            await context.SaveChangesAsync();
            await CargarProveedores();
        }

        [RelayCommand]
        public async Task Eliminar()
        {
            if (Proveedor.Id == 0)
            {
                await Shell.Current.DisplayAlert("Error", "Seleccione un proveedor para eliminar", "OK");
                return;
            }

            var context = App.DbContext;
            context.Proveedores.Remove(Proveedor);
            await context.SaveChangesAsync();
            await CargarProveedores();
        }

        [RelayCommand]
        public async Task CargarProveedores()
        {
            Proveedores.Clear();
            var context = App.DbContext;
            var proveedores = await context.Proveedores.ToListAsync();
            foreach (var proveedor in proveedores)
            {
                Proveedores.Add(proveedor);
            }
        }
    }
}
