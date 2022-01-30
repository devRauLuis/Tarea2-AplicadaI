using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Tarea2
{
    public class RoleService
    {

        public static List<Role> GetAll()
        {
            using (var context = new Context())
            {
                return context.UserRoles.ToList();
            }
        }

        public static bool Create(Role newRole)
        {
            bool passed = false;
            using (var context = new Context())
            {
                if (newRole is not null)
                {
                    try
                    {
                        newRole.CreatedAt = DateTime.Now;
                        context.UserRoles.Add(newRole);
                        passed = context.SaveChanges() > 0;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return passed;
            }
        }

        public static void Update(Role updatedRole)
        {
            if (updatedRole is not null)
                using (var context = new Context())
                {
                    context.Update(updatedRole);
                    context.SaveChanges();
                }
        }

        public static void Delete(Role removedRole)
        {
            if (removedRole is not null)
                using (var context = new Context())
                {
                    context.UserRoles.Remove(removedRole);
                    context.SaveChanges();
                }
        }

        public static bool Exists(string Description)
        {
            bool exists = false;
            if (Description is not null)
                using (var context = new Context())
                {
                    try { exists = context.UserRoles.Any(x => x.Description == Description); }
                    catch (Exception ex) { }
                }
            return exists;
        }
        public static List<Role> FindByDescription(string desc)
        {

            using (var context = new Context())
            {
                return context.UserRoles.Where(r => r.Description.Contains(desc)).ToList();
            }
        }
    }
}