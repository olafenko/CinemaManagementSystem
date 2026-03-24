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

            var entries = ChangeTracker.Entries().ToList();


            foreach (var entity in entries)
            {

                switch (entity.State)
                {

                    case EntityState.Added:
                        {
                            if(entity.CurrentValues.PropertyNames.Contains("KiedyDodal")) entity.Property("KiedyDodal").CurrentValue = DateTime.Now;

                            if (entity.CurrentValues.PropertyNames.Contains("KtoDodal"))  entity.Property("KtoDodal").CurrentValue = "admin";

                            if (entity.CurrentValues.PropertyNames.Contains("CzyAktywny"))  entity.Property("CzyAktywny").CurrentValue = true;
                            break;
                        }

                    case EntityState.Modified:
                        {
                            if (entity.CurrentValues.PropertyNames.Contains("KiedyModyfikowal")) entity.Property("KiedyModyfikowal").CurrentValue = DateTime.Now;
                            if (entity.CurrentValues.PropertyNames.Contains("KtoModyfikowal")) entity.Property("KtoModyfikowal").CurrentValue = "admin";
                            break;
                        }

                    case EntityState.Deleted:
                        {

                            entity.State = EntityState.Modified;

                            if (entity.CurrentValues.PropertyNames.Contains("KiedyWykasowal")) entity.Property("KiedyWykasowal").CurrentValue = DateTime.Now;
                            if (entity.CurrentValues.PropertyNames.Contains("KtoWykasowal")) entity.Property("KtoWykasowal").CurrentValue = "admin";
                            if (entity.CurrentValues.PropertyNames.Contains("CzyAktywny")) entity.Property("CzyAktywny").CurrentValue = false;
                            break;
                        }



                }

            }
            return base.SaveChanges();
        }

    }
}
