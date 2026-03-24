using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models
{
    public partial class PABProjektEntities 
    {

        public override int SaveChanges()
        {

            var entries = ChangeTracker.Entries();


            foreach (var entity in entries)
            {

                switch (entity.State)
                {

                    case EntityState.Added:
                        {
                            entity.Property("KiedyDodal").CurrentValue = DateTime.Now;
                            entity.Property("KtoDodal").CurrentValue = "admin";
                            entity.Property("CzyAktywny").CurrentValue = true;
                            break;
                        }

                    case EntityState.Modified:
                        {
                            entity.Property("KiedyModyfikowal").CurrentValue = DateTime.Now;
                            entity.Property("KtoModyfikowal").CurrentValue = "admin";
                            break;
                        }

                    case EntityState.Deleted:
                        {

                            entity.State = EntityState.Modified;

                            entity.Property("KiedyWykasowal").CurrentValue = DateTime.Now;
                            entity.Property("KtoWykasowal").CurrentValue = "admin";
                            entity.Property("CzyAktywny").CurrentValue = false;
                            break;
                        }



                }

            }
            return base.SaveChanges();
        }

    }
}
