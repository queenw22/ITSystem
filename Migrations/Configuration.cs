namespace TicketFinalSys.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TicketFinalSys.Models;
    using System.Collections.Generic;
    

    internal sealed class Configuration : DbMigrationsConfiguration<TicketFinalSys.DAL.SystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TicketFinalSys.DAL.SystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var tickets = new List<Ticket>
            {
                 new Ticket{RequestDate=DateTime.Now, FirstName="Tanya", LastName="Perry", RequestDesc="Technical Issue", TechAssigned="Queen", CompletionDate=DateTime.Now, Note="Missing Remote Scanner App", Status="Open"},
                new Ticket{RequestDate=DateTime.Now, FirstName="Mike", LastName="Lowrey", RequestDesc="Bug Issue", TechAssigned="Zen", CompletionDate=DateTime.Now, Note="Device Managers closes randomly", Status="Closed"},
                new Ticket{RequestDate=DateTime.Now, FirstName="Max", LastName="James",RequestDesc="Hardware Issue", TechAssigned="John", CompletionDate=DateTime.Now, Note="Need new keyboard", Status="Open"}
            };

            tickets.ForEach(t => context.Tickets.AddOrUpdate(p => p.RequestDesc, t));
            context.SaveChanges();
        }
    }
}
