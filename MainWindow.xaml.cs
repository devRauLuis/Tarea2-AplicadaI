using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Tarea2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Role selectedRole = new Role();
        private Role newRole = new Role();
        public MainWindow()
        {
            InitializeComponent();
            GetRoles();
            AddRoleContainer.DataContext = newRole;
        }

        private void GetRoles()
        {
            RolesDataGrid.ItemsSource = RoleService.GetAll();
        }

        private void onAddNewClick(object sender, EventArgs e)
        {
            newRole = (sender as FrameworkElement).DataContext as Role;
            if (!Validate(newRole)) return;
            bool passed = RoleService.Create(newRole);
            if (passed)
            {
                GetRoles();
            }
        }

        private bool Validate(Role newRole)
        {

            bool valid = true;
            if (RoleService.Exists(newRole.Description) && newRole.Description.Length <= 0)
            {
                valid = false;
                MessageBox.Show("Por favor ingrese un rol valido.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return valid;
        }

        // private void onEditClick(object sender, EventArgs e)
        // {
        //     selectedRole = (sender as FrameworkElement).DataContext as Role;
        //     EditRoleContainer.DataContext = selectedRole;
        //     EditRoleWrapper.Visibility = Visibility.Visible;
        // }


        // private void onSaveAfterEditClick(object sender, EventArgs e)
        // {
        //     RoleService.Update(selectedRole);
        //     GetRoles();
        //     EditRoleWrapper.Visibility = Visibility.Collapsed;
        // }

        private void onDGSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRole = RolesDataGrid.SelectedItem as Role;
            ViewRoleContainer.DataContext = selectedRole;
        }

        private void onSaveClick(object sender, EventArgs e)
        {

            if (!Validate(newRole)) return;
            RoleService.Update(selectedRole);
            GetRoles();
        }


        private void onDeleteClick(object sender, EventArgs e)
        {
            var removedRole = RolesDataGrid.SelectedItem as Role;
            RoleService.Delete(removedRole);
            GetRoles();
        }
        private void onSearchClick(object sender, EventArgs e)
        {
            var search = SearchBox.Text;
            var filteredRoles = RoleService.FindByDescription(search);
            RolesDataGrid.ItemsSource = filteredRoles;
        }
        private void onClearClick(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            GetRoles();
        }

    }
}