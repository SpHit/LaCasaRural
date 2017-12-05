using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace LaCasaRural.Models
{
    public class Context: DbContext
    {
        public DbSet<Llogater> Llogaters { get; set; }
        public DbSet<Reserva> Reserves { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reserva>()
                .HasRequired(r => r.Llogater)
                .WithMany(m => m.Reserves)
                .HasForeignKey(k => k.IdLlogater)
                .WillCascadeOnDelete(true);
        }
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());

            if (entityEntry.Entity is Llogater &&
                (entityEntry.State == EntityState.Added ||
                entityEntry.State == EntityState.Modified))
            {
                Llogater llogater = entityEntry.Entity as Llogater;

                bool comprobar_codi_postal = Regex.Match(llogater.CodiPostal + "", @"^([1-9]{2}|[0-9][1-9]|[1-9][0-9])[0-9]{3}$", RegexOptions.IgnoreCase).Success;
                bool comprobar_nif = Regex.Match(llogater.NIF + "", @"^[0-9]{8}[A-Z]{1}$", RegexOptions.IgnoreCase).Success;
                bool comprobar_nom = (llogater.NomLlogater.Length >= 20 && llogater.NomLlogater.Length <= 200);
                bool comprobar_cognom = (llogater.CognomLlogater.Length >= 20 && llogater.CognomLlogater.Length <= 200);

                if (!comprobar_codi_postal)
                {
                    result.ValidationErrors.Add(
                        new System.Data.Entity.Validation.DbValidationError("CodiPostal",
                        "Amb compte! El format del codi postal introduit no és valid"));
                }
                if (!comprobar_nif)
                {
                    result.ValidationErrors.Add(
                        new System.Data.Entity.Validation.DbValidationError("NIF",
                        "Amb compte! El format del NIF introduit no és valid"));
                }
                if (!comprobar_nom)
                {
                    result.ValidationErrors.Add(
                        new System.Data.Entity.Validation.DbValidationError("NomLlogater",
                        "Amb compte! El format del Nom introduit no és valid ha de tenir una longitura mínima de 20 caracters i màxima de 200 caracters"));
                }
                if (!comprobar_cognom)
                {
                    result.ValidationErrors.Add(
                        new System.Data.Entity.Validation.DbValidationError("CognomLlogater",
                        "Amb compte! El format del Cognom introduit no és valid ha de tenir una longitura mínima de 20 caracters i màxima de 200 caracters"));
                }
                if (result.ValidationErrors.Count >= 0)
                {
                    return result;
                }
            } else if (entityEntry.Entity is Reserva &&
                (entityEntry.State == EntityState.Added ||
                entityEntry.State == EntityState.Modified))
            {
                Reserva reserva = entityEntry.Entity as Reserva;

                var dataEntrada = reserva.DataEntrada;
                var dataSortida = reserva.DataSortida;

                var data_a_comprobar = new DateTime();
                data_a_comprobar = data_a_comprobar.AddDays(1);

                if (dataEntrada > dataSortida)
                {
                    result.ValidationErrors.Add(
                        new System.Data.Entity.Validation.DbValidationError( "DataEntrada",
                        "La data d'entrada no pot ser més posterior a la data de sortida!"));
                }
                if (dataEntrada < data_a_comprobar.Date)
                {
                    result.ValidationErrors.Add(
                        new System.Data.Entity.Validation.DbValidationError("DataEntrada",
                        "La data d'entrada ha de ser de almenys 24 hores més tard que la data actual"));
                }
                if (result.ValidationErrors.Count >= 0)
                {
                    return result;
                }
            }

            return base.ValidateEntity(entityEntry, items);
        }
    }
}